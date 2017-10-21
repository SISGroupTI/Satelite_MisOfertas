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

        public Oferta RegistrarOferta(Oferta oferta) {
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
                cmd.Parameters.Add("p_out_ID_OFERTA", OracleDbType.Int32).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {

                    cone.Obtener().Open();
                }

                cmd.ExecuteNonQuery();
                oferta.IdOferta = Int32.Parse(cmd.Parameters["p_out_ID_OFERTA"].Value.ToString());
                cone.Obtener().Close();
                return oferta;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
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
        public Oferta ModificarOferta(Oferta oferta)
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
                return oferta;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
        }

        public List<Oferta> listarOfertasMasVisitadas()
        {
            //metodo para generar reporete de visitas
            try
            {
                Oferta oferta;
                List<Oferta> listaOfertas = new List<Oferta>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_OFT_MAS_VISITADAS";
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
                    oferta.IdOferta = dr.GetInt32(0);
                    oferta.TituloOferta = dr.GetString(1);
                    oferta.Visitas = dr.GetInt32(2);
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


        public List<Oferta> listarOfertasMasVisitadasMenuPrincipal(Oferta ofertaInput)
        {
            //metodo para generar el grafico de ofertas mas visitadas en la pagina principal
            try
            {
                Oferta oferta;
                List<Oferta> listaOfertas = new List<Oferta>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_OFT_MASVISIT_MENU";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_FECHA_PUBLICACION", OracleDbType.Date).Value = ofertaInput.FechaInicio;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oferta = new Oferta();
                    oferta.IdOferta = dr.GetInt32(0);
                    oferta.TituloOferta = dr.GetString(1);
                    oferta.CodigoOferta = dr.GetInt32(2);
                    oferta.Visitas = dr.GetInt32(3);
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
        
        public int cantidadTotalOfertas()
        {
            try
            {
                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_CANTTOTAL_OFERTAS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                int total = 0;
                while (dr.Read())
                {
                    total = dr.GetInt32(0);
                }
                cone.Obtener().Close();
                return total;
            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return 0;
            }
        }

        public List<OfertaBI> listaOfertasBI(DateTime? fechaCreacionInicio, DateTime? fechaCreacionTermino)
        {
            try
            {
                OfertaBI ofertaBI;
                List<OfertaBI> listaOfertasBI = new List<OfertaBI>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_OFERTAS_BI";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_FECHA_CREACION_INICIO", OracleDbType.Date).Value = fechaCreacionInicio;
                cmd.Parameters.Add("p_FECHA_CREACION_TERMINO", OracleDbType.Date).Value = fechaCreacionTermino;
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ofertaBI = new OfertaBI();
                    ofertaBI.NombreEmpresa = dr.GetString(0);
                    ofertaBI.NumeroLocal = dr.GetInt32(1);
                    ofertaBI.Rubro = dr.GetString(2);
                    ofertaBI.IdOferta = dr.GetInt32(3);
                    ofertaBI.TituloOferta = dr.GetString(5);
                    ofertaBI.PrecioOferta = dr.GetInt32(6);
                    ofertaBI.FechaCreacion = dr.GetString(7);
                    ofertaBI.FechaPublicacion = dr.GetString(8);
                    ofertaBI.FechaFinalizacion = dr.GetString(9);
                    ofertaBI.CantValoracionNegativas = dr.GetInt32(10);
                    ofertaBI.CantValoracionMedias = dr.GetInt32(11);
                    ofertaBI.CantValoracionPositivas = dr.GetInt32(12);
                    ofertaBI.CantValoracionTotal = dr.GetInt32(13);
                    ofertaBI.NombreProducto = dr.GetString(14);
                    ofertaBI.CantVisitas = dr.GetInt32(15);
                    listaOfertasBI.Add(ofertaBI);
                }

                cone.Obtener().Close();
                return listaOfertasBI;
            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
        }
    }
}
