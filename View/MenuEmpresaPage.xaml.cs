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
using System.Windows.Forms;
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
            dtEmpresa.Items.Refresh();
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult= System.Windows.Forms.MessageBox.Show("Confirmar accion", "Eliminar Empresa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Empresa empresa = (Empresa)dtEmpresa.SelectedItems[0];
                Boolean res = empresaNeg.EliminarEmpresa(empresa);
                if (res)
                {
                    System.Windows.MessageBox.Show("Empresa Eliminada", "Eliminar Empresa");
                    cargarEmpresas();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }
    }
}
