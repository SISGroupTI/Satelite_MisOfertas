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
    /// Lógica de interacción para MenuLocalPage.xaml
    /// </summary>
    public partial class MenuLocalPage : Page
    {
        RegistrarLocalPage registrarLocalPage;
        LocalNeg localNeg;
        public MenuLocalPage()
        {
            InitializeComponent();
            if (localNeg == null)
                localNeg = new LocalNeg();
            cargarDataGridLocal();
        }

        private void cargarDataGridLocal()
        {
            dtLocal.ItemsSource = localNeg.ListarLocales();
            dtLocal.Items.Refresh();
        }

        private void btnAgregarLocal_Click(object sender, RoutedEventArgs e)
        {
            if (registrarLocalPage == null) { registrarLocalPage = new RegistrarLocalPage(); }
            NavigationService.Navigate(registrarLocalPage);
        }
    }
}
