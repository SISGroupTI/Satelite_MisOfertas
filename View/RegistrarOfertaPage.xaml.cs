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
    /// Lógica de interacción para RegistrarOfertaPage.xaml
    /// </summary>
    public partial class RegistrarOfertaPage : Page
    {
        LocalNeg localNeg;
        ProductoNeg productoNeg;
        EstadoNeg estadoNeg;
        RubroNeg rubroNeg;
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
            cargarCbxs();
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
            //Rubro rubro = (Rubro)camposOfertas.cbxRubro.SelectionBoxItem;
            Rubro rubro = (Rubro)(sender as ComboBox).SelectedItem;
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
    }
}
