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
            con.ConnectionString = "User Id=<username>;Password=<password>;Data Source=<datasource>";
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
