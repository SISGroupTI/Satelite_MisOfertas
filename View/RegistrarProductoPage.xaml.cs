using DAOLibrary;
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
    public partial class RegistrarProductoPage : Page
    {
        LocalNeg localNeg;
        ProductoNeg productoNeg;
        EstadoNeg estadoNeg;
        RubroNeg rubroNeg;
        List<Estado> estado = new List<Estado>();
        public RegistrarProductoPage()
        {
            InitializeComponent();
            if (localNeg == null) { localNeg = new LocalNeg(); }
            if (productoNeg == null) { productoNeg = new ProductoNeg(); }
            if (estadoNeg == null)
                estadoNeg = new EstadoNeg();
            if (rubroNeg == null)
                rubroNeg = new RubroNeg();
            camposProductos.cbxRubro.SelectionChanged += CbxRubro_SelectionChanged;
            cargarCbxLocal();
            cargarCboEstado();
            cargarCbxRubro();
        }

        private void CbxRubro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rubro rubro = (Rubro)(sender as ComboBox).SelectedItem;
            if (rubro.TipoRubro.IdTipoRubro==1)
            {
                camposProductos.dpFechaCaducidad.IsEnabled = true;
            }
            else
            {
                camposProductos.dpFechaCaducidad.IsEnabled = false;
            }
        }

        private void cargarCbxRubro()
        {
            List<Rubro> rubro = new List<Rubro>();
            rubro = rubroNeg.ListarRubro();
            camposProductos.cbxRubro.ItemsSource = rubro;
            camposProductos.cbxRubro.DisplayMemberPath = "DescripcionRubro";
            camposProductos.cbxRubro.SelectedValuePath = "IdRubro";
            camposProductos.cbxRubro.Items.Refresh();
            camposProductos.cbxRubro.SelectedIndex = 0;
        }

        private void cargarCboEstado()
        {
            List<Estado> estados = new List<Estado>();
            estados = estadoNeg.ListarEstado();
            camposProductos.cbxEstado.ItemsSource = estados;
            camposProductos.cbxEstado.DisplayMemberPath = "NombreEstado";
            camposProductos.cbxEstado.SelectedValuePath = "IdEstado";
            camposProductos.cbxEstado.Items.Refresh();
            camposProductos.cbxEstado.SelectedIndex = 0;
        }


        private void cargarCbxLocal()
        {
            List<Local> locales = new List<Local>();
            locales = localNeg.ListarLocales();
            camposProductos.spLocal.ItemsSource = locales;
            camposProductos.spLocal.DisplayMemberPath = "Direccion";
            camposProductos.spLocal.SelectedValuePath = "IdLocal";
            camposProductos.spLocal.Items.Refresh();
            camposProductos.spLocal.SelectedIndex = 0;

        }

        private void btnGuardarRegistro_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                Local local = (Local)camposProductos.spLocal.SelectedItem;
                Estado estado = (Estado)camposProductos.cbxEstado.SelectedItem;
                Rubro rubro = (Rubro)camposProductos.cbxRubro.SelectedItem;
                int codigo = int.Parse(camposProductos.txtCodigo.Text.ToString());
                String nombrePro = camposProductos.txtNombreProducto.Text.ToString();
                int precioNormal = int.Parse(camposProductos.txtPrecioNormal.Text.ToString());
                int precioOferta = int.Parse(camposProductos.txtPrecioOferta.Text.ToString());
                DateTime fecha = DateTime.Now;
                if (rubro.IdRubro == 2)
                {
                    fecha = DateTime.Parse(camposProductos.dpFechaCaducidad.Text.ToString());
                }
                if (productoNeg.RegistrarProducto(local,codigo,nombrePro,precioNormal,precioOferta,fecha,estado,rubro))
                {
                    camposProductos.txtCodigo.Text = "";
                    camposProductos.txtNombreProducto.Text = "";
                    camposProductos.txtPrecioNormal.Text = "";
                    camposProductos.txtPrecioOferta.Text = "";
                    camposProductos.cbxEstado.SelectedIndex = 0;
                    camposProductos.spLocal.SelectedIndex = 0;
                    camposProductos.cbxRubro.SelectedIndex = 0;

                    MessageBox.Show("Producto ingresado exitosamente al sistema", "Ingreso de registro - Producto");
                }
                else { MessageBox.Show("Se ha generado un inconveniente al momento de ingresar el registro\n Intente nuevamente", "Ingreso de registro - Producto"); }
            }
            else { MessageBox.Show("Para ingresar un registro Producto se necesario completar todos los campos requeridos", "Ingreso de registro - Producto"); }
        }

        private bool validarCampos()
        {
            if (camposProductos.txtCodigo.Text.Trim().Equals("")
                || camposProductos.txtNombreProducto.Text.Trim().Equals("")
                || camposProductos.txtPrecioNormal.Text.Trim().Equals("")
                || camposProductos.txtPrecioOferta.Text.Trim().Equals(""))
            {
                return false;
            }
            else { return true; }
        }
    }
}
