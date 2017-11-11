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
    /// Lógica de interacción para VerDescuentoPage.xaml
    /// </summary>
    public partial class VerDescuentoPage : Page
    {
        DescuentoNeg descuentoNeg;
        List<Descuento> listaDescuento;

        public VerDescuentoPage()
        {
            InitializeComponent();
            if (descuentoNeg == null)
                descuentoNeg = new DescuentoNeg();
            if (listaDescuento==null)
                listaDescuento = descuentoNeg.listarDescuento();
            cargarDtDescuentos();
        }
        private void cargarDtDescuentos()
        {
            dtDescuentos.ItemsSource = listaDescuento;
            dtDescuentos.Items.Refresh();
        }

        private void btnGoVerDescuento(object sender, RoutedEventArgs e)
        {
            Descuento descuento = (Descuento)dtDescuentos.SelectedItems[0];
            VerDescuentoDetallePage verDescuentoDetallePage = new VerDescuentoDetallePage();
            verDescuentoDetallePage.obtenerDatosDescuento(descuento);
            NavigationService.Navigate(verDescuentoDetallePage);
        }

        private void txtBuscarDescuentos_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarDescuentos.Text.Length>0)
            {

                dtDescuentos.ItemsSource = listaDescuento.Where(descuento => descuento.Consumidor.Apellidos.ToLower().Contains(txtBuscarDescuentos.Text.ToLower()));
                dtDescuentos.Items.Refresh();
            }
            else
            {
                cargarDtDescuentos();
            }
        }
    }

    

}
