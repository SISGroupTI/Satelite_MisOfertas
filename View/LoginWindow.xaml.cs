using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using NegLibrary;
namespace View
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        TrabajadorNeg trabajadorNeg;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (trabajadorNeg == null)
            {
                trabajadorNeg = new TrabajadorNeg();
            }

            Boolean res = trabajadorNeg.validarCredenciales(txtUsuario.Text, txtContrasena.Password);
            if (res) { MessageBox.Show("Existe"); } else { MessageBox.Show("no existe"); }
        }
    }
}
