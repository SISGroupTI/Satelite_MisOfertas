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
        List<Descuento> listaDescuento = new List<Descuento>();

        public VerDescuentoPage()
        {
            InitializeComponent();
            if (descuentoNeg == null)
                descuentoNeg = new DescuentoNeg();
            cargarDtDescuentos();
        }
        private void cargarDtDescuentos()
        {
            dtDescuentos.ItemsSource = descuentoNeg.listarDescuento();
            dtDescuentos.Items.Refresh();
        }

        private void btnGoVerDescuento(object sender, RoutedEventArgs e)
        {

        }
    }

    

}
