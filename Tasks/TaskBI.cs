using EntityLibrary;
using Microsoft.Win32.TaskScheduler;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tasks
{
    public class TaskBI
    {
        OfertaNeg ofertaNeg;
        public TaskBI()
        {
            if(ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
        }

        public void createTask()
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Generacion Automatica de la base de conocimientos sobre las ofertas accedidas por los consumidores";
                td.RegistrationInfo.Author = "Mis Ofertas";

                td.Triggers.Add(new WeeklyTrigger
                {
                    StartBoundary = DateTime.Today
                   + TimeSpan.FromHours(2),
                    DaysOfWeek = DaysOfTheWeek.Monday
                });

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction("notepad.exe", "c:\\test.log", null));
                td.
                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"Test", td);

                // Remove the task we just created
                ts.RootFolder.DeleteTask("Test");
            }
        }

        public void generarArchivo()
        {
            String rutaDirectorioOferta = "D:/MisOfertas/BI";
            DateTime fechaCreacionArchivo = DateTime.Now;
            String rutaArchivo = rutaDirectorioOferta + "/ArchivoBI" + fechaCreacionArchivo.ToString("ddMMyyyyHHmm") + ".csv";

            List<OfertaBI> listaOfertasBI = ofertaNeg.listaOfertasBI(null,null);
            if (listaOfertasBI!=null)
            {
                if (!Directory.Exists(rutaDirectorioOferta))
                    Directory.CreateDirectory(rutaDirectorioOferta);
                string csv = String.Join("", listaOfertasBI.Select(x => x.ToString()).ToArray());
                File.WriteAllText(rutaArchivo, csv);
                
            }
        }

    }
}
