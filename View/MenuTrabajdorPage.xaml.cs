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
        List<Trabajador> lista = new List<Trabajador>();
        public MenuTrabajdorPage()
        {
            InitializeComponent();
            if (trabNeg == null)
                trabNeg = new TrabajadorNeg();
            cargarDataGridTrabajador();
        }




        private void cargarDataGridTrabajador()
        {
            lista = trabNeg.listarTrabajadores();
            if (lista != null)
            {
                dtTrabajador.ItemsSource = lista;
                dtTrabajador.Items.Refresh();
            }
            else
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Error de carga de datos","Carga Trabajadores",MessageBoxButtons.AbortRetryIgnore);
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
            if (registrarTrabajadorPage == null) { registrarTrabajadorPage = new RegistrarTrabajadorPage(); }
            NavigationService.Navigate(registrarTrabajadorPage);
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Confirmar accion", "Eliminar Trabajador", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Trabajador trabajador = (Trabajador)dtTrabajador.SelectedItems[0];
                Boolean res = trabNeg.EliminarTrabajadores(trabajador);
                if (res)
                {
                    System.Windows.MessageBox.Show("Trabajador Eliminado", "Eliminar Trabajador");
                    cargarDataGridTrabajador();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }



        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            Trabajador trabajador = (Trabajador)dtTrabajador.SelectedItems[0];
            if (modificarTrabajadorPage == null) { modificarTrabajadorPage = new ModificarTrabajadorPage(); }
            modificarTrabajadorPage.cargarDatosTrabajador(trabajador);
            NavigationService.Navigate(modificarTrabajadorPage);
        }
        
    }

}
