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
        public VerOfertasPage()
        {
            InitializeComponent();
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            caragarDtOfertas();
            
        }

        private void caragarDtOfertas()
        {
            dtOfertas.ItemsSource = ofertaNeg.ListarOfertas();
            dtOfertas.Items.Refresh();
        }

        private void btnGoVer_Click(object sender, RoutedEventArgs e)
        {
            Oferta oferta = (Oferta)dtOfertas.SelectedItems[0];
            VerOfertaDetallePage verOferta = new VerOfertaDetallePage();
            verOferta.ObtenerOferta(oferta);
            NavigationService.Navigate(verOferta);
        }
    }
}
