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
    /// Lógica de interacción para RegistrarEmpresaPage.xaml
    /// </summary>
    public partial class RegistrarEmpresaPage : Page
    {
        LocalNeg localNeg;
        EmpresaNeg empresaNeg;
        public RegistrarEmpresaPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
            if (empresaNeg == null)
                empresaNeg = new EmpresaNeg();
        }

        private void btnGuardarLocal_Click(object sender, RoutedEventArgs e)
        {
            String direccion =controlesLocal.txtDireccionLocal.Text.ToString();
            int numero = int.Parse(controlesLocal.txtNumeroLocal.Text.ToString());
            if (localNeg.GuardarLocalList(numero, direccion))
            {
                controlesLocal.txtDireccionLocal.Text = "";
                controlesLocal.txtNumeroLocal.Text = "";
                //MessageBox.Show("Local Agregado");
                btnRegistrar.IsEnabled = true;
                var locales = localNeg.LocalesObject;
                dtgLocales.ItemsSource = locales.ToList();
                dtgLocales.AutoGenerateColumns = true;
                dtgLocales.Items.Refresh();
                
            }
            else { MessageBox.Show("Error interno"); }
        
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            String rutCompleto = controlesEmpresa.txtRutEmpresa.Text.ToUpper();
            String nombre;
            Boolean res= false;
            if (controlesEmpresa.txtRutEmpresa.Text.Length>=10 && controlesEmpresa.txtNombreEmpresa.Text.Length>=1)
            {
                try
                {
                    int rut = int.Parse(rutCompleto.Substring(0, 8));
                    char dv = char.Parse(rutCompleto.Substring(9, 1));
                    nombre = controlesEmpresa.txtNombreEmpresa.Text;
                    res = empresaNeg.RegistrarEmpresa(rut, dv, nombre, localNeg);
                    if (res)
                    {
                        MessageBox.Show("Registro Exitoso");
                        controlesEmpresa.txtNombreEmpresa.Text = "";
                        controlesEmpresa.txtRutEmpresa.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No se registro");
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los datos");
            }
        }
    }
}
