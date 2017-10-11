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
using System.Windows.Forms;
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
        ProductoNeg productoNeg;
        public MenuProductoPage()
        {
            InitializeComponent();
            if (productoNeg == null)
                productoNeg = new ProductoNeg();
            cargarProductos();
        }

        private void cargarProductos()
        {
            List<Producto> productos = new List<Producto>();
            productos = productoNeg.listarProducto();
            dtProducto.ItemsSource = productos;
            dtProducto.Items.Refresh();
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            goToRegistrar();
        }

        private void goToRegistrar()
        {
            if (registrarProductoPage == null) { registrarProductoPage = new RegistrarProductoPage(); }
            NavigationService.Navigate(registrarProductoPage);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Esta seguro de eliminar este registro?", "Eliminar registro - Producto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Se reliza la misma accion de rescatar al item seleccionado del data grid y parcearlo a Local
                Producto producto = (Producto)dtProducto.SelectedItems[0];
                // Se procede a eliminar el local
                Boolean res = productoNeg.EliminarProducto(producto);
                if (res)
                {
                    System.Windows.MessageBox.Show("Producto eliminado exitosamente", "Eliminar registro - Producto");
                    cargarProductos();
                }
            }
            
        }

        private void btnGoEditar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)dtProducto.SelectedItems[0];
            ModificarProductoPage modificarProductoPage = new ModificarProductoPage();
            modificarProductoPage.cargarDatosProducto(producto);
            NavigationService.Navigate(modificarProductoPage);
        }
        

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            goToRegistrar();
        }
    }
}
