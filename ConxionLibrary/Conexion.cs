using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConxionLibrary
{//
    public class Conexion
    {
        private static OracleConnection con;

        public Conexion()
        {
            if (con==null)
            {
                con = new OracleConnection();
            }
        }
        public static OracleConnection Connect()
        {
            String dataSource = "(DESCRIPTION ="+
                                    "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))"+
                                        "(CONNECT_DATA ="+
                                            "(SERVER = DEDICATED)"+
                                             "(SERVICE_NAME = XE)"+
                                    ")"+
                                 ")";
            /**String dataSource = "(DESCRIPTION =" +
                                    "(ADDRESS = (PROTOCOL = TCP)(HOST = LAPTOP-2AFLT0V8)(PORT = 1521))" +
                                        "(CONNECT_DATA =" +
                                            "(SERVER = DEDICATED)" +
                                             "(SERVICE_NAME = XE)" +
                                    ")" +
                                 ")";*/
            con.ConnectionString = "User Id=misofertas;Password=root;Data Source="+dataSource;
            return con;
        }

        public static void Close()
        {
            con.Close();
            con.Dispose();
        }

        public static void Open()
        {
            con.Open();
        }
        
    }
}
