using EntityLibrary;
using NegLibrary;
using System;
using System.Collections;

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
    /// Lógica de interacción para RegistrarProductoPage.xaml
    /// </summary>
    public partial class RegistrarProductoPage : Page
    {
        LocalNeg localNeg;
        ProductoNeg productoNeg;

        
        List<Estado> estado = new List<Estado>();
        public RegistrarProductoPage()
        {
            InitializeComponent();
            if (localNeg == null) { localNeg = new LocalNeg(); }
                
            if (productoNeg == null) { productoNeg = new ProductoNeg(); }
                


        }
        
        private void btnGuardarRegistro_Click(object sender, RoutedEventArgs e)
        {
            
            Local local = (Local)camposProductos.spLocal.SelectedItem;
            int codigo = int.Parse(camposProductos.txtCodigo.Text.ToString());
            String nombrePro = camposProductos.txtNombreProducto.Text.ToString();
            int precioNormal = int.Parse(camposProductos.txtPrecioNormal.Text.ToString());
            int precioOferta = int.Parse(camposProductos.txtPrecioOferta.Text.ToString());
            Estado estado = (Estado)camposProductos.spTipoProducto.SelectedItem;
            DateTime fecha = DateTime.Parse(camposProductos.dpFechaCaducidad.Text.ToString());

            
            if (productoNeg.RegistrarProducto(local, codigo, nombrePro, precioNormal, precioOferta, estado, fecha))
            {
                camposProductos.spLocal.SelectedItem = "";
                camposProductos.txtCodigo.Text = "";
                camposProductos.txtNombreProducto.Text = "";
                camposProductos.txtPrecioNormal.Text = "";
                camposProductos.txtPrecioOferta.Text = "";
                camposProductos.spTipoProducto.Text = "";
                camposProductos.dpFechaCaducidad.Text = "";
                /*
                //MessageBox.Show("Local Agregado");
                btnGuardarRegistro.IsEnabled = true;
                var locales = localNeg.LocalesObject;
                dtgLocales.ItemsSource = locales.ToList();
                dtgLocales.AutoGenerateColumns = true;
                dtgLocales.Items.Refresh(); */
                MessageBox.Show("Producto Guardado");
            }
            else { MessageBox.Show("Error No se regritro producto"); }

        }
    }
}
