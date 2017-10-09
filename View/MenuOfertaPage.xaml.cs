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
    /// Lógica de interacción para MenuOfertaPage.xaml
    /// </summary>
    public partial class MenuOfertaPage : Page
    {
        RegistrarOfertaPage registrarOfertaPage;
        OfertaNeg ofertaNeg;
        DetalleOfertaNeg detalleOfertaNeg;
        ImagenesOfertaNeg imagenesOfertaNeg;
        public MenuOfertaPage()
        {
            InitializeComponent();
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            if (detalleOfertaNeg == null)
                detalleOfertaNeg = new DetalleOfertaNeg();
            if (imagenesOfertaNeg == null)
                imagenesOfertaNeg = new ImagenesOfertaNeg();
            cargarDtOfertas();
        }

        private void cargarDtOfertas()
        {
            dtOfertas.ItemsSource = ofertaNeg.ListarOfertas();
            dtOfertas.Items.Refresh();
        }

        private void btnAgregarOferta_Click(object sender, RoutedEventArgs e)
        {
            goToRegistrar();
        }

        private void goToRegistrar()
        {
            if (registrarOfertaPage == null) { registrarOfertaPage = new RegistrarOfertaPage(); }
            NavigationService.Navigate(registrarOfertaPage);
        }
        

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            goToRegistrar();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Confirmar accion", "Eliminar Oferta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Oferta oferta = (Oferta)dtOfertas.SelectedItems[0];
                if (oferta.IsDisponible == 1)
                {
                    System.Windows.MessageBox.Show("Error: Oferta en curso", "Eliminar Oferta");
                }
                else {
                    Boolean res = ofertaNeg.EliminarOferta(oferta);
                    if (res)
                    {
                        System.Windows.MessageBox.Show("Oferta Eliminado", "Eliminar Detalle");
                        cargarDtOfertas();
                    }
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            Oferta oferta = (Oferta)dtOfertas.SelectedItems[0];
            //DetalleOferta detalle = detalleOfertaNeg.
            ModificarOfertaPage modificarOfertaPage = new ModificarOfertaPage();
            List<DetalleOferta> lista= detalleOfertaNeg.BuscarDetalleOferta(oferta);
            List<ImagenOferta> listaImagenes = imagenesOfertaNeg.listarImagenesOfertaPorOferta(oferta);
            modificarOfertaPage.obtenerDatos(lista, oferta, listaImagenes);
            NavigationService.Navigate(modificarOfertaPage);
        }
    }
}
