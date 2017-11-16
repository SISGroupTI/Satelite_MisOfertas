using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para MenuLocalPage.xaml
    /// </summary>
    public partial class MenuLocalPage : Page
    {
        RegistrarLocalPage registrarLocalPage;
        LocalNeg localNeg;
        List<Local> listaLocales;
        public MenuLocalPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
            if(listaLocales==null)
                listaLocales = localNeg.ListarLocales(); 
            cargarDataGridLocal();
        }

        private void updateListGridLocales()
        {
            listaLocales = localNeg.ListarLocales();
        }
        private void cargarDataGridLocal()
        {
            dtLocal.ItemsSource = listaLocales;
            dtLocal.Items.Refresh();
        }

        private void btnAgregarLocal_Click(object sender, RoutedEventArgs e)
        {
            goToEditar();
        }

        private void goToEditar()
        {
            if (registrarLocalPage == null) { registrarLocalPage = new RegistrarLocalPage(); }
            NavigationService.Navigate(registrarLocalPage);
        }

        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            /*
             * del data grid de empresas se rescata el item seleccionado
             * de la file del boton cickleado indexando al item seleccionado en 0
             * */
            Local local = (Local)dtLocal.SelectedItems[0];
            // Se instancia a la clase del page objetivo como en este caso es editar el local
            // se llama al ModificarLocalPage
            ModificarLocalPage modificarLocalPage = new ModificarLocalPage();
            // Este meto se usa especialemente para poder traspasar el objeto local en este caso
            // para relalizar las funciones correspondientes
            modificarLocalPage.cargarComboBoxEmpresa(local);
            NavigationService.Navigate(modificarLocalPage);
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
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Esta seguro de eliminar el registro seleccionado? \n Eliminar un local desvinculará y eliminará automaticamente todas las ofertas asociadas a este", "Eliminar registro - Local", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Se reliza la misma accion de rescatar al item seleccionado del data grid y parcearlo a Local
                Local local = (Local)dtLocal.SelectedItems[0];
                // Se procede a eliminar el local
                Boolean res = localNeg.EliminarLocal(local);
                if (res)
                {
                    System.Windows.MessageBox.Show("Registro eliminado exitosamente", "Eliminar registro - Local");
                    updateListGridLocales();
                    cargarDataGridLocal();
                }
            }
            
        }
        
        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            goToEditar();
        }

        private void txtBuscarLocal_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (txtBuscarLocal.Text.Length>0)
            {
                dtLocal.ItemsSource = listaLocales.Where(local=>local.Direccion.ToLower().Contains(txtBuscarLocal.Text.ToLower()));
                dtLocal.Items.Refresh();
            }
            else
            {
                cargarDataGridLocal();
            }
        }
    }
}
