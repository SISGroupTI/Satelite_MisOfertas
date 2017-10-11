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
    /// Lógica de interacción para ModificarTrabajadorPage.xaml
    /// </summary>
    public partial class ModificarTrabajadorPage : Page
    {
        Trabajador trabajador=new Trabajador();
        TrabajadorNeg trabNeg;
        PerfilNeg perfilNeg;
        LocalNeg localNeg;
        List<Perfil> perfiles= new List<Perfil>();
        List<Local> locales = new List<Local>();
        public ModificarTrabajadorPage()
        {
            InitializeComponent();
            if (trabNeg == null)
                trabNeg = new TrabajadorNeg();
            if (perfilNeg == null)
                perfilNeg = new PerfilNeg();
            if (localNeg == null)
                localNeg = new LocalNeg();
            CargarLocales();
            CargarPerfiles();
        }
        private void CargarPerfiles()
        {
            perfiles = perfilNeg.ListarPerfiles();
            camposTrabajador.cbxPerfil.ItemsSource = perfiles;
            camposTrabajador.cbxPerfil.DisplayMemberPath = "NombrePerfil";
            camposTrabajador.cbxPerfil.SelectedValuePath = "IdPerfil";
        }

        private void CargarLocales()
        {
            locales= localNeg.ListarLocales();
            camposTrabajador.cbxLocal.ItemsSource = locales;
            camposTrabajador.cbxLocal.DisplayMemberPath = "Direccion";
            camposTrabajador.cbxLocal.SelectedValuePath = "IdLocal";
        }
        private void obtenerTrabajador(Trabajador trabajador)
        {
            this.trabajador = trabajador;
            cargarDatosTrabajador(trabajador);
        }

        public void cargarDatosTrabajador(Trabajador trabajador)
        {
            camposTrabajador.txtRut.Text = trabajador.Rut+"-"+Dv(trabajador.Rut.ToString());
            camposTrabajador.txtApellidos.Text = trabajador.Apellidos;
            camposTrabajador.txtContrasena.Password = trabajador.Contrasena;
            camposTrabajador.txtCorreo.Text = trabajador.CorreoCorporativo;
            camposTrabajador.txtNombre.Text = trabajador.Nombre;
            camposTrabajador.txtNombreUsuario.Text = trabajador.NombreUsuario;
            camposTrabajador.etIdTrabajador.Text = trabajador.IdTrabajador.ToString();
            SeleccionarComboBox(trabajador);
        }

        private void SeleccionarComboBox(Trabajador trabajador)
        {
            camposTrabajador.cbxPerfil.SelectedValue= trabajador.Perfil.IdPerfil;
            camposTrabajador.cbxLocal.SelectedValue = trabajador.Local.IdLocal;

        }

        private void btnModificarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CamposNull())
                {
                    MessageBox.Show("Para modificar un registro Producto es necesario de completar todos los campos requeridos", "Modificacion de registro - Trabajador");
                }
                else
                {
                    String rutCompleto = camposTrabajador.txtRut.Text.ToUpper();
                    Local local = (Local)camposTrabajador.cbxLocal.SelectionBoxItem;
                    Perfil perfil = (Perfil)camposTrabajador.cbxPerfil.SelectionBoxItem;
                    Trabajador trabajador = new Trabajador();
                    trabajador.Apellidos = camposTrabajador.txtApellidos.Text;
                    if (!camposTrabajador.txtContrasena.Password.Equals(""))
                    {
                        trabajador.Contrasena = camposTrabajador.txtContrasena.Password;
                    }
                    else { trabajador.Contrasena = this.trabajador.Contrasena; }
                    trabajador.CorreoCorporativo = camposTrabajador.txtCorreo.Text;
                    int rut = int.Parse(rutCompleto.Substring(0, 8));
                    char dv = char.Parse(rutCompleto.Substring(9, 1));
                    trabajador.Dv = dv.ToString();
                    trabajador.Rut = rut;
                    trabajador.Nombre = camposTrabajador.txtNombre.Text;
                    trabajador.NombreUsuario = camposTrabajador.txtNombreUsuario.Text;
                    long idTrabajador= long.Parse(camposTrabajador.etIdTrabajador.Text);
                    trabajador.IdTrabajador = idTrabajador;
                    Boolean res = trabNeg.ModificarTrabajador(local, perfil, trabajador);
                    if (res)
                    {
                        camposTrabajador.txtRut.Text = "";
                        camposTrabajador.cbxLocal.SelectedIndex = 0;
                        camposTrabajador.cbxPerfil.SelectedIndex = 0;
                        camposTrabajador.txtApellidos.Text = "";
                        camposTrabajador.txtContrasena.Password = "";
                        camposTrabajador.txtCorreo.Text = "";
                        camposTrabajador.txtNombre.Text = "";
                        camposTrabajador.txtNombreUsuario.Text = "";
                        MessageBox.Show("Modificacion realizada exitosamente", "Modificacion de registro - Trabajador");
                    }
                    else { MessageBox.Show("Se ha generado un inconveniente al momento de modificar el registro\n Intente nuevamente", "Modificacion de registro - Trabajador"); }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Se ha generado un inconveniente al momento de modificar el registro\n Intente nuevamente", "Modificacion Personal");
            }
        }
        private bool CamposNull()
        {
            if (camposTrabajador.txtApellidos.Equals("")
                || camposTrabajador.txtContrasena.Equals("")
                || camposTrabajador.txtCorreo.Equals("")
                || camposTrabajador.txtNombre.Equals("")
                || camposTrabajador.txtNombreUsuario.Equals("")
                || camposTrabajador.txtRut.Equals(""))
            {
                return true;
            }
            return false;
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
    }
}
