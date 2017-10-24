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
using NegLibrary;
using EntityLibrary;

namespace View
{
    /// <summary>
    /// Lógica de interacción para RegistrarTrabajadorPage.xaml
    /// </summary>
    public partial class RegistrarTrabajadorPage : Page
    {
        TrabajadorNeg trabNeg;
        PerfilNeg perfilNeg;
        LocalNeg localNeg;
        public RegistrarTrabajadorPage()
        {
            InitializeComponent();
            if (trabNeg == null)
                trabNeg = new TrabajadorNeg();
            if (perfilNeg == null)
                perfilNeg = new PerfilNeg();
            if (localNeg == null)
                localNeg = new LocalNeg();
            cargarConboBox();
        }

        private void cargarConboBox()
        {
            CargarPerfiles();
            CargarLocales();
        }

        private void CargarLocales()
        {
            camposTrabajador.cbxPerfil.ItemsSource = perfilNeg.ListarPerfiles();
            camposTrabajador.cbxPerfil.DisplayMemberPath = "NombrePerfil";
            camposTrabajador.cbxPerfil.SelectedValuePath = "IdPerfil";
            camposTrabajador.cbxPerfil.SelectedIndex = 0;
        }

        private void CargarPerfiles()
        {
            camposTrabajador.cbxLocal.ItemsSource = localNeg.ListarLocales();
            camposTrabajador.cbxLocal.DisplayMemberPath = "Direccion";
            camposTrabajador.cbxLocal.SelectedValuePath = "IdLocal";
            camposTrabajador.cbxLocal.SelectedIndex = 0;
        }

        private void btnAgregarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (CamposNull())
                {
                    MessageBox.Show("Para ingresar un nuevo registro Trabajador, es necesario de completar todos los campos requeridos", "Ingreso de registro - Trabajador");
                }
                else
                {
                    String rutCompleto = camposTrabajador.txtRut.Text.ToUpper();
                    Local local = (Local)camposTrabajador.cbxLocal.SelectionBoxItem;
                    Perfil perfil = (Perfil)camposTrabajador.cbxPerfil.SelectionBoxItem;
                    Trabajador trabajador = new Trabajador();
                    trabajador.Apellidos = camposTrabajador.txtApellidos.Text;
                    trabajador.Contrasena = camposTrabajador.txtContrasena.Password;
                    trabajador.CorreoCorporativo = camposTrabajador.txtCorreo.Text;
                    int rut = int.Parse(rutCompleto.Substring(0, 8));
                    char dv = char.Parse(rutCompleto.Substring(9, 1));
                    trabajador.Dv = dv.ToString();
                    trabajador.Rut = rut;
                    trabajador.Nombre = camposTrabajador.txtNombre.Text;
                    trabajador.NombreUsuario = camposTrabajador.txtNombreUsuario.Text;
                    Boolean res = trabNeg.RegistrarTrabajador(local, perfil, trabajador);
                    if (res)
                    {
                        camposTrabajador.txtRut.Text="";
                        camposTrabajador.cbxLocal.SelectedIndex=0;
                        camposTrabajador.cbxPerfil.SelectedIndex = 0;
                        camposTrabajador.txtApellidos.Text="";
                        camposTrabajador.txtContrasena.Password="";
                        camposTrabajador.txtCorreo.Text="";
                        camposTrabajador.txtNombre.Text="";
                        camposTrabajador.txtNombreUsuario.Text="";
                        MessageBox.Show("Registro ingresado exitosamente al sistema", "Ingreso de registro - Trabajador");
                    }
                    else { MessageBox.Show("Se ha generado un inconveniente al momento de ingresar el registro\n Intente nuevamente", "Ingreso de registro - Trabajador"); }
                }
            }
            catch
            {
                MessageBox.Show("Se ha generado un inconveniente al momento de ingresar el registro\n Intente nuevamente", "Ingreso de registro - Trabajador");
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
    }
}
