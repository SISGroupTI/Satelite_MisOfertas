using Oracle.DataAccess.Client;
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

namespace View
{
    /// <summary>
    /// Lógica de interacción para TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection con = new OracleConnection();
            String dataSource = "(DESCRIPTION =" +
                                    "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP - LQ8HQGJ)(PORT = 1521))" +
                                        "(CONNECT_DATA =" +
                                            "(SERVER = DEDICATED)" +
                                             "(SERVICE_NAME = XE)" +
                                    ")" +
                                 ")";
            con.ConnectionString = "User Id=portafolio;Password=portafolio;Data Source=" + dataSource;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = ("select direccion from TBL_LOCAL where id_local=1");
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lblNombreLocal.Content = dr.GetString(3);

        }
    }
}
