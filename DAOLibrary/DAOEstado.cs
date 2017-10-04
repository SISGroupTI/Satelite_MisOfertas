using ConxionLibrary;
using EntityLibrary;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLibrary
{
    public class DAOEstado
    {
        Conexion cone;

        public DAOEstado()
        {
            if (cone == null)
                cone = new Conexion();
        }

        public List<Estado> ListarEstados()
        {
            List<Estado> estados = new List<Estado>();
            Estado estado;
            try
            {
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_SELECT_ESTADO";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    estado = new Estado();
                    estado.IdEstado = dr.GetInt32(0);
                    estado.NombreEstado = dr.GetString(1);
                    estados.Add(estado);

                }
                cone.Obtener().Close();
                return estados;
            }
            catch
            {
                return null;
            }
        }
    }
}
