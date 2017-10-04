using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
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
        }

        public void ObtenerOferta(Oferta oferta)
        {
            ofertaNeg.Oferta = oferta;
            cargarDtDetalle();
            cargarcbxLocal();
            caragrcbxEstado();
            cargarcbxRubro();
            cargarCampos();
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
            lblCantidad.Content = ofertaNeg.Oferta.Visitas;
            txbNumero.Text = ofertaNeg.Oferta.CodigoOferta.ToString();
        }
    }
}
