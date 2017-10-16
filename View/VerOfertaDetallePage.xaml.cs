using EntityLibrary;
using LiveCharts;
using LiveCharts.Wpf;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Lógica de interacción para VerOfertaDetallePage.xaml
    /// </summary>
    public partial class VerOfertaDetallePage : Page
    {
        OfertaNeg ofertaNeg;
        LocalNeg localNeg;
        ProductoNeg productoNeg;
        EstadoNeg estadoNeg;
        RubroNeg rubroNeg;
        DetalleOfertaNeg detalleOfertaNeg;

        ImagenesOfertaNeg imagenesOfertaNeg;
        List<object> listaImagenes; //----------LISTA CUSTOM PARA LA AGREGACION DE NUEVAS IMAGENES
        List<ImagenOferta> listaImagenesOferta;
        ValoracionOfertaNeg valoracionOfertaNeg;
        ValoracionOferta valoracionOferta;
        public VerOfertaDetallePage()
        {
            InitializeComponent();
            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            if (localNeg == null)
                localNeg = new LocalNeg();
            if (productoNeg == null)
                productoNeg = new ProductoNeg();
            if (estadoNeg == null)
                estadoNeg = new EstadoNeg();
            if (rubroNeg == null)
                rubroNeg = new RubroNeg();
            if (detalleOfertaNeg == null)
                detalleOfertaNeg = new DetalleOfertaNeg();
            if (imagenesOfertaNeg == null)
                imagenesOfertaNeg = new ImagenesOfertaNeg();
            if (listaImagenes == null)
                listaImagenes = new List<object>();
            if (listaImagenesOferta == null)
                listaImagenesOferta = new List<ImagenOferta>();
            if (valoracionOfertaNeg == null)
                valoracionOfertaNeg = new ValoracionOfertaNeg();
            
        }

        public void ObtenerOferta(Oferta oferta, List<ImagenOferta> listaImagenesIn, ValoracionOferta valoracionOfertaIn)
        {
            ofertaNeg.Oferta = oferta;
            listaImagenesOferta = listaImagenesIn;
            valoracionOferta = valoracionOfertaIn;
            cargarDtDetalle();
            cargarcbxLocal();
            caragrcbxEstado();
            cargarcbxRubro();
            cargarCampos();
            cargarImagenes();
            
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
            camposOfertas.cbxRubro.IsEnabled = false;
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
            camposOfertas.cbxEstado.IsEnabled = false;

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
            camposOfertas.cbxLocal.IsEnabled = false;

        }
        private void cargarDtDetalle()
        {
            dtDetalle.ItemsSource = detalleOfertaNeg.BuscarDetalleOferta(ofertaNeg.Oferta);
            dtDetalle.Items.Refresh();
            dtDetalle.IsEnabled = false;
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
            camposOfertas.txtPrecio.IsEnabled = false;
            camposOfertas.txtPrecio.IsEnabled = false;
            txbNumero.Text = ofertaNeg.Oferta.CodigoOferta.ToString();
            lblCantidad.Content = (valoracionOferta.CantTotalValoraciones.ToString() == null)? valoracionOferta.CantTotalValoraciones.ToString(): "0" ;

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

        public void cargarDtImagenesOferta()
        {
            dtVerImagenesOferta.ItemsSource = listaImagenes;
            dtVerImagenesOferta.Items.Refresh();
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

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //ValoracionOferta valoracionOferta = valoracionOfertaNeg.listarCantValoracionesPorOferta(ofertaNeg.Oferta.IdOferta);
                if (valoracionOferta != null)
                {
                    SeriesCollection = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Valoraciones",
                            Values = new ChartValues<double> {valoracionOferta.CantValoracionesNegativas, valoracionOferta.CantValoracionMedias, valoracionOferta.CantValoracionesPositivas }
                        }
                    };
                    //SeriesCollection[0].Values.Add(valoracionOferta.CantValoracionMedias);
                    //SeriesCollection[0].Values.Add(valoracionOferta.CantValoracionesPositivas);
                    Labels = new[] { "Negativas", "Medias", "Positivas"};
                    Formatter = value => value.ToString("N");
                    DataContext = this;
                }
            }
            catch (Exception exception)
            {

            }
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }

    
}
