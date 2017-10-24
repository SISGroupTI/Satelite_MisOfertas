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
    public class DAODetalleOferta
    {
        Conexion cone;
        public DAODetalleOferta()
        {
            if (cone == null)
                cone = new Conexion();
        }

        public Boolean RegistrarDetalleOferta(List<DetalleOferta> detalles)
        {
            try
            {
                foreach (DetalleOferta detalle in detalles)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cone.Obtener();
                    cmd.CommandText = "SP_REGISTRAR_DETALLE_OFERTA";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int16).Value = detalle.Oferta.IdOferta;
                    cmd.Parameters.Add("p_ID_PRODUCTO", OracleDbType.Int16).Value = detalle.Producto.IdProducto;
                    cmd.Parameters.Add("p_CANTIDAD_MAXIMA", OracleDbType.Int16).Value = detalle.CantidadMaxima;
                    cmd.Parameters.Add("p_CANTIDAD_MINIMA", OracleDbType.Int16).Value = detalle.CantidadMinima;
                    if (cone.Obtener().State == ConnectionState.Closed)
                    {

                        cone.Obtener().Open();
                    }
                    cmd.ExecuteNonQuery();
                    cone.Obtener().Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return false;
            }
        }

        public List<DetalleOferta> BuscarDetalleOferta(Oferta oferta)
        {
            try
            {
                List<DetalleOferta> detalleList = new List<DetalleOferta>();
                int idOferta = oferta.IdOferta;
                DetalleOferta detalle;
                Producto producto;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_DETALLE_OFERTA_PORID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int32).Value = idOferta;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    detalle = new DetalleOferta();
                    producto = new Producto();
                    detalle.Oferta = oferta;
                    detalle.IdDetalle = dr.GetInt32(1);
                    detalle.CantidadMinima = dr.GetInt32(2);
                    detalle.CantidadMaxima = dr.GetInt32(3);
                    detalle.FechaIngreso = dr.GetDateTime(4);
                    // Producto
                    producto.IdProducto = dr.GetInt32(5);
                    producto.CodigoProducto = dr.GetInt32(6);
                    producto.Descripcion = dr.GetString(7);
                    producto.PrecioNormal = dr.GetInt32(8);
                    producto.PrecioOferta = dr.GetInt32(9);
                    detalle.Producto = producto;
                    detalleList.Add(detalle);
                }
                cone.Obtener().Close();
                return detalleList;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
        }

        public Boolean EliminarDetalle(DetalleOferta detalle)
        {
            try
            {
                Int32 IdDetalle = detalle.IdDetalle;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_ELIMINAR_DETALLE_OFERTA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_DETALLE_OFERTA", OracleDbType.Int32).Value = IdDetalle;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }
                cmd.ExecuteNonQuery();
                cone.Obtener().Close();
                return true;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return false;
            }
        }


        public Boolean EliminarListDetalle(List<DetalleOferta> listaDetalle)
        {
            try
            {
                foreach (DetalleOferta detalle in listaDetalle)
                {
                    Int32 IdDetalle = detalle.IdDetalle;
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cone.Obtener();
                    cmd.CommandText = "SP_ELIMINAR_DETALLE_OFERTA";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_ID_DETALLE_OFERTA", OracleDbType.Int32).Value = IdDetalle;
                    if (cone.Obtener().State == ConnectionState.Closed)
                    {
                        cone.Obtener().Open();
                    }
                    cmd.ExecuteNonQuery();
                    cone.Obtener().Close();
                }
                return true;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return false;
            }
        }
    }
}
