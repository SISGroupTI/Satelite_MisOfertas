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
    /// Lógica de interacción para MenuOfertaPage.xaml
    /// </summary>
    public partial class MenuOfertaPage : Page
    {
        RegistrarOfertaPage registrarOfertaPage;
        public MenuOfertaPage()
        {
            InitializeComponent();
        }

        private void btnAgregarOferta_Click(object sender, RoutedEventArgs e)
        {
            if (registrarOfertaPage == null) { registrarOfertaPage = new RegistrarOfertaPage(); }
            NavigationService.Navigate(registrarOfertaPage);
        }
    }
}
