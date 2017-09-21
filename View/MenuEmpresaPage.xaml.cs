using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
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
    /// Lógica de interacción para MenuEmpresaPage.xaml
    /// </summary>
    public partial class MenuEmpresaPage : Page
    {
        RegistrarEmpresaPage registrarEmpresaPage;
        EmpresaNeg empresaNeg;
        List<Empresa> lista = new List<Empresa>();
        public MenuEmpresaPage()
        {
            InitializeComponent();
            if (empresaNeg == null)
                empresaNeg = new EmpresaNeg();
            cargarEmpresas();
        }
        private void cargarEmpresas()
        {
            
            lista = empresaNeg.ListarEmpresas();
            dtEmpresa.ItemsSource = lista.ToList();
        }

        private void btnAgregarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (registrarEmpresaPage == null) { registrarEmpresaPage = new RegistrarEmpresaPage(); }
            NavigationService.Navigate(registrarEmpresaPage);
        }

        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = (Empresa)dtEmpresa.SelectedItems[0];
            int idEmpresa = empresa.IdEmpresa;
            ModificarEmpresaPage modificarEmpresaPage = new ModificarEmpresaPage();
            modificarEmpresaPage.cargarDatosEmpresa(empresa);
            NavigationService.Navigate(modificarEmpresaPage);
        }
    }
}
