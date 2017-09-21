using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para RegistrarLocalPage.xaml
    /// </summary>
    public partial class RegistrarLocalPage : Page
    {
        EmpresaNeg empresaNeg;
        public RegistrarLocalPage()
        {
            InitializeComponent();
            if(empresaNeg==null)
                empresaNeg = new EmpresaNeg();
            cargarEmpresas();
        }
        

        private void cargarEmpresas()
        {
            List<String> nombres = new List<string>();
            foreach (Empresa empresa in empresaNeg.ListarEmpresas())
            {
                String nombreEmpresa = empresa.NombreEmpresa;
                nombres.Add(nombreEmpresa);
                int idEmpresa = empresa.IdEmpresa;
                cbxEmpresa.ItemsSource = nombres;
                cbxEmpresa.SelectedValue = empresa.IdEmpresa;
            }
           
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
