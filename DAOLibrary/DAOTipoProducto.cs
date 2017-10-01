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
    public class DAOTipoProducto
    {
        Conexion cone;
        public DAOTipoProducto()
        {
            if (cone == null)
                cone = new Conexion();
        }

        public List<TipoProducto> ListarTipoProductos()
        {
            try
            {
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_SELECT_TIPO_PRODUCTO";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                
                TipoProducto tipo;
                List<TipoProducto> tipoProductos = new List<TipoProducto>();
                while (dr.Read())
                {
                    tipo = new TipoProducto();
                    tipo.IdTipoProducto = dr.GetInt32(0);
                    tipo.Descripcion = dr.GetString(1);
                    tipoProductos.Add(tipo);

                }
                cone.Obtener().Close();
                return tipoProductos;
            }
            catch
            {
                return null;
            }
        }
    }
}
