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
    public class DAOImagenesOferta
    {
        Conexion conexion;

        public DAOImagenesOferta()
        {
            if (conexion == null)
                conexion = new Conexion();
        }

        public Boolean ingresarImagenesOferta(List<ImagenOferta> imagenesOferta)
        {
            try
            {
                foreach (ImagenOferta imagen in imagenesOferta)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conexion.Obtener();
                    cmd.CommandText = "SP_REGISTRAR_IMG_OFERTA";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int16).Value = imagen.oferta.IdOferta;
                    cmd.Parameters.Add("p_IMAGEN", OracleDbType.Varchar2).Value = imagen.Imagen;
                    cmd.Parameters.Add("p_IS_PRINCIPAL", OracleDbType.Int16).Value = imagen.Is_principal;
                    if (conexion.Obtener().State == ConnectionState.Closed)
                    {

                        conexion.Obtener().Open();
                    }
                    cmd.ExecuteNonQuery();
                    conexion.Obtener().Close();
                    
                }
                return true;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return false;
            }
        }

        public List<ImagenOferta> listarImagenesOfertaPorOferta(Oferta oferta)
        {
            try
            {
                int idOferta = oferta.IdOferta;
                ImagenOferta imagenOferta;
                List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_IMG_OFERTA_POR_IDOFE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int32).Value = idOferta;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    imagenOferta = new ImagenOferta();
                    imagenOferta.Oferta = oferta;
                    imagenOferta.Imagen = dr.GetString(1);
                    imagenOferta.Is_principal = dr.GetInt32(2);
                    listaImagenesOferta.Add(imagenOferta);
                }

                return listaImagenesOferta;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }

        public Boolean eliminarImagenesOfertaPorOferta(Oferta oferta)
        {
            try
            {
                int idOferta = oferta.IdOferta;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_ELIMINAR_IMGOFERTA_POR_IDOF";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int32).Value = idOferta;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State == ConnectionState.Closed)
                {

                    conexion.Obtener().Open();
                }
                cmd.ExecuteNonQuery();
                conexion.Obtener().Close();
                return true;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return false;
            }
        }
    }
}
