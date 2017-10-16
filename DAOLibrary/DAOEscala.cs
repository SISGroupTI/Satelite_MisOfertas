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
    public class DAOEscala
    {
        Conexion conexion;
        
        public DAOEscala()
        {
            if (conexion == null)
                conexion = new Conexion();            
        }

        public List<Escala> listarEscalas()
        {
            try
            {
                List<Escala> listaEscala = new List<Escala>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_ESCALAS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Escala escala = new Escala();
                    escala.IdEscala = dr.GetInt32(0);
                    escala.Nota = dr.GetString(1);
                    listaEscala.Add(escala);
                }
                conexion.Obtener().Clone();
                return listaEscala;
            }
            catch (Exception e)
            {
                conexion.Obtener().Clone();
                return null;
            }
        }
    }
}
