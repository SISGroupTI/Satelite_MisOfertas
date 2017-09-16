using ConxionLibrary;
using EntityLibrary;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAOLibrary
{
    public class DAOTrabajador
    {
        private Conexion cone;
        DataSet dataSet = new DataSet();
        public DAOTrabajador()
        {
            cone = new Conexion();
        }

        public Boolean validarTrabajador(Trabajador trabajador)
        {
            String nombre_usuario = trabajador.NombreUsuario;
            String contrasena = trabajador.Contrasena;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SP_INICIO_SESION_TRABAJADOR";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("p_NOMBRE_USUARIO", OracleDbType.Varchar2).Value = nombre_usuario;
            cmd.Parameters.Add("p_CONTRASENA", OracleDbType.Varchar2).Value = contrasena;
            OracleParameter output = cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor);
            output.Direction = System.Data.ParameterDirection.Output;
            try
            {

                cmd.ExecuteNonQuery();
                OracleDataReader dr = ((OracleRefCursor)output.Value).GetDataReader();
                while (dr.Read())
                {
                    trabajador.Rut = dr.GetInt32(2);

                }
                cone.Obtener().Close();
                return true;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
            }
            cone.Obtener().Close();
            return false;
        }
    }
}
