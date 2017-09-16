using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConxionLibrary
{//
    public class Conexion
    {
        String cadena = "Data Source=localhost;User ID=misofertas;Password=root";
        private static OracleConnection cone;

        public Conexion()
        {
            if (cone == null)
            {
                cone = new OracleConnection();
                cone.ConnectionString = cadena;
            }
        }

        public OracleConnection Obtener()
        {
            return cone;
        }

    }
}
