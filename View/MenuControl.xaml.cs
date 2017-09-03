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
    /// Lógica de interacción para MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        private void menu_descuento_Click(object sender, RoutedEventArgs e)
        {
            MenuDescuentoWindow menuDescuentoWindow = new MenuDescuentoWindow();
            menuDescuentoWindow.Show();
        }
        private void menu_oferta_Click(object sender, RoutedEventArgs e)
        {
            MenuOfertasWindow menuOfertasWindow = new MenuOfertasWindow();
            menuOfertasWindow.Show();
        }

        private void registrar_empresa_Click(object sender, RoutedEventArgs e)
        {
            RegistrarEmpresaWindow registrarEmpresaWindow = new RegistrarEmpresaWindow();
            registrarEmpresaWindow.Show();
        }
    }
}
