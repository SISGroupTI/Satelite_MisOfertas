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
            dtEmpresa.ItemsSource = lista;
            dtEmpresa.Items.Refresh();
        }
        //Evento del boton para agregar empresa
        private void btnAgregarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            gotoAgregarEmpresa();
            
        }

        private void gotoAgregarEmpresa()
        {
            if (registrarEmpresaPage == null) { registrarEmpresaPage = new RegistrarEmpresaPage(); }
            NavigationService.Navigate(registrarEmpresaPage);
        }

        /*
* Este metodo se encarga de derivar al modificar
* */
        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            /*
             * del data grid de empresas se rescata el item seleccionado
             * de la file del boton cickleado indexando al item seleccionado en 0
             * */
            Empresa empresa = (Empresa)dtEmpresa.SelectedItems[0];
            // Se instancia a la clase del page objetivo como en este caso es editar la empresa
            // se llama al ModificarEmpresaPage
            ModificarEmpresaPage modificarEmpresaPage = new ModificarEmpresaPage();
            // Este meto se usa especialemente para poder traspasar el objeto empresa en este caso
            // para relalizar las funciones correspondientes
            modificarEmpresaPage.cargarDatosEmpresa(empresa);
            // se procede a navegar hacia es page
            NavigationService.Navigate(modificarEmpresaPage);
        }
        /*
         * Este metodo es para la accion de eliminar
         * como este motodo no requiere de otra interfaz grafica la accion se lleva a cabo
         * desde esta clase
         * */
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Se crea un DialogResult para alojar la respuesta del MessageBox 
             * que en este caso se seteo el MessageBoxButtons con YesNo (ctrl+espacio) para mas opc 
             * */
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Está seguro de realizar esta accion? \n Eliminar este registro desvinculará automaticamente los locales y ofertas asociadas", "Eliminar registro - Empresa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Se reliza la misma accion de rescatar al item seleccionado del data grid y parcearlo a Empresa
                    Empresa empresa = (Empresa)dtEmpresa.SelectedItems[0];
                    // Se procede a eliminar la empresa
                    Boolean res = empresaNeg.EliminarEmpresa(empresa);
                    if (res)
                    {
                        // Se lanza el mensaje al usuario
                        System.Windows.MessageBox.Show("Empresa eliminada del sistema exitosamente", "Eliminar registro - Empresa");
                        // se procede a cargar las empresas nuevamente
                        cargarEmpresas();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Nada aqui
                }
            
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            gotoAgregarEmpresa();
        }
    }
}
