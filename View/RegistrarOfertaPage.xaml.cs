using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        ImagenesOfertaNeg imagenesOfertaNeg;
        List<object> listaImagenes;
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
            if (imagenesOfertaNeg == null)
                imagenesOfertaNeg = new ImagenesOfertaNeg();
            if (listaImagenes == null)
                listaImagenes = new List<object>();
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

        private void btnGenerarOferta_Click(object sender, RoutedEventArgs e)
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
                    Oferta ofertaOut = ofertaNeg.RegistrarOferta(descripcion, condiciones,
                        rubro, local, estado, fechaFinalizacion, fechaPublicacion, titulo, codigoOferta, precio,
                        isVisible, isDisponible);


                    if (ofertaOut != null)
                    {      
                        detalleOfertaNeg.AsignarOfertaADetalles(ofertaOut);
                        Boolean res = detalleOfertaNeg.RegistrarDetalle(detalleOfertaNeg.DetalleOfertasList);

                        String rutaDirectorioOferta = "D:/MisOfertas/Ofertas/Oferta_" + ofertaOut.IdOferta +"_"+ofertaOut.CodigoOferta;
                        List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                        if (!Directory.Exists(rutaDirectorioOferta))
                            Directory.CreateDirectory(rutaDirectorioOferta);
                        int contImagenes = 1;
                        foreach (object imagenOferta in listaImagenes)
                        {
                            String extension = (String)imagenOferta.GetType().GetProperty("Extension").GetValue(imagenOferta,null);
                            BitmapImage bitImagen = (BitmapImage)imagenOferta.GetType().GetProperty("Imagen").GetValue(imagenOferta, null);
                            Bitmap img = BitmapImage2Bitmap(bitImagen);
                            String rutaImagenOferta = rutaDirectorioOferta + "/Img_" + contImagenes + extension;
                            img.Save(rutaImagenOferta);
                            int is_principal = (contImagenes == 1) ? 1 : 0;
                            listaImagenesOferta.Add(new ImagenOferta(rutaImagenOferta, is_principal, ofertaOut));
                            contImagenes += 1;
                        }


                        Boolean resImagenes = imagenesOfertaNeg.registrarImagenesOferta(listaImagenesOferta);


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
                catch (Exception ex) { System.Windows.MessageBox.Show("Error: " + ex.Message, "Registro de Oferta"); }
            }
            else
            {
                System.Windows.MessageBox.Show("Para crear una oferta se requiere ingresar todos los datos requeridos","Mensaje de aviso");
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
                    
                    System.Windows.MessageBox.Show("Producto agregado exitosamente", "Producto agregado");
                    txtCantidadMinima.Text = "";
                    txtCantidadMaxima.Text = "";
                    cargarDataGridDetalle();

                    List<Producto> productos = new List<Producto>();
                    productos = productoNeg.ListarProductosPorRubro((Rubro)camposOfertas.cbxRubro.SelectionBoxItem);
                    productos.Remove((Producto)cbxProductos.SelectionBoxItem);
                    cbxProductos.ItemsSource = productos;
                    cbxProductos.DisplayMemberPath = "Descripcion";
                    cbxProductos.SelectedValuePath = "IdProducto";
                    cbxProductos.Items.Refresh();
                    cbxProductos.SelectedIndex = 0;

                }
                else { System.Windows.MessageBox.Show("Se ha presentado un inconveniente \n favor de reingresar los productos a la lista","Alerta!"); }
            }
            else
            {
                System.Windows.MessageBox.Show("Verifique los campos", "Alerta!");
            }
        }

        private void cargarDataGridDetalle()
        {
            dtDetalle.ItemsSource = detalleOfertaNeg.DetalleOfertasList;
            dtDetalle.Items.Refresh();
        }

        private bool validarCamposDetalle()
        {
            if (txtCantidadMaxima.Text.Trim().Length < 1 || txtCantidadMinima.Text.Trim().Length < 1)
            {
                return false;
            }
            else {
                if (Int32.Parse(txtCantidadMinima.Text.ToString()) >= Int32.Parse(txtCantidadMaxima.Text.ToString()) )
                {
                    return false;
                }
                return true;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Está seguro de eliminar este registro de la lista?", "Confirmar acción", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Se reliza la misma accion de rescatar al item seleccionado del data grid y parcearlo a Local
                DetalleOferta detalle = (DetalleOferta)dtDetalle.SelectedItems[0];
                // Se procede a eliminar el local
                Boolean res = detalleOfertaNeg.EliminarDetalleList(detalle);
                if (res)
                {
                    System.Windows.MessageBox.Show("Se ha eliminado de la lista el registro seleccionado", "Registro eliminado");
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
            openFile.Filter = "Imagenes |*.jpeg; *.jpg; *.gif; *.png; *.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                b.BeginInit();
                b.UriSource = new Uri(openFile.FileName);
                b.EndInit();
                var imagen = new { Ruta = openFile.FileName, Imagen = b, Extension = System.IO.Path.GetExtension(openFile.FileName) }; //custom object
                listaImagenes.Add(imagen);
            }
            cargarDtImagenesOferta();


        }
        public void btnEliminarImagenOferta_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Está seguro de descartar esta imagen?", "Confirmar accion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                object imagenOferta = (object)dtImagenesOferta.SelectedItems[0];
                listaImagenes.Remove(imagenOferta);
                cargarDtImagenesOferta();
            }
        }

        public void cargarDtImagenesOferta()
        {
            dtImagenesOferta.ItemsSource = listaImagenes;
            dtImagenesOferta.Items.Refresh();
        }
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }



    }
}
