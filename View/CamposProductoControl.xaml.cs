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
    /// Lógica de interacción para CamposProductoControl.xaml
    /// </summary>
    public partial class CamposProductoControl : UserControl
    {
        public CamposProductoControl()
        {
            InitializeComponent();
        }

        private void txtPrecioNormal_KeyDown(object sender, KeyEventArgs e)
        {
            validarIngresosNumeros(sender,e);
        }

        private void validarIngresosNumeros(object sender, KeyEventArgs e)
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

        private void txtPrecioOferta_KeyDown(object sender, KeyEventArgs e)
        {
            validarIngresosNumeros(sender, e);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            validarIngresosNumeros(sender, e);
        }


    }
}
