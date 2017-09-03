using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using System.Diagnostics;

namespace View
{
    /// <summary>
    /// Lógica de interacción para PrincipalWindow.xaml
    /// </summary>
    public partial class PrincipalWindow : MetroWindow
    {

        PrincipalPage principalPage = new PrincipalPage();
        MenuOfertaPage menuOfertaPage;
        MenuDescuentoPage MenuDescuentoPage;
        RegistrarEmpresaPage registrarEmpresaPage;
        ModificarEmpresaPage modificarEmpresaPage;
        RegistrarLocalPage registrarLocalPage;
        ModificarLocalPage modificarLocalPage;
        public PrincipalWindow()
        {
            InitializeComponent();
            initFristPage();
            
        }

        private void initFristPage()
        {
            setNavigationService(principalPage);
        }

        private void menu_oferta_Click(object sender, RoutedEventArgs e)
        {
            if (this.menuOfertaPage==null)
            {
                menuOfertaPage = new MenuOfertaPage();
            }
            setNavigationService(menuOfertaPage);
        }

        private void menu_inicio_Click(object sender, RoutedEventArgs e)
        {
            initFristPage();
        }

        private void menu_descuento_Click(object sender, RoutedEventArgs e)
        {
            if (this.MenuDescuentoPage == null)
            {
                MenuDescuentoPage = new MenuDescuentoPage();
            }
            setNavigationService(MenuDescuentoPage);
        }

        private void registrar_empresa_Click(object sender, RoutedEventArgs e)
        {
            if (registrarEmpresaPage == null) { this.registrarEmpresaPage = new RegistrarEmpresaPage(); }
            setNavigationService(registrarEmpresaPage);
        }

        private void modificar_empresa_Click(object sender, RoutedEventArgs e)
        {
            if (modificarEmpresaPage == null) { this.modificarEmpresaPage = new ModificarEmpresaPage(); }
            setNavigationService(modificarEmpresaPage);
        }
        private void setNavigationService(Page page)
        {
            frame.NavigationService.Navigate(page);
        }

        private void registrar_local_Click(object sender, RoutedEventArgs e)
        {
            if (registrarLocalPage==null) { registrarLocalPage = new RegistrarLocalPage(); }
            setNavigationService(registrarLocalPage);
        }

        private void Mmodificar_local_Click(object sender, RoutedEventArgs e)
        {
            if (modificarLocalPage == null) { modificarLocalPage = new ModificarLocalPage(); }
            setNavigationService(modificarLocalPage);
        }
    }

}
