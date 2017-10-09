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
            List<Local> locales = new List<Local>();
            locales = localNeg.ListarLocales();
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
            cargarDtDetalle();
            cargarcbxLocal();
            caragrcbxEstado();
            cargarcbxRubro();
            cargarCampos();
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
            if (txtCantidadMaxima.Text.Trim().Length < 1 ||
                txtCantidadMinima.Text.Trim().Length < 1)
            {
                return false;
            }
            else { return true; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validarDiponibilidad()) {
                System.Windows.Forms.MessageBox.Show("Oferta en curso", "Modificar Oferta");
            }
            else {
                if (camposOfertas.dpFechaFinalizacion.SelectedDate < ofertaNeg.Oferta.FechaFinalizacion)
                {
                    System.Windows.Forms.MessageBox.Show("No se permite \n adelantar la finalizacion", "Modificar Oferta");
                }
                else
                {
                    string descripcion = txtDescripcion.Text.ToString();
                    string condiciones = txtCondiciones.Text.ToString();
                    Rubro rubro = (Rubro)camposOfertas.cbxRubro.SelectionBoxItem;
                    Local local = (Local)camposOfertas.cbxLocal.SelectionBoxItem;
                    Estado estado = (Estado)camposOfertas.cbxEstado.SelectionBoxItem;
                    DateTime fechaFinalizacion = (DateTime)camposOfertas.dpFechaFinalizacion.SelectedDate;
                    DateTime fechaPublicacion = (DateTime)camposOfertas.dpFechaPublicacion.SelectedDate;
                    String titulo = txtTitulo.Text.Trim();
                    int codigoOferta = int.Parse(camposOfertas.txtCodigoOferta.Text.Trim());
                    int precio = int.Parse(camposOfertas.txtPrecio.Text.Trim());
                    int isDisponible = rbSi.IsChecked == true ? 1 : 0;
                    bool res = ofertaNeg.ModificarOferta(descripcion, condiciones,
                        rubro, local, estado, fechaFinalizacion, fechaPublicacion, titulo, codigoOferta, precio, isDisponible);
                    if (res)
                    {
                        System.Windows.Forms.MessageBox.Show("Oferta Modificada", "Modificar Oferta");
                        
                        cargarDtDetalle();
                    }
                    else { System.Windows.Forms.MessageBox.Show("No se modifico", "Modificar Oferta"); }
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
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Confirmar accion", "Eliminar Oferta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (validarDiponibilidad())
                {
                    
                    System.Windows.Forms.MessageBox.Show("Oferta en curso", "Modificar Oferta");

                }
                else
                {
                    DetalleOferta detalle = (DetalleOferta)dtDetalle.SelectedItems[0];
                    Boolean res = detalleOfertaNeg.EliminarDetalle(detalle);
                    if (res)
                    {
                        System.Windows.MessageBox.Show("Detalle Eliminado", "Eliminar Detalle");
                        cargarDtDetalle();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Detalle No Se Elimino", "Eliminar Detalle");
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
                if (validarDiponibilidad())
                {

                    System.Windows.Forms.MessageBox.Show("Oferta en curso", "Modificar Oferta");

                }
                else
                {
                    Producto producto = (Producto)cbxProductos.SelectionBoxItem;
                    int minimo = int.Parse(txtCantidadMinima.Text.Trim().ToString());
                    int maximo = int.Parse(txtCantidadMaxima.Text.Trim().ToString());
                    Boolean res = detalleOfertaNeg.RegistrarDetalle(producto, minimo, maximo, ofertaNeg.Oferta);
                    if (res)
                    {
                        System.Windows.MessageBox.Show("Agregado Correctamente");
                        txtCantidadMaxima.Text = "";
                        txtCantidadMinima.Text = "";
                        cargarDtDetalle();
                    }
                    else { System.Windows.MessageBox.Show("No se agrego"); }
                }
                
            }
            else
            {
                System.Windows.MessageBox.Show("Ingrese todos los campos");
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

    }
}
