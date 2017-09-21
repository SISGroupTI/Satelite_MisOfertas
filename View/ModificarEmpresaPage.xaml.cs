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
    /// Lógica de interacción para ModificarEmpresaPage.xaml
    /// </summary>
    public partial class ModificarEmpresaPage : Page
    {
        LocalNeg localNeg;
        List<Local> locales = new List<Local>();
        public ModificarEmpresaPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
        }

        public void cargarDatosEmpresa(Empresa empresa)
        {
            String rut = empresa.RutEmpresa.ToString();
            String rutCompleto = rut +"-"+ Dv(rut);
            controlesEmpresa.txtRutEmpresa.Text = rutCompleto;
            controlesEmpresa.txtNombreEmpresa.Text = empresa.NombreEmpresa;
            controlesEmpresa.txtRutEmpresa.IsEnabled = false;
            cargarDataGrid(empresa);
        }

        private void cargarDataGrid(Empresa empresa)
        {
            locales = localNeg.ListarLocalesIdEmpresa(empresa);
            dtLocal.ItemsSource= locales.ToList();
            dtLocal.Items.Refresh();
        }

        public static string Dv(string r)
        {
            int suma = 0;
            for (int x = r.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(r[x]) ? r[x].ToString() : "0") * (((r.Length - (x + 1)) % 6) + 2);
            int numericDigito = (11 - suma % 11);
            string digito = numericDigito == 11 ? "0" : numericDigito == 10 ? "K" : numericDigito.ToString();
            return digito;
        }

        private void btnModificarEmpresa_Click(object sender, RoutedEventArgs e)
        {

        }
        int flag = 0;
        private void btnAñadirLocal_Click(object sender, RoutedEventArgs e)
        {
            if (!(controlesLocal.txtDireccionLocal.Text.ToString().Equals("") &&
                controlesLocal.txtNumeroLocal.Text.ToString().Equals("")))
            {
                if(flag==0)
                    localNeg.Locales = locales;

                String direccion = controlesLocal.txtDireccionLocal.Text.ToString();
                int numero = int.Parse(controlesLocal.txtNumeroLocal.Text.ToString());
                if (localNeg.GuardarLocalList(numero, direccion))
                {
                    controlesLocal.txtDireccionLocal.Text = "";
                    controlesLocal.txtNumeroLocal.Text = "";
                    //MessageBox.Show("Local Agregado");
                    btnModificarEmpresa.IsEnabled = true;
                    dtLocal.ItemsSource = localNeg.Locales.ToList();
                    //dtgLocales.AutoGenerateColumns = true;
                    dtLocal.Items.Refresh();

                }
                else { MessageBox.Show("Error interno"); }
            }
            else { MessageBox.Show("Ingrese los campos"); }
        }
    }
}
