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
    /// Lógica de interacción para RegistrarOfertaPage.xaml
    /// </summary>
    public partial class RegistrarOfertaPage : Page
    {
        LocalNeg localNeg;
        ProductoNeg productoNeg;
        EstadoNeg estadoNeg;
        RubroNeg rubroNeg;
        OfertaNeg ofertaNeg;
        DetalleOfertaNeg detalleOfertaNeg;
        public RegistrarOfertaPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
            if (productoNeg == null)
                productoNeg = new ProductoNeg();
            if (estadoNeg == null)
                estadoNeg = new EstadoNeg();
            if (rubroNeg == null)
                rubroNeg = new RubroNeg();
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            if (detalleOfertaNeg == null)
                detalleOfertaNeg = new DetalleOfertaNeg();
            cargarCbxs();
            setDatePickers();
        }

        private void setDatePickers()
        {
            camposOfertas.dpFechaFinalizacion.SelectedDate = DateTime.Now.AddDays(1);
            camposOfertas.dpFechaFinalizacion.DisplayDateStart = DateTime.Now;
            camposOfertas.dpFechaPublicacion.DisplayDateStart = DateTime.Now;
            camposOfertas.dpFechaPublicacion.SelectedDate = DateTime.Now;
            rbSi.IsChecked = true;
            rbNo.IsEnabled = false;
            camposOfertas.dpFechaPublicacion.SelectedDateChanged += DpFechaPublicacion_SelectedDateChanged;
        }

        private void DpFechaPublicacion_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime publicacion = (DateTime)camposOfertas.dpFechaPublicacion.SelectedDate;
            camposOfertas.dpFechaFinalizacion.SelectedDate = publicacion.AddDays(1);
            camposOfertas.dpFechaFinalizacion.DisplayDateStart = publicacion;

            if (camposOfertas.dpFechaPublicacion.SelectedDate == DateTime.Now.Date)
            {
                rbSi.IsEnabled = true;
                rbSi.IsChecked = true;
                rbNo.IsChecked = false;
                rbNo.IsEnabled = false;
            }
            else
            {
                rbSi.IsEnabled = false;
                rbSi.IsChecked = false;
                rbNo.IsChecked = true;
                rbNo.IsEnabled = true;
            }
        }

        private void cargarCbxs()
        {
            cargarcbxLocal();
            caragrcbxEstado();
            cargarcbxRubro();
        }

        private void cargarcbxRubro()
        {
            List<Rubro> rubros = new List<Rubro>();
            rubros = rubroNeg.ListarRubro();
            camposOfertas.cbxRubro.ItemsSource = rubros;
            camposOfertas.cbxRubro.DisplayMemberPath = "DescripcionRubro";
            camposOfertas.cbxRubro.SelectedValuePath = "IdRubro";
            camposOfertas.cbxRubro.Items.Refresh();
            camposOfertas.cbxRubro.SelectedIndex = 0;
            camposOfertas.cbxRubro.SelectionChanged += CbxRubro_SelectionChanged;
            Rubro rubro = (Rubro)camposOfertas.cbxRubro.SelectionBoxItem;
            cargarcbxProducto(rubro);
        }


        private void CbxRubro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rubro rubro = (Rubro)(sender as System.Windows.Controls.ComboBox).SelectedItem;
            cargarcbxProducto(rubro);
        }

        private void caragrcbxEstado()
        {
            List<Estado> estados = new List<Estado>();
            estados = estadoNeg.ListarEstado();
            camposOfertas.cbxEstado.ItemsSource = estados;
            camposOfertas.cbxEstado.DisplayMemberPath = "NombreEstado";
            camposOfertas.cbxEstado.SelectedValuePath = "IdEstado";
            camposOfertas.cbxEstado.Items.Refresh();
            camposOfertas.cbxEstado.SelectedIndex = 0;
        }

        private void cargarcbxProducto(Rubro rubro)
        {
            List<Producto> productos = new List<Producto>();
            productos = productoNeg.ListarProductosPorRubro(rubro);
            cbxProductos.ItemsSource = productos;
            cbxProductos.DisplayMemberPath = "Descripcion";
            cbxProductos.SelectedValuePath = "IdProducto";
            cbxProductos.Items.Refresh();
            cbxProductos.SelectedIndex = 0;
        }

        private void cargarcbxLocal()
        {
            List<Local> locales = new List<Local>();
            locales = localNeg.ListarLocales();
            camposOfertas.cbxLocal.ItemsSource = locales;
            camposOfertas.cbxLocal.DisplayMemberPath = "Direccion";
            camposOfertas.cbxLocal.SelectedValuePath = "IdLocal";
            camposOfertas.cbxLocal.Items.Refresh();
            camposOfertas.cbxLocal.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                try
                {
                    string descripcion = tbxDescripcion.Text.ToString();
                    string condiciones = tbxCondiciones.Text.ToString();
                    Rubro rubro = (Rubro)camposOfertas.cbxRubro.SelectionBoxItem;
                    Local local = (Local)camposOfertas.cbxLocal.SelectionBoxItem;
                    Estado estado = (Estado)camposOfertas.cbxEstado.SelectionBoxItem;
                    DateTime fechaFinalizacion = (DateTime)camposOfertas.dpFechaFinalizacion.SelectedDate;
                    DateTime fechaPublicacion = (DateTime)camposOfertas.dpFechaPublicacion.SelectedDate;
                    String titulo = tbxTitulo.Text.Trim();
                    int codigoOferta = int.Parse(camposOfertas.txtCodigoOferta.Text.Trim());
                    int precio = int.Parse(camposOfertas.txtPrecio.Text.Trim());
                    int isVisible = 1;
                    int isDisponible = rbSi.IsChecked == true ? 1 : 0;
                    bool res = ofertaNeg.RegistrarOferta(descripcion, condiciones,
                        rubro, local, estado, fechaFinalizacion, fechaPublicacion, titulo, codigoOferta, precio,
                        isVisible, isDisponible);
                    if (res)
                    {
                        Oferta oferta = ofertaNeg.BuscarOferta(descripcion, condiciones,
                        rubro, local, estado, fechaFinalizacion, fechaPublicacion, titulo, codigoOferta, precio,
                        isVisible, isDisponible);
                        if (oferta != null)
                        {
                            detalleOfertaNeg.AsignarOfertaADetalles(oferta);
                            res = detalleOfertaNeg.RegistrarDetalle(detalleOfertaNeg.DetalleOfertasList);
                            if (res) {
                                tbxDescripcion.Text="";
                                tbxCondiciones.Text="";
                                camposOfertas.cbxRubro.SelectedIndex=0;
                                camposOfertas.cbxLocal.SelectedIndex = 0;
                                camposOfertas.cbxEstado.SelectedIndex = 0;
                                setDatePickers();
                                tbxTitulo.Text="";
                                cbxProductos.SelectedIndex = 0;
                                txtCantidadMaxima.Text = "";
                                txtCantidadMinima.Text = "";
                                System.Windows.MessageBox.Show("Registro Exitoso", "Registro de Oferta");
                            } 
                        }
                        
                    }
                }
                catch (Exception ex) { System.Windows.MessageBox.Show("Error: " + ex.Message, "Registro de Oferta"); }
            }
            else
            {
                System.Windows.MessageBox.Show("Ingrese todos los campos");
            }
        }

        private bool validarCampos()
        {
            
            if (camposOfertas.txtCodigoOferta.Text.Trim().Length<1 ||
                tbxTitulo.Text.Trim().Length<1 ||
                tbxCondiciones.Text.Trim().Length<1 ||
                tbxDescripcion.Text.Trim().Length<1 ||
                camposOfertas.dpFechaFinalizacion.SelectedDate==null ||
                camposOfertas.dpFechaPublicacion.SelectedDate==null ||
                camposOfertas.txtPrecio.Text.Trim().Length<1)
            {
                return false;
            }
            else { return true; }
        }

        private void btnAgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (validarCamposDetalle())
            {
                Producto producto = (Producto)cbxProductos.SelectionBoxItem;
                int minimo = int.Parse(txtCantidadMinima.Text.Trim().ToString());
                int maximo = int.Parse(txtCantidadMaxima.Text.Trim().ToString());
                Boolean res = detalleOfertaNeg.AgregarDetalleList(producto, minimo, maximo);
                if (res)
                {
                    System.Windows.MessageBox.Show("Agregado Correctamente");
                    cargarDataGridDetalle();
                }
                else { System.Windows.MessageBox.Show("No se agrego"); }
            }
            else
            {
                System.Windows.MessageBox.Show("Ingrese todos los campos");
            }
        }

        private void cargarDataGridDetalle()
        {
            dtDetalle.ItemsSource = detalleOfertaNeg.DetalleOfertasList;
            dtDetalle.Items.Refresh();
        }

        private bool validarCamposDetalle()
        {
            if (txtCantidadMaxima.Text.Trim().Length < 1 ||
                txtCantidadMinima.Text.Trim().Length < 1)
            {
                return false;
            }
            else { return true; }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Confirmar accion", "Eliminar Detalle", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Se reliza la misma accion de rescatar al item seleccionado del data grid y parcearlo a Local
                DetalleOferta detalle = (DetalleOferta)dtDetalle.SelectedItems[0];
                // Se procede a eliminar el local
                Boolean res = detalleOfertaNeg.EliminarDetalleList(detalle);
                if (res)
                {
                    System.Windows.MessageBox.Show("Detalle Eliminado", "Eliminar Detalle");
                    cargarDataGridDetalle();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void txtCantidadMinima_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validarIngresosNumeros(sender, e);
        }

        private void txtCantidadMaxima_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validarIngresosNumeros(sender, e);
        }
        private void validarIngresosNumeros(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnAbrirFolfer_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            openFile.InitialDirectory = @"C:\Users\%USERPROFILE%\Pictures";
            BitmapImage b = new BitmapImage();
            openFile.Title = "Seleccione Imagen";
            openFile.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                b.BeginInit();
                b.UriSource = new Uri(openFile.FileName);
                b.EndInit();
                imgPrincipal.Stretch = Stretch.Fill;
                imgPrincipal.Source = b;
            }
        }
    }
}
