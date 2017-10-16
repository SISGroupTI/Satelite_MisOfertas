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
    /// Lógica de interacción para CamposEmpresaControl.xaml
    /// </summary>
    public partial class CamposEmpresaControl : UserControl
    {
        Boolean camposLlenos = false;

        public bool CamposLlenos { get => camposLlenos; set => camposLlenos = value; }

        public CamposEmpresaControl()
        {
            InitializeComponent();
        }

        private void txtRutEmpresa_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtRutEmpresa.Text.Length==10)
            {
                CamposLlenos = true;
                String rut = txtRutEmpresa.Text;
                bool validacion = false;
                try
                {
                    rut = rut.ToUpper();
                    rut = rut.Replace(".", "");
                    rut = rut.Replace("-", "");
                    int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                    char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                    int m = 0, s = 1;
                    for (; rutAux != 0; rutAux /= 10)
                    {
                        s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                    }
                    if (dv == (char)(s != 0 ? s + 47 : 75))
                    {
                        validacion = true;
                    }
                }
                catch (Exception)
                {
                }
                if (!validacion)
                {
                    MessageBox.Show("El rut que has ingresado no es válido", "Validacion de RUT");
                    txtRutEmpresa.Clear();
                    CamposLlenos = false;
                }
            }
        }

        private void txtRutEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || 
                e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || 
                e.Key == Key.K || 
                e.Key==Key.Subtract || 
                e.Key==Key.OemQuotes)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        
    }
}
