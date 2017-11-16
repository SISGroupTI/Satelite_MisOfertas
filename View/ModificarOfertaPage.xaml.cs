using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para ModificarOfertaPage.xaml
    /// </summary>
    public partial class ModificarOfertaPage : Page
    {
        Oferta ofer;
        DetalleOfertaNeg detalleOfertaNeg;
        LocalNeg localNeg;
        ProductoNeg productoNeg;
        EstadoNeg estadoNeg;
        RubroNeg rubroNeg;
        OfertaNeg ofertaNeg;

        


        ImagenesOfertaNeg imagenesOfertaNeg;
        List<object> listaImagenes; //----------LISTA CUSTOM PARA LA AGREGACION DE NUEVAS IMAGENES
        List<ImagenOferta> listaImagenesOferta;
        public ModificarOfertaPage()
        {
            InitializeComponent();
            if (detalleOfertaNeg == null)
                detalleOfertaNeg = new DetalleOfertaNeg();
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
            if (imagenesOfertaNeg == null)
                imagenesOfertaNeg = new ImagenesOfertaNeg();
            if (listaImagenes == null)
                listaImagenes = new List<object>();
            if (listaImagenesOferta == null)
                listaImagenesOferta = new List<ImagenOferta>();
            
        }
        private void cargarcbxRubro()
        {
            List<Rubro> rubros = new List<Rubro>();
            rubros = rubroNeg.ListarRubro();
            camposOfertas.cbxRubro.ItemsSource = rubros;
            camposOfertas.cbxRubro.DisplayMemberPath = "DescripcionRubro";
            camposOfertas.cbxRubro.SelectedValuePath = "IdRubro";
            camposOfertas.cbxRubro.Items.Refresh();
            camposOfertas.cbxRubro.SelectedValue = ofertaNeg.Oferta.Rubro.IdRubro;
            Rubro rubro = (Rubro)camposOfertas.cbxRubro.SelectionBoxItem;
            camposOfertas.cbxRubro.SelectionChanged += CbxRubro_SelectionChanged;
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
            camposOfertas.cbxEstado.SelectedValue = ofertaNeg.Oferta.Estado.IdEstado;
        }
        private void cargarcbxProducto(Rubro rubro)
        {
            List<Producto> productos = new List<Producto>();
            productos = productoNeg.ListarProductosPorRubro(rubro);
            cbxProductos.ItemsSource = productos;
            cbxProductos.DisplayMemberPath = "Descripcion";
            cbxProductos.SelectedValuePath = "IdProducto";
            cbxProductos.SelectedIndex = 0;
            cbxProductos.Items.Refresh();

        }
        private void cargarcbxLocal()
        {
            List<Local> locales = localNeg.ListarLocales(); //new List<Local>();
            //locales = localNeg.ListarLocales();
            camposOfertas.cbxLocal.ItemsSource = locales;
            camposOfertas.cbxLocal.DisplayMemberPath = "Direccion";
            camposOfertas.cbxLocal.SelectedValuePath = "IdLocal";
            camposOfertas.cbxLocal.Items.Refresh();
            camposOfertas.cbxLocal.SelectedValue = ofertaNeg.Oferta.Local.IdLocal;
            camposOfertas.cbxLocal.SelectedIndex = 0;
        }
        private void cargarDtDetalle()
        {
            dtDetalle.ItemsSource = detalleOfertaNeg.DetalleOfertasList;
            dtDetalle.Items.Refresh();
        }
        public void obtenerDatos(List<DetalleOferta> detalleList, Oferta oferta, List<ImagenOferta> listaImagenesOfertaIn)
        {
            detalleOfertaNeg.DetalleOfertasList = detalleList;
            listaImagenesOferta = listaImagenesOfertaIn;
            ofertaNeg.Oferta = oferta;
            cargarcbxLocal();
            caragrcbxEstado();
            cargarcbxRubro();
            cargarCampos();
            cargarDtDetalle();
            cargarImagenes();


        }
        public void cargarImagenes()
        {
            if (listaImagenesOferta.Count > 0)
            {
                
                foreach (ImagenOferta imagenOferta in listaImagenesOferta)
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.CacheOption = BitmapCacheOption.OnLoad;
                    b.UriSource = new Uri(imagenOferta.Imagen);
                    b.EndInit();
                    var imagen = new { Ruta = imagenOferta.Imagen, Imagen = b, Extension = System.IO.Path.GetExtension(imagenOferta.Imagen) }; //custom object
                    listaImagenes.Add(imagen);
                }
                cargarDtImagenesOferta();
            }
        }

        private void cargarCampos()
        {
            camposOfertas.txtCodigoOferta.Text = ofertaNeg.Oferta.CodigoOferta.ToString();
            camposOfertas.dpFechaPublicacion.SelectedDate = ofertaNeg.Oferta.FechaInicio;
            camposOfertas.dpFechaFinalizacion.SelectedDate = ofertaNeg.Oferta.FechaFinalizacion;
            camposOfertas.dpFechaFinalizacion.DisplayDateStart = ofertaNeg.Oferta.FechaFinalizacion;
            camposOfertas.dpFechaPublicacion.DisplayDateStart = ofertaNeg.Oferta.FechaInicio;
            camposOfertas.txtPrecio.Text = ofertaNeg.Oferta.Precio.ToString();
            txtTitulo.Text = ofertaNeg.Oferta.TituloOferta;
            txtDescripcion.Text = ofertaNeg.Oferta.DescripcionOferta;
            txtCondiciones.Text = ofertaNeg.Oferta.Condiciones;
            camposOfertas.cbxLocal.IsEnabled = false;
            camposOfertas.cbxRubro.IsEnabled = false;
            camposOfertas.txtCodigoOferta.IsEnabled = false;
            camposOfertas.cbxEstado.IsEnabled = false;
            rbSi.IsChecked = ofertaNeg.Oferta.IsDisponible==1 ? true : false;
            rbNo.IsChecked = ofertaNeg.Oferta.IsDisponible == 0 ? true : false;
            if ((bool)rbSi.IsChecked)
                rbNo.IsEnabled = false;
            if ((bool)rbNo.IsChecked)
                rbSi.IsEnabled = false;
        }
        private Boolean valdidarCampos()
        {
            if (camposOfertas.txtCodigoOferta.Text.Trim().Length < 1 ||
                txtTitulo.Text.Trim().Length < 1 ||
                txtCondiciones.Text.Trim().Length < 1 ||
                txtDescripcion.Text.Trim().Length < 1 ||
                camposOfertas.dpFechaFinalizacion.SelectedDate == null ||
                camposOfertas.dpFechaPublicacion.SelectedDate == null ||
                camposOfertas.txtPrecio.Text.Trim().Length < 1)
            {
                return false;
            }
            else { return true; }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validarDiponibilidad()) //validarDiponibilidad()
            { 
            
                System.Windows.Forms.MessageBox.Show("No es posible realizar modificaciones a este registro\n La oferta se encuentra en curso hasta: "+ofertaNeg.Oferta.FechaFinalizacion.ToShortDateString(), "Aviso de modificacion de ofertas");
            }
            else {
                if (camposOfertas.dpFechaFinalizacion.SelectedDate < ofertaNeg.Oferta.FechaFinalizacion) //camposOfertas.dpFechaFinalizacion.SelectedDate < ofertaNeg.Oferta.FechaFinalizacion
                {
                    System.Windows.Forms.MessageBox.Show("No se permite \n adelantar la finalizacion", "Modificar Oferta");
                }
                else
                {
                    if (listaImagenes.Count<=0)
                    {
                        System.Windows.Forms.MessageBox.Show("Se requiere una imagen como minimo para ser asociada a esta oferta", "Modificar Oferta");
                    }
                    else
                    {
                        String descripcion = txtDescripcion.Text.ToString();
                        String condiciones = txtCondiciones.Text.ToString();
                        Rubro rubro = (Rubro)camposOfertas.cbxRubro.SelectionBoxItem;
                        Local local = (Local)camposOfertas.cbxLocal.SelectionBoxItem;
                        Estado estado = (Estado)camposOfertas.cbxEstado.SelectionBoxItem;
                        DateTime fechaFinalizacion = (DateTime)camposOfertas.dpFechaFinalizacion.SelectedDate;
                        DateTime fechaPublicacion = (DateTime)camposOfertas.dpFechaPublicacion.SelectedDate;
                        String titulo = txtTitulo.Text.Trim();
                        int codigoOferta = int.Parse(camposOfertas.txtCodigoOferta.Text.Trim());
                        int precio = int.Parse(camposOfertas.txtPrecio.Text.Trim());
                        int isDisponible = rbSi.IsChecked == true ? 1 : 0;

                        Oferta ofertaOut = ofertaNeg.ModificarOferta(descripcion, condiciones,
                            rubro, local, estado, fechaFinalizacion, fechaPublicacion, titulo, codigoOferta, precio, isDisponible);
                        if (ofertaOut != null)
                        {
                            if (listaImagenes.Count > 0)
                            {
                                if (imagenesOfertaNeg.eliminarImagenesOfertaPorOferta(ofertaOut))
                                {
                                    dtImagenesOfertaModificar.ItemsSource = null;
                                    dtImagenesOfertaModificar.Items.Clear();
                                    dtImagenesOfertaModificar.Items.Refresh();

                                    String rutaDirectorioOferta = "D:/MisOfertas/Ofertas/Oferta_" + ofertaOut.IdOferta + "_" + ofertaOut.CodigoOferta;

                                    System.IO.DirectoryInfo directorioOferta = new DirectoryInfo(rutaDirectorioOferta);
                                    if (!Directory.Exists(rutaDirectorioOferta))
                                        Directory.CreateDirectory(rutaDirectorioOferta);
                                    foreach (FileInfo file in directorioOferta.GetFiles())
                                    {
                                        file.Delete();
                                    }

                                    List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                                    int contImagenes = 1;
                                    foreach (object imagenOferta in listaImagenes)
                                    {
                                        String extension = (String)imagenOferta.GetType().GetProperty("Extension").GetValue(imagenOferta, null);
                                        BitmapImage bitImagen = new BitmapImage();
                                        bitImagen.BeginInit();
                                        bitImagen.CacheOption = BitmapCacheOption.OnLoad;
                                        //(BitmapImage)imagenOferta.GetType().GetProperty("Imagen").GetValue(imagenOferta, null); 
                                        bitImagen.UriSource = new Uri((String)imagenOferta.GetType().GetProperty("Ruta").GetValue(imagenOferta, null));
                                        bitImagen.EndInit();


                                        Bitmap img = BitmapImage2Bitmap(bitImagen);
                                        String rutaImagenOferta = rutaDirectorioOferta + "/Img_" + contImagenes + extension;
                                        if (File.Exists(rutaImagenOferta))
                                            File.Delete(rutaImagenOferta);
                                        img.Save(rutaImagenOferta);
                                        int is_principal = (contImagenes == 1) ? 1 : 0;
                                        listaImagenesOferta.Add(new ImagenOferta(rutaImagenOferta, is_principal, ofertaOut));
                                        contImagenes += 1;
                                    }

                                    imagenesOfertaNeg.registrarImagenesOferta(listaImagenesOferta);
                                }
                            }
                            System.Windows.Forms.MessageBox.Show("Oferta modificada exitosamente", "Modificacion de registro - Ofertas");
                            cargarDtDetalle();
                            cargarDtImagenesOferta();
                        }
                        else { System.Windows.Forms.MessageBox.Show("Se ha generado un inconveniente al momento de modificar la oferta \n Intente nuevamente", "Modificacion de registro - Ofertas"); }
                    }
                    
                }
            }
        }

        private bool validarDiponibilidad()
        {
            if (ofertaNeg.Oferta.IsDisponible == 1)
            {
                return true;
            }
            else { return false; }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Está seguro de eliminar de la lista este producto?", "Eliminar registro asociado", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (validarDiponibilidad())
                {
                    
                    System.Windows.Forms.MessageBox.Show("No es posible eliminar este producto de la lista \n ya que, la oferta se encuentra en curso actualmente", "Eliminar registro asociado");

                }
                else
                {
                    DetalleOferta detalle = (DetalleOferta)dtDetalle.SelectedItems[0];
                    Boolean res = detalleOfertaNeg.EliminarDetalleList(detalle);
                    if (res)
                    {
                        detalleOfertaNeg.EliminarDetalle(detalle);
                        System.Windows.MessageBox.Show("Registro eliminado de la lista exitosamente", "Eliminar registro asociado");
                        cargarDtDetalle();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("se ha generado un enconveniente en la eliminacion del registro", "Eliminar registro asociado");
                    }
                }
                cargarDtDetalle();
            }
            else
            {

            }
        }

        private void btnAgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (validarCamposDetalle())
            {
                if (validarDiponibilidad())//validarDiponibilidad()
                {

                    System.Windows.Forms.MessageBox.Show("No es posible agregar nuevos productos a la lista actual \n La oferta se encuentra en curso actualmente", "Modificacion de registro asociado");

                }
                else
                {
                    Producto producto = (Producto)cbxProductos.SelectionBoxItem;
                    int minimo = int.Parse(txtCantidadMinima.Text.Trim().ToString());
                    int maximo = int.Parse(txtCantidadMaxima.Text.Trim().ToString());
                    Boolean res = detalleOfertaNeg.RegistrarDetalle(producto, minimo, maximo, ofertaNeg.Oferta);
                    if (res)
                    {
                        System.Windows.MessageBox.Show("Registro agregado exitosamente a la lista actual", "Modificacion de registro asociado");
                        txtCantidadMaxima.Text = "";
                        txtCantidadMinima.Text = "";
                        cargarDtDetalle();
                    }
                    else { System.Windows.MessageBox.Show("No se ha podido agregar exitosamente el registro a la lista actual \n Intente nuevamente", "Modificacion de registro asociado"); }
                }
                
            }
            else
            {
                System.Windows.MessageBox.Show("Para agregar un producto a la lista actual \n se requiere de completar todos los campos requeridos");
            }
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

        private void txtCantidadMinima_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validarIngresosNumeros(sender, e);
        }

        private void txtCantidadMaxima_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validarIngresosNumeros(sender, e);
        }

        //----------------METODO PARA ABRIR EL DIALOGO DE SELECCION DE ARCHIVOS------------------

        private void BtnAbrirFolderModificar_Click(object sender, RoutedEventArgs e)
        {
            if (validarDiponibilidad())
            {
                System.Windows.Forms.MessageBox.Show("No es posible agregar nuevas imagenes a la lista actual \n La oferta se encuentra en curso actualmente", "Modificacion de registro asociado");
            }
            else
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
                    var imagen = new { Ruta = openFile.FileName, Imagen = b, Extension = System.IO.Path.GetExtension(openFile.FileName) }; //custom object
                    listaImagenes.Add(imagen);
                    b.EndInit();
                }
               
                cargarDtImagenesOferta();
            }
            
        }
        public void cargarDtImagenesOferta()
        {
            dtImagenesOfertaModificar.ItemsSource = listaImagenes;
            dtImagenesOfertaModificar.Items.Refresh();
        }
        public void btnEliminarImagenOferta_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Está seguro de descartar esta imagen?", "Confirmar accion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                object imagenOferta = (object)dtImagenesOfertaModificar.SelectedItems[0];
                listaImagenes.Remove(imagenOferta);
                cargarDtImagenesOferta();
            }
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

        private void camposOfertas_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
