using ConxionLibrary;
using EntityLibrary;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLibrary
{
    public class DAOValoracionOferta
    {
        Conexion conexion;

        public DAOValoracionOferta()
        {
            if (conexion == null)
                conexion = new Conexion();
        }

        public ValoracionOferta listarCantValoracionesPorOferta(Oferta oferta, ValoracionOferta valoracionOferta)
        {
            try
            {
                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_CANT_VALORACION_OFT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_OFERTA", OracleDbType.Int16).Value = oferta.IdOferta;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Oferta ofertaOut = new Oferta();
                    ofertaOut.IdOferta = dr.GetInt32(0);
                    valoracionOferta.Oferta = ofertaOut;

                    valoracionOferta.CantValoracionesNegativas = dr.GetInt32(2);
                    valoracionOferta.CantValoracionMedias = dr.GetInt32(3);
                    valoracionOferta.CantValoracionesPositivas = dr.GetInt32(4);
                    valoracionOferta.CantTotalValoraciones = dr.GetInt32(5);
                }


                conexion.Obtener().Close();
                return valoracionOferta;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }
    }
}
