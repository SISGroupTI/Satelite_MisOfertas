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
        String nombreEmpresa="";
        int idEmpresa;
        EmpresaNeg empresaNeg;
        public ModificarEmpresaPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
            if (empresaNeg == null)
                empresaNeg = new EmpresaNeg();
        }

        public void cargarDatosEmpresa(Empresa empresa)
        {
            idEmpresa = empresa.IdEmpresa;
            String rut = empresa.RutEmpresa.ToString();
            String rutCompleto = rut +"-"+ Dv(rut);
            controlesEmpresa.txtRutEmpresa.Text = rutCompleto;
            controlesEmpresa.txtNombreEmpresa.Text = empresa.NombreEmpresa;
            nombreEmpresa = empresa.NombreEmpresa;
            controlesEmpresa.txtRutEmpresa.IsEnabled = false;
            cargarDataGridLocales(empresa);
        }

        private void cargarDataGridLocales(Empresa empresa)
        {
            locales = localNeg.ListarLocalesIdEmpresa(empresa);
            localNeg.Locales = locales;
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
            Boolean resEmpresa = false;
            Boolean resLocal = false;
            Empresa empresa;
            String rutCompleto = controlesEmpresa.txtRutEmpresa.Text.ToUpper();
            int rut = int.Parse(rutCompleto.Substring(0, 8));
            char dv = char.Parse(rutCompleto.Substring(9, 1));
            String nombre = controlesEmpresa.txtNombreEmpresa.Text;
            int id = idEmpresa;
            empresa = new Empresa();
            empresa.RutEmpresa = rut;
            empresa.DvEmpresa = dv;
            empresa.NombreEmpresa = nombre;
            empresa.IdEmpresa = id;
            //Primero se modifica la empresa
            //Si se modifico em campo nombre empresa se actualiza si no no
            if (!(nombreEmpresa.Equals(controlesEmpresa.txtNombreEmpresa.Text)))
            {
                resEmpresa = empresaNeg.ModificarEmpresa(rut,dv,nombre,idEmpresa);
            }
            resLocal= localNeg.EliminarLocales();
            if (resEmpresa)
            {
                MessageBox.Show("Empresa Modificada", "Modificar Empresa");
                if (resLocal)
                {
                    cargarDataGridLocales(empresa);
                }
            }
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Local local = (Local)dtLocal.SelectedItems[0];
            List<Local> listaAux = new List<Local>();
            Boolean res;
            res = localNeg.EliminarLocalList(local);
            if (res)
            {
                foreach (Local loc in localNeg.Locales)
                {
                    if (loc.IsActivo!=0)
                    {
                        listaAux.Add(loc);
                    }
                }
                MessageBox.Show("Para confirma presione\n Modificar Empresa");
                dtLocal.ItemsSource = listaAux;
                dtLocal.Items.Refresh();
            }
            else { MessageBox.Show("No sepudo Eliminar"); }
        }
    }
}
