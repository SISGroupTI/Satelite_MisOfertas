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
    /// Lógica de interacción para ModificarProductoPage.xaml
    /// </summary>
    public partial class ModificarProductoPage : Page
    {
        Producto producto;
        LocalNeg localNeg;
        ProductoNeg productoNeg;
        EstadoNeg estadoNeg;
        RubroNeg rubroNeg;
        public ModificarProductoPage()
        {
            InitializeComponent();
            if (producto == null)
                producto = new Producto();
            if (localNeg == null) { localNeg = new LocalNeg(); }
            if (productoNeg == null) { productoNeg = new ProductoNeg(); }
            if (estadoNeg == null)
                estadoNeg = new EstadoNeg();
            if (rubroNeg == null)
                rubroNeg = new RubroNeg();
            controlesProducto.cbxRubro.SelectionChanged += CbxRubro_SelectionChanged;
        }

        private void CbxRubro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rubro rubro = (Rubro)(sender as ComboBox).SelectedItem;
            if (rubro.TipoRubro.IdTipoRubro == 1)
            {
                controlesProducto.dpFechaCaducidad.IsEnabled = true;
            }
            else
            {
                controlesProducto.dpFechaCaducidad.IsEnabled = false;
            }
        }

        public void cargarDatosProducto(Producto producto)
        {
            this.producto = producto;
            cargarCbxLocal();
            cargarCboEstado();
            cargarCbxRubro();
            cargarCampos();
        }
        private void cargarCbxRubro()
        {
            List<Rubro> rubro = new List<Rubro>();
            rubro = rubroNeg.ListarRubro();
            controlesProducto.cbxRubro.ItemsSource = rubro;
            controlesProducto.cbxRubro.DisplayMemberPath = "DescripcionRubro";
            controlesProducto.cbxRubro.SelectedValuePath = "IdRubro";
            controlesProducto.cbxRubro.Items.Refresh();
            controlesProducto.cbxRubro.SelectedIndex = 0;
            controlesProducto.cbxRubro.SelectedValue = this.producto.Rubro.IdRubro;

        }
        private void cargarCampos()
        {
            controlesProducto.txtCodigo.Text = this.producto.CodigoProducto.ToString();
            controlesProducto.txtNombreProducto.Text = this.producto.Descripcion;
            controlesProducto.txtPrecioNormal.Text = this.producto.PrecioNormal.ToString();
            controlesProducto.txtPrecioOferta.Text = this.producto.PrecioOferta.ToString();
            controlesProducto.dpFechaCaducidad.SelectedDate = this.producto.FechaCaducidad;
        }

        private void cargarCboEstado()
        {
            List<Estado> estados = new List<Estado>();
            estados = estadoNeg.ListarEstado();
            controlesProducto.cbxEstado.ItemsSource = estados;
            controlesProducto.cbxEstado.DisplayMemberPath = "NombreEstado";
            controlesProducto.cbxEstado.SelectedValuePath = "IdEstado";
            controlesProducto.cbxEstado.Items.Refresh();
            controlesProducto.cbxEstado.SelectedValue=this.producto.Estado.IdEstado;
        }
        

        private void cargarCbxLocal()
        {
            List<Local> locales = new List<Local>();
            locales = localNeg.ListarLocales();
            controlesProducto.spLocal.ItemsSource = locales;
            controlesProducto.spLocal.DisplayMemberPath = "Direccion";
            controlesProducto.spLocal.SelectedValuePath = "IdLocal";
            controlesProducto.spLocal.Items.Refresh();
            controlesProducto.spLocal.SelectedValue = this.producto.Local.IdLocal;

        }

        private void btnGuardarRegistro_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                Local local = (Local)controlesProducto.spLocal.SelectedItem;
                Estado estado = (Estado)controlesProducto.cbxEstado.SelectedItem;
                int codigo = int.Parse(controlesProducto.txtCodigo.Text.ToString());
                String nombrePro = controlesProducto.txtNombreProducto.Text.ToString();
                int precioNormal = int.Parse(controlesProducto.txtPrecioNormal.Text.ToString());
                int precioOferta = int.Parse(controlesProducto.txtPrecioOferta.Text.ToString());
                Rubro rubro = (Rubro)controlesProducto.cbxRubro.SelectedItem;
                DateTime fecha = DateTime.Now;
                if (rubro.IdRubro == 2)
                {
                    fecha = DateTime.Parse(controlesProducto.dpFechaCaducidad.Text.ToString());
                }

                int idProducto = this.producto.IdProducto;
                if (productoNeg.ModificarProducto(local, codigo, nombrePro, precioNormal, precioOferta, fecha, estado,idProducto,rubro))
                {
                    controlesProducto.txtCodigo.Text = "";
                    controlesProducto.txtNombreProducto.Text = "";
                    controlesProducto.txtPrecioNormal.Text = "";
                    controlesProducto.txtPrecioOferta.Text = "";
                    controlesProducto.cbxEstado.SelectedIndex = 0;
                    controlesProducto.cbxRubro.SelectedIndex = 0;

                    controlesProducto.spLocal.SelectedIndex = 0;
                    controlesProducto.dpFechaCaducidad.IsEnabled = true;


                    MessageBox.Show("Producto Modificado","Modificar producto");
                }
                else { MessageBox.Show("No se modifico producto","Modificar Producto"); }

            }
            else { MessageBox.Show("Todos los campos son requeridos", "Modificar Producto"); }
        }

        private bool ValidarCampos()
        {
                if (controlesProducto.txtCodigo.Text.ToString().Trim().Equals("") ||
                    controlesProducto.txtNombreProducto.Text.ToString().Trim().Equals("") ||
                    controlesProducto.txtPrecioNormal.Text.ToString().Trim().Equals("") ||
                    controlesProducto.txtPrecioOferta.Text.ToString().Trim().Equals("") )
                    //controlesProducto.dpFechaCaducidad.SelectedDate!=null)
                {
                    return false;
                }
                else { return true; }
        }
    }
}
