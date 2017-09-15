using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConxionLibrary
{
    public class Conexion
    {
        OracleConnection con;

        public Conexion()
        {
            if (con==null)
            {
                con = new OracleConnection();
            }
        }
        public OracleConnection Connect()
        {
            String dataSource = "(DESCRIPTION ="+
                                    "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP - LQ8HQGJ)(PORT = 1521))"+
                                        "(CONNECT_DATA ="+
                                            "(SERVER = DEDICATED)"+
                                             "(SERVICE_NAME = XE)"+
                                    ")"+
                                 ")";
            con.ConnectionString = "User Id=portafolio;Password=portafolio;Data Source="+dataSource;
            return con;
        }

        public void Close()
        {
            con.Close();
            con.Dispose();
        }

        public void Open()
        {
            con.Open();
        }
        
    }
}
