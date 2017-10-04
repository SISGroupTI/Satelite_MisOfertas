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
    public class DAOOferta
    {
        Conexion cone;
        public DAOOferta()
        {
            if (cone == null)
                cone = new Conexion();
        }

        public Boolean RegistrarOferta(Oferta oferta) {
            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_REGISTRO_OFERTA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_RUBRO", OracleDbType.Int16).Value = oferta.Rubro.IdRubro;
                cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int16).Value = oferta.Local.IdLocal;
                cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int16).Value = oferta.Estado.IdEstado;
                cmd.Parameters.Add("p_CODIGO_OFERTA", OracleDbType.Int16).Value = oferta.CodigoOferta;
                cmd.Parameters.Add("p_FECHA_INICIO", OracleDbType.Date).Value = oferta.FechaInicio;
                cmd.Parameters.Add("p_FECHA_FINALIZACION", OracleDbType.Date).Value = oferta.FechaFinalizacion;
                cmd.Parameters.Add("p_PRECIO", OracleDbType.Int32).Value = oferta.Precio;
                cmd.Parameters.Add("p_IS_VISIBLE", OracleDbType.Int16).Value = oferta.IsVisible;
                cmd.Parameters.Add("p_TITULO_OFERTA", OracleDbType.Varchar2).Value = oferta.TituloOferta;
                cmd.Parameters.Add("p_DESCRIPCION_OFERTA", OracleDbType.Varchar2).Value = oferta.DescripcionOferta;
                cmd.Parameters.Add("p_CONDICIONES", OracleDbType.Varchar2).Value = oferta.Condiciones;
                cmd.Parameters.Add("p_IS_DISPONIBLE", OracleDbType.Int16).Value = oferta.IsDisponible;
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
        public Oferta BuscarOferta(Oferta ofertaInput)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_OFERTA_FILTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_CODIGO_OFERTA", OracleDbType.Int32).Value = ofertaInput.CodigoOferta;
                cmd.Parameters.Add("p_TITULO_OFERTA", OracleDbType.Varchar2).Value = ofertaInput.TituloOferta;
                cmd.Parameters.Add("p_FECHA_INICIO", OracleDbType.Date).Value = ofertaInput.FechaInicio;
                cmd.Parameters.Add("p_FECHA_FINALIZACION", OracleDbType.Date).Value = ofertaInput.FechaFinalizacion;
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ofertaInput.IdOferta = dr.GetInt32(0);

                }
                cone.Obtener().Close();
                return ofertaInput;
            }
            catch
            {
                return null;
            }
        }
        public List<Oferta> ListarOfertas()
        {
            try
            {
                Oferta oferta;
                Local local;
                Rubro rubro;
                Estado estado;
                List<Oferta> listaOfertas = new List<Oferta>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_OFERTAS_MENU";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oferta = new Oferta();
                    local = new Local();
                    rubro = new Rubro();
                    estado = new Estado();
                    oferta.IdOferta = dr.GetInt32(0);
                    oferta.TituloOferta = dr.GetString(1);
                    oferta.FechaCreacion = dr.GetDateTime(2);
                    oferta.FechaInicio = dr.GetDateTime(3);
                    oferta.FechaFinalizacion = dr.GetDateTime(4);
                    oferta.IsVisible = dr.GetInt32(5);
                    oferta.CodigoOferta = dr.GetInt32(6);
                    oferta.Visitas = dr.GetInt32(17);
                    //Local
                    local.IdLocal = dr.GetInt32(7);
                    local.Direccion = dr.GetString(8);
                    //Rubro
                    rubro.IdRubro = dr.GetInt32(11);
                    rubro.DescripcionRubro = dr.GetString(12);
                    //Estado
                    estado.IdEstado = dr.GetInt32(9);
                    estado.NombreEstado = dr.GetString(10);
                    oferta.DescripcionOferta = dr.GetString(13);
                    oferta.Condiciones = dr.GetString(14);
                    oferta.Precio = dr.GetInt32(15);
                    oferta.IsDisponible = dr.GetInt32(16);
                    oferta.Local = local;
                    oferta.Estado = estado;
                    oferta.Rubro = rubro;
                    listaOfertas.Add(oferta);
                }
                cone.Obtener().Close();
                return listaOfertas;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
        }
        public Boolean EliminarOferta(Oferta oferta)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_ELIMINAR_OFERTA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int16).Value = oferta.IdOferta;
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
        public Boolean ModificarOferta(Oferta oferta)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_MODIFICAR_OFERTA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int32).Value = oferta.IdOferta;
                cmd.Parameters.Add("p_PRECIO", OracleDbType.Int32).Value = oferta.Precio;
                cmd.Parameters.Add("p_TITULO", OracleDbType.Varchar2).Value = oferta.TituloOferta;
                cmd.Parameters.Add("p_DESCRIPCION_OFERTA", OracleDbType.Varchar2).Value = oferta.DescripcionOferta;
                cmd.Parameters.Add("p_CONDICIONES", OracleDbType.Varchar2).Value = oferta.Condiciones;
                cmd.Parameters.Add("p_FECHA_FINALIZACION", OracleDbType.Date).Value = oferta.FechaFinalizacion;
                cmd.Parameters.Add("p_FECHA_INICIO", OracleDbType.Date).Value = oferta.FechaInicio;
                cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int32).Value = oferta.Estado.IdEstado;
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
    }
}
