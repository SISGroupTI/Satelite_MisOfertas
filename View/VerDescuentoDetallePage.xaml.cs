using EntityLibrary;
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
    /// Lógica de interacción para VerDescuentoDetallePage.xaml
    /// </summary>
   

    public partial class VerDescuentoDetallePage : Page
    {

        Descuento descuento;
        Consumidor consumidor;
        public VerDescuentoDetallePage()
        {
            InitializeComponent();
            if (descuento == null)
                descuento = new Descuento();
            if (consumidor == null)
                consumidor = new Consumidor();
            
        }

        public void obtenerDatosDescuento(Descuento descuentoIn)
        {
            descuento = descuentoIn;
            setDatosDescuento();
            bloquearElementosConsumidor();
        }

        public void setDatosDescuento()
        {
            camposConsumidor.txtCorreo.Text = descuento.Consumidor.Correo;
            camposConsumidor.txtNombre.Text = descuento.Consumidor.Nombre + " " + descuento.Consumidor.Apellidos;
            camposConsumidor.txtRut.Text = descuento.Consumidor.Rut.ToString();

            camposDescuento.txtTope.Text = descuento.Tope.ToString();
            camposDescuento.txtDescuento.Text = descuento.Descuentos.ToString();
            camposDescuento.txtPuntos.Text = descuento.Puntos.ToString();
            camposDescuento.txtRubros.Text = descuento.Rubros.ToString();
            camposDescuento.dpFechaEmision.SelectedDate = descuento.FechaEmision;
            camposDescuento.dpFechaEmision.DisplayDateStart = descuento.FechaEmision;
            txbNumero.Text = descuento.IdDescuento.ToString();


            FlowDocument document = new FlowDocument();
            document.Blocks.Add(new Paragraph(new Run(descuento.Condiciones)));
            camposDescuento.rtbCondiciones.Document = document;
        }

        private void CamposConsumidorControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void camposDescuento_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void bloquearElementosConsumidor()
        {
            camposConsumidor.txtRut.IsEnabled = false;
            camposConsumidor.txtNombre.IsEnabled = false;
            camposConsumidor.txtCorreo.IsEnabled = false;
        }
    }
}
