using EntityLibrary;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para RegistrarLocalPage.xaml
    /// </summary>
    public partial class RegistrarLocalPage : Page
    {
        EmpresaNeg empresaNeg;
        LocalNeg localNeg;
        public RegistrarLocalPage()
        {
            InitializeComponent();
            if(empresaNeg==null)
                empresaNeg = new EmpresaNeg();
            if (localNeg == null)
                localNeg = new LocalNeg();
            cargarEmpresas();
        }
        

        private void cargarEmpresas()
        {
            cbxEmpresa.ItemsSource = empresaNeg.ListarEmpresas();
            cbxEmpresa.DisplayMemberPath = "NombreEmpresa";
            cbxEmpresa.SelectedValuePath = "IdEmpresa";
            cbxEmpresa.SelectedIndex = 0;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            /***/
            if (!(cbxEmpresa.SelectedIndex == -1))
            {
                if (!(controlesLocal.txtNumeroLocal.Text.Equals("") && controlesLocal.txtDireccionLocal.Text.Equals("")))
                {
                    int numeroLocal = int.Parse(controlesLocal.txtNumeroLocal.Text);
                    String direccionLocal = controlesLocal.txtDireccionLocal.Text;
                    Local local = new Local();
                    local.Direccion = direccionLocal;
                    local.NumeroLocal = numeroLocal;
                    Empresa empresa = (Empresa)cbxEmpresa.SelectionBoxItem;
                    Boolean res=localNeg.RegistrarLocal(local,empresa);
                    if (res)
                    {
                        MessageBox.Show("Local ingresado exitosamente al sistema", "Ingreso de registro - Local");
                        cbxEmpresa.SelectedIndex = -1;
                        controlesLocal.txtDireccionLocal.Text = "";
                        controlesLocal.txtNumeroLocal.Text = "";

                    }
                    else { MessageBox.Show("Se ha generado un inconveniento al momento de ingresar este registro\n Intente nuevamente", "Ingreso de registro - Local"); }
                    //MessageBox.Show("" + empresa.IdEmpresa);

                }
                else
                {
                    MessageBox.Show("Para un ingresar un registro local, es necesario completar todos los campos requeridos", "Ingreso de registro - Local");
                }

            }
            else { MessageBox.Show("Para ingresar un registro Local, es necesario seleccionar la empresa objetivo", "Ingreso de registro - Local"); }
        }
        
    }
}
