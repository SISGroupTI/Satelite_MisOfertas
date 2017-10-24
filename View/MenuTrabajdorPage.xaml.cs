using System;
using System.Collections.Generic;
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
using NegLibrary;
using EntityLibrary;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Windows.Forms;


namespace View
{
    /// <summary>
    /// Lógica de interacción para MenuTrabajdorPage.xaml
    /// </summary>
    public partial class MenuTrabajdorPage : Page
    {
        RegistrarTrabajadorPage registrarTrabajadorPage;
        ModificarTrabajadorPage modificarTrabajadorPage;
        TrabajadorNeg trabNeg;
        List<Trabajador> lista;
        public MenuTrabajdorPage()
        {
            InitializeComponent();
            if (trabNeg == null)
                trabNeg = new TrabajadorNeg();
            if (lista == null)
                lista = trabNeg.listarTrabajadores();
            cargarDataGridTrabajador();
        }




        private void cargarDataGridTrabajador()
        {
            if (lista != null)
            {
                dtTrabajador.ItemsSource = lista;
                dtTrabajador.Items.Refresh();
            }
            else
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Se ha presentado un inconveniente\n La lista de trabajadores no se ha cargado correctamente","Alerta!",MessageBoxButtons.AbortRetryIgnore);
                switch (dialogResult)
                {
                    case DialogResult.Abort:

                        break;
                    case DialogResult.Retry:
                        cargarDataGridTrabajador();
                        break;
                    case DialogResult.Ignore:
                        break;
                }
            }
        }


        private void btnAgregarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            toToRegistrar();

        }

        private void toToRegistrar()
        {
            if (registrarTrabajadorPage == null) { registrarTrabajadorPage = new RegistrarTrabajadorPage(); }
            NavigationService.Navigate(registrarTrabajadorPage);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Esta seguro de eliminar el registro seleccionado?", "Eliminar registro - Trabajador", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Trabajador trabajador = (Trabajador)dtTrabajador.SelectedItems[0];
                Boolean res = trabNeg.EliminarTrabajadores(trabajador);
                if (res)
                {
                    System.Windows.MessageBox.Show("Registro eliminado exitosamente del sistema", "Eliminar Trabajador");
                    cargarDataGridTrabajador();
                }
            }
            
        }



        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            Trabajador trabajador = (Trabajador)dtTrabajador.SelectedItems[0];
            if (modificarTrabajadorPage == null) { modificarTrabajadorPage = new ModificarTrabajadorPage(); }
            modificarTrabajadorPage.cargarDatosTrabajador(trabajador);
            NavigationService.Navigate(modificarTrabajadorPage);
        }
        
        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            toToRegistrar();

        }

        private void txtBuscarTrabajador_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (txtBuscarTrabajador.Text.Length>0)
            {
                dtTrabajador.ItemsSource = lista.Where(trabajador => trabajador.Apellidos.Contains(txtBuscarTrabajador.Text));
            }
            else
            {
                cargarDataGridTrabajador();
            }
        }
    }

}
