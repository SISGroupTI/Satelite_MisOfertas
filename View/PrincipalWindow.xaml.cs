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
        VerDescuentoPage verDescuentoPage;
        VerOfertasPage verOfertasPage;
        MenuOfertaPage menuOfertaPage;
        MenuLocalPage menuLocalPage;
        MenuProductoPage menuProductoPage;
        MenuEmpresaPage menuEmpresaPage;
        MenuTrabajdorPage menuTrabajdorPage;
        MenuReporteTiendaPage menuReporteTiendaPage;
        MenuReporteValoracionPage menuReporteValoracionPage;
        MenuBIPage menuBIPage;
        public PrincipalWindow()
        {
            InitializeComponent();
            initFristPage();
            
        }

        private void initFristPage()
        {
            setNavigationService(principalPage);
        }  
        private void menu_inicio_Click(object sender, RoutedEventArgs e)
        {
            initFristPage();
        }
        
        public void setNavigationService(Page page)
        {
            frame.NavigationService.Navigate(page);
        }
        
        private void ver_oferta_Click(object sender, RoutedEventArgs e)
        {
            if (verOfertasPage == null) { verOfertasPage = new VerOfertasPage(); }
            setNavigationService(verOfertasPage);
        }
        private void ver_descuento_Click(object sender, RoutedEventArgs e)
        {
            if (verDescuentoPage == null) { verDescuentoPage = new VerDescuentoPage(); }
            setNavigationService(verDescuentoPage);
        }
        private void menu_oferta_Click(object sender, RoutedEventArgs e)
        {
            if (menuOfertaPage == null) { menuOfertaPage = new MenuOfertaPage(); }
            setNavigationService(menuOfertaPage);
        }
        
        private void menu_local_Click(object sender, RoutedEventArgs e)
        {
            if (menuLocalPage == null) { menuLocalPage = new MenuLocalPage(); }
            setNavigationService(menuLocalPage);
        }

        private void menu_producto_Click(object sender, RoutedEventArgs e)
        {
            if (menuProductoPage == null) { menuProductoPage = new MenuProductoPage(); }
            setNavigationService(menuProductoPage);
        }

        private void menu_empresa_Click(object sender, RoutedEventArgs e)
        {
            if (menuEmpresaPage == null) { menuEmpresaPage = new MenuEmpresaPage(); }
            setNavigationService(menuEmpresaPage);
        }

        private void menu_trabajor_Click(object sender, RoutedEventArgs e)
        {
            if (menuTrabajdorPage == null) { menuTrabajdorPage = new MenuTrabajdorPage(); }
            setNavigationService(menuTrabajdorPage);
        }

        private void menu_reporte_tienda_Click(object sender, RoutedEventArgs e)
        {
            
            if (menuReporteTiendaPage == null) { menuReporteTiendaPage = new MenuReporteTiendaPage(); }
            setNavigationService(menuReporteTiendaPage);
        }

        private void menu_reporte_valoracion_Click(object sender, RoutedEventArgs e)
        {
            if (menuReporteValoracionPage == null) { menuReporteValoracionPage = new MenuReporteValoracionPage(); }
            setNavigationService(menuReporteValoracionPage);
        }

        private void menu_archivos_Click(object sender, RoutedEventArgs e)
        {
            if (menuBIPage == null) { menuBIPage = new MenuBIPage(); }
            setNavigationService(menuBIPage);
        }


        /** 
         * A partir de este punto todas las acciones realizadas con
         * respecto al menu de inicio son con fines de demostracion en 
         * proceso de desarrollo, estos posteriormente se comentaran
         * para su no uso 
         * **/

        ModificarProductoPage modificarProducto;
        private void menu_modificar_producto_Click(object sender, RoutedEventArgs e)
        {
            if (modificarProducto == null) { modificarProducto = new ModificarProductoPage(); }
            setNavigationService(modificarProducto);
        }
        ModificarOfertaPage modificarOfertaPage;
        private void menu_modificar_oferta_Click(object sender, RoutedEventArgs e)
        {
            if (modificarOfertaPage == null) { modificarOfertaPage = new ModificarOfertaPage(); }
            setNavigationService(modificarOfertaPage);
        }
        VerOfertaDetallePage verOfertaDetallePage;
        private void menu_detalle_oferta_Click(object sender, RoutedEventArgs e)
        {
            if (verOfertaDetallePage == null) { verOfertaDetallePage = new VerOfertaDetallePage(); }
            setNavigationService(verOfertaDetallePage);
        }
        ModificarEmpresaPage modificarEmpresaPage;
        private void menu_modificar_empresa_Click(object sender, RoutedEventArgs e)
        {
            if (modificarEmpresaPage == null) { modificarEmpresaPage = new ModificarEmpresaPage(); }
            setNavigationService(modificarEmpresaPage);
        }
        ModificarTrabajadorPage modificarTrabajadorPage;
        private void menu_modificar_trabajadores_Click(object sender, RoutedEventArgs e)
        {
            if (modificarTrabajadorPage == null) { modificarTrabajadorPage = new ModificarTrabajadorPage(); }
            setNavigationService(modificarTrabajadorPage);
        }
        ModificarLocalPage modificarLocalPage;
        private void menu_modificar_locales_Click(object sender, RoutedEventArgs e)
        {
            if (modificarLocalPage == null) { modificarLocalPage = new ModificarLocalPage(); }
            setNavigationService(modificarLocalPage);
        }
        VerDescuentoDetallePage verDescuentoDetallePage;
        private void menu_mostrar_descuento_Click(object sender, RoutedEventArgs e)
        {
            if (verDescuentoDetallePage == null) { verDescuentoDetallePage = new VerDescuentoDetallePage(); }
            setNavigationService(verDescuentoDetallePage);
        }
    }

}
