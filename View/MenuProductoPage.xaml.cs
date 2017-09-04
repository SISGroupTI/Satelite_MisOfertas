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
    /// Lógica de interacción para MenuProductoPage.xaml
    /// </summary>
    public partial class MenuProductoPage : Page
    {
        RegistrarProductoPage registrarProductoPage;
        public MenuProductoPage()
        {
            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (registrarProductoPage == null) { registrarProductoPage = new RegistrarProductoPage(); }
            NavigationService.Navigate(registrarProductoPage);
        }
    }
}
