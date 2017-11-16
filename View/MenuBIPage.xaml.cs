using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Lógica de interacción para MenuBIPage.xaml
    /// </summary>
    public partial class MenuBIPage : Page
    {
        OfertaNeg ofertaNeg;
        public MenuBIPage()
        {
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            InitializeComponent();
        }

        public bool validarFechas()
        {
            if (dpFechaInicio.SelectedDate!=null && dpFechaTermino.SelectedDate!=null)
            {
                if (dpFechaInicio.SelectedDate < dpFechaTermino.SelectedDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool validarFechasVacias()
        {
            if (dpFechaInicio.SelectedDate!=null && dpFechaTermino.SelectedDate==null)
            {
                return true;
            }
            else if (dpFechaInicio.SelectedDate == null && dpFechaTermino.SelectedDate != null)
            {
                return true;
            }
            return false;
        }

        private void btnArchivoBI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validarFechasVacias())
                {
                    MessageBox.Show("Debes seleccionar una fecha de inicio y termino para generar el reporte\n a partir de una rango de fechas", "Generacion archivo BI");
                    dpFechaInicio.Focus();
                }
                else
                {
                    if (!validarFechas())
                    {
                        MessageBox.Show("La fecha de inicio debe ser menor a la de termino\n Ingrese nuevamente", "Generacion archivo BI");
                        dpFechaInicio.Focus();
                    }
                    else
                    {
                        String rutaDirectorioOferta = "D:/MisOfertas/BI";
                        DateTime fechaCreacionArchivo = DateTime.Now;
                        String rutaArchivo = rutaDirectorioOferta + "/ArchivoBI" + fechaCreacionArchivo.ToString("ddMMyyyyHHmm") + ".csv";

                        try
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            List<OfertaBI> listaOfertasBI;

                            if (dpFechaInicio.SelectedDate == null && dpFechaTermino.SelectedDate == null)
                            {
                                listaOfertasBI = ofertaNeg.listaOfertasBI(null, null);
                            }
                            else
                            {
                                listaOfertasBI = ofertaNeg.listaOfertasBI(dpFechaInicio.SelectedDate, dpFechaTermino.SelectedDate);
                            }

                            if (listaOfertasBI != null)
                            {
                                if (!Directory.Exists(rutaDirectorioOferta))
                                    Directory.CreateDirectory(rutaDirectorioOferta);
                                string csv = String.Join("", listaOfertasBI.Select(x => x.ToString()).ToArray());
                                File.WriteAllText(rutaArchivo, csv);
                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                MessageBox.Show("Archivo generado correctamente en la ruta:\n" + rutaArchivo, "Generacion archivo BI");

                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                Uri uriPdf = new Uri(rutaArchivo);
                                process.StartInfo.FileName = rutaArchivo;
                                process.Start();
                                process.WaitForExit();
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Se ha presentado un inconveniente al generar el archivo csv\n Intente nuevamente", "Generacion archivo BI");
                            File.Delete(rutaArchivo);
                        }
                    }
                }
            }
            catch (Exception err)
            {

            }
        }
    }
}
