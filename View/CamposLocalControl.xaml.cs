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
    /// Lógica de interacción para CamposLocalControl.xaml
    /// </summary>
    public partial class CamposLocalControl : UserControl
    {
        public CamposLocalControl()
        {
            InitializeComponent();
        }

        private void txtNumeroLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) { 
                e.Handled = false;}
            else { 
                e.Handled = true;}
        }
    }
}
