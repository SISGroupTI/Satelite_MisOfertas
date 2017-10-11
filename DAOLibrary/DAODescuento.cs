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
    public class DAODescuento
    {
        Conexion conexion;

        public DAODescuento()
        {
            if (conexion == null)
                conexion = new Conexion();
        }

        public List<Descuento> listarDescuentos()
        {

            try
            {
                Consumidor consumidor;
                Descuento descuento;
                List<Descuento> listaDescuentos = new List<Descuento>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_DESCUENTOS_MENU";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    descuento = new Descuento();
                    consumidor = new Consumidor();

                    descuento.IdDescuento = dr.GetInt32(0);
                    descuento.Puntos = dr.GetInt32(2);
                    descuento.Descuentos = dr.GetFloat(3);
                    descuento.Tope = dr.GetInt32(4);
                    descuento.FechaEmision = dr.GetDateTime(5);
                    descuento.Rubros = dr.GetString(1);
                    descuento.Condiciones = dr.GetString(14);
                    //DATOS CONSUMIDOR
                    consumidor.IdConsumidor = dr.GetInt32(8);
                    consumidor.Nombre = dr.GetString(9);
                    consumidor.Apellidos = dr.GetString(10);
                    consumidor.Correo = dr.GetString(11);
                    consumidor.Rut = dr.GetInt32(12);
                    descuento.Consumidor = consumidor;

                    listaDescuentos.Add(descuento);
                }
                conexion.Obtener().Close();
                return listaDescuentos;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }

            
        }

    }
}
