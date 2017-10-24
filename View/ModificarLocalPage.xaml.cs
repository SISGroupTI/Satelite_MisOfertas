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
    /// Lógica de interacción para ModificarLocalPage.xaml
    /// </summary>
    public partial class ModificarLocalPage : Page
    {
        EmpresaNeg empresaNeg;
        LocalNeg localNeg;
        String direccionAntigua;
        String numeroAntiguo;
        private Local local;

        public ModificarLocalPage()
        {
            InitializeComponent();
            if (empresaNeg == null)
                empresaNeg = new EmpresaNeg();
            if (localNeg == null)
                localNeg = new LocalNeg();
            
        }
        
        public void cargarComboBoxEmpresa(Local local)
        {
            cbxEmpresa.IsEnabled = false;
            btnActualizar.IsEnabled = false;
            List<Empresa> empresas = new List<Empresa>();
            empresas.Add(local.Empresa);
            cbxEmpresa.ItemsSource = empresas;
            cbxEmpresa.DisplayMemberPath = "NombreEmpresa";
            cbxEmpresa.SelectedValuePath = "IdEmpresa";
            cbxEmpresa.SelectedIndex = 0;
            cargarDatosLocal(local);
            
        }

        private void cargarDatosLocal(Local local)
        {
            this.local = local;
            controlesLocal.txtNumeroLocal.Text = local.NumeroLocal.ToString();
            numeroAntiguo = local.NumeroLocal.ToString();
            controlesLocal.txtDireccionLocal.Text = local.Direccion;
            direccionAntigua = local.Direccion;
            controlesLocal.txtDireccionLocal.TextChanged += TxtDireccionLocal_TextChanged;
            controlesLocal.txtNumeroLocal.TextChanged += TxtNumeroLocal_TextChanged;
        }

        private void TxtNumeroLocal_TextChanged(object sender, TextChangedEventArgs e)
        {
            String numeroActual = controlesLocal.txtNumeroLocal.Text;
            if (numeroActual.Equals(numeroAntiguo)) { btnActualizar.IsEnabled = false; }
            else { btnActualizar.IsEnabled = true; }
        }

        private void TxtDireccionLocal_TextChanged(object sender, TextChangedEventArgs e)
        {
            String direccionActual = controlesLocal.txtDireccionLocal.Text;
            if (direccionActual.Equals(direccionAntigua)) { btnActualizar.IsEnabled = false; }
            else { btnActualizar.IsEnabled = true; }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            int numeroLocal = int.Parse(controlesLocal.txtNumeroLocal.Text);
            String direccionLocal = controlesLocal.txtDireccionLocal.Text;
            local.Direccion = direccionLocal;
            local.NumeroLocal = numeroLocal;
            Boolean res = localNeg.ModificarLocal(local);
            if (res)
            {
                cargarComboBoxEmpresa(local);
                MessageBox.Show("Local modificado exitosamente", "Modificar registro - Local");
            }
            else
            {
                MessageBox.Show("Se ha generado un inconveniente al momento de modificar este registro \n Intente nuevamente", "Modificar registro - Local");
            }
        }
    }
}
