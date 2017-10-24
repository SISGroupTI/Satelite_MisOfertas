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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Lógica de interacción para VerOfertasPage.xaml
    /// </summary>
    public partial class VerOfertasPage : Page
    {
        OfertaNeg ofertaNeg;
        ImagenesOfertaNeg imagenesOfertaNeg;
        List<Oferta> listaOfertas;
        public VerOfertasPage()
        {
            InitializeComponent();
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            if (imagenesOfertaNeg == null)
                imagenesOfertaNeg = new ImagenesOfertaNeg();
            if(listaOfertas==null)
                listaOfertas = ofertaNeg.ListarOfertas();
            caragarDtOfertas();
            
        }

        private void caragarDtOfertas()
        {
            dtOfertas.ItemsSource = listaOfertas;//ofertaNeg.ListarOfertas();
            dtOfertas.Items.Refresh();
        }

        private void btnGoVer_Click(object sender, RoutedEventArgs e)
        {
            Oferta oferta = (Oferta)dtOfertas.SelectedItems[0];
            VerOfertaDetallePage verOferta = new VerOfertaDetallePage();
            List<ImagenOferta> listaImagenes = imagenesOfertaNeg.listarImagenesOfertaPorOferta(oferta);
            ValoracionOferta valoracionOferta = new ValoracionOfertaNeg().listarCantValoracionesPorOferta(oferta.IdOferta);
            verOferta.ObtenerOferta(oferta, listaImagenes,valoracionOferta);
            NavigationService.Navigate(verOferta);
        }

        private void TextBox_KeyDown_BuscarOferta(object sender, KeyEventArgs e)
        {
            
           
        }

        private void txtBuscarOfertas_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarOfertas.Text.Length > 0)
            {
                dtOfertas.ItemsSource = listaOfertas.Where(oferta => oferta.TituloOferta.Contains(txtBuscarOfertas.Text));
                dtOfertas.Items.Refresh();
            }
            else
            {
                caragarDtOfertas();
            }
        }
    }
}
