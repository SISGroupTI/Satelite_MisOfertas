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
using System.Windows.Forms;
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
        Empresa empresa;
        EmpresaNeg empresaNeg;
        public ModificarEmpresaPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
            if (empresaNeg == null)
                empresaNeg = new EmpresaNeg();
            InicializarEvents();
        }
        //Inicializa los eventos de los textbox
        private void InicializarEvents()
        {
            controlesLocal.txtDireccionLocal.TextChanged += TxtDireccionLocal_TextChanged;
            controlesLocal.txtNumeroLocal.TextChanged += TxtNumeroLocal_TextChanged;
        }
        /*
         * Se setea un evento para el control del usuario el cual capta
         * los cambios en el textBox
         * */
        private void TxtNumeroLocal_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Se valida si ingreso un caracter en el textbox txtNumeroLocal sacandole los espacios y midiendo el largo
            if (controlesLocal.txtNumeroLocal.Text.Trim().Length < 1) { btnAñadirLocal.IsEnabled = false; }
            else { btnAñadirLocal.IsEnabled = true; }
        }
        /*
         * Se setea un evento para el control del usuario el cual capta
         * los cambios en el textBox
         * */
        private void TxtDireccionLocal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controlesLocal.txtDireccionLocal.Text.Trim().Length < 1) { btnAñadirLocal.IsEnabled = false; }
            else { btnAñadirLocal.IsEnabled = true; }
        }

        public void cargarDatosEmpresa(Empresa empresa)
        {
            this.empresa = empresa;
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
        // Metodo para devolver el digito verificador a partir de un rut
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
            if (resLocal)
            {
                System.Windows.MessageBox.Show("Empresa Modificada", "Modificar Empresa");
                if (resLocal)
                {
                    cargarDataGridLocales(empresa);
                }
            }
        }
        private void btnAñadirLocal_Click(object sender, RoutedEventArgs e)
        {
            if (!(controlesLocal.txtDireccionLocal.Text.ToString().Equals("") &&
                controlesLocal.txtNumeroLocal.Text.ToString().Equals("")))
            {

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Confirmar accion", "Añadir Local", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Local local = new Local();
                    local.NumeroLocal = int.Parse(controlesLocal.txtNumeroLocal.Text);
                    local.Direccion = controlesLocal.txtDireccionLocal.Text;
                    Boolean res = localNeg.RegistrarLocal(local,empresa);
                    if (res)
                    {
                        controlesLocal.txtNumeroLocal.Text = "";
                        controlesLocal.txtDireccionLocal.Text="";
                        System.Windows.MessageBox.Show("Local Ingresada", "Ingresar Local");
                        cargarDataGridLocales(empresa);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else { System.Windows.MessageBox.Show("Ingrese los campos"); }
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
                System.Windows.MessageBox.Show("Para confirma presione\nModificar Empresa");
                dtLocal.ItemsSource = listaAux;
                dtLocal.Items.Refresh();
            }
            else { System.Windows.MessageBox.Show("No sepudo Eliminar"); }
        }
    }
}
