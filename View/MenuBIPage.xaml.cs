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
    /// Lógica de interacción para MenuBIPage.xaml
    /// </summary>
    public partial class MenuBIPage : Page
    {
        OfertaNeg ofertaNeg;
        public MenuBIPage()
        {
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            InitializeComponent();
        }

        private void btnArchivoBI_Click(object sender, RoutedEventArgs e)
        {
            List<OfertaBI> listaOfertasBI = ofertaNeg.listaOfertasBI();
            if (listaOfertasBI!=null)
            {

            }
        }
    }
}
