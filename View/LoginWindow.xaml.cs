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
using EntityLibrary;

namespace View
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        TrabajadorNeg trabajadorNeg;
        PrincipalWindow principalWindow;
        UserOptionControl userOptionControl;
        public LoginWindow()
        {
            InitializeComponent();
            txtUsuario.Text = "desarrollador";
            txtContrasena.Password = "root";
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (trabajadorNeg == null)
            {
                trabajadorNeg = new TrabajadorNeg();
            }
            if (principalWindow == null)
            {
                principalWindow = new PrincipalWindow();
            }
            if (userOptionControl==null)
            {
                userOptionControl = new UserOptionControl();
            }
            if (txtUsuario.Text.Trim().Length > 0 && txtContrasena.Password.Trim().Length > 0)
            {

                Trabajador trabajador = trabajadorNeg.validarCredenciales(txtUsuario.Text, txtContrasena.Password.Trim());

                if (trabajador != null)
                {
                    principalWindow.lblNombreUsuario.Content = txtUsuario.Text.Trim();
                    DateTime fechaActual = DateTime.Now;
                    principalWindow.lblTimer.Content = fechaActual.ToString("dd MMMM, yyyy");    
                    userOptionControl.dropNombreUsuario.Content = trabajador.Nombre+" "+trabajador.Apellidos;

                    switch (trabajador.Perfil.IdPerfil)
                    {
                        case 2:
                            principalWindow.menu_mantenedores.Visibility = Visibility.Collapsed;
                            principalWindow.menu_inicio.Visibility = Visibility.Collapsed;
                            principalWindow.ver_oferta.Visibility = Visibility.Collapsed;
                            principalWindow.ver_descuento.Visibility = Visibility.Collapsed;
                            principalWindow.menu_reporte_valoracion.Visibility = Visibility.Collapsed;
                            principalWindow.menu_archivos.Visibility = Visibility.Collapsed;
                            MenuReporteTiendaPage menuReporteTiendaPage = new MenuReporteTiendaPage();
                            principalWindow.setNavigationService(menuReporteTiendaPage);
                            principalWindow.Show();
                            this.Close();
                            break;
                        case 3:
                            principalWindow.menu_inicio.Visibility = Visibility.Collapsed;
                            principalWindow.ver_oferta.Visibility = Visibility.Collapsed;
                            //principalWindow.ver_descuento.Visibility = Visibility.Collapsed;
                            principalWindow.menu_reportes.Visibility = Visibility.Collapsed;
                            MenuBIPage menuBIPage = new MenuBIPage();
                            principalWindow.setNavigationService(menuBIPage);
                            principalWindow.Show();
                            this.Close();
                            break;
                        case 4:
                            PrincipalPage principalPage = new PrincipalPage();
                            principalWindow.menu_empresa.Visibility = Visibility.Collapsed;
                            principalWindow.menu_local.Visibility = Visibility.Collapsed;
                            principalWindow.menu_trabajor.Visibility = Visibility.Collapsed;
                            principalWindow.menu_reporte_tienda.Visibility = Visibility.Collapsed;
                            principalWindow.menu_reportes.Visibility = Visibility.Collapsed;
                            principalWindow.ver_descuento.Visibility = Visibility.Collapsed;
                            principalWindow.menu_archivos.Visibility = Visibility.Collapsed;
                            principalWindow.separador1.Visibility = Visibility.Collapsed;
                            principalWindow.separador2.Visibility = Visibility.Collapsed;
                            principalWindow.setNavigationService(principalPage);
                            principalWindow.Show();
                            this.Close();
                            break;
                        case 1:
                            PrincipalPage principal = new PrincipalPage();
                            principalWindow.setNavigationService(principal);
                            principalWindow.Show();
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Credenciales invalidas", "Login - Mis Ofertas");
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Credenciales invalidas", "Login - Mis Ofertas");
                }
                
            }
            else { MessageBox.Show("Complete los campos solicitados", "Login - Mis Ofertas"); }
            
        }
    }
}
