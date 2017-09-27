using ConxionLibrary;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLibrary
{
    public class DAOPerfil
    {
        private Conexion cone;
        public DAOPerfil()
        {
            cone = new Conexion();
        }

        public List<Perfil> ListarPerfiles()
        {
            try
            {
                Perfil perfil;
                List<Perfil> listaPerfiles = new List<Perfil>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_PERFIL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    perfil = new Perfil();
                    perfil.IdPerfil = dr.GetInt32(0);
                    perfil.NombrePerfil = dr.GetString(1);
                    
                    listaPerfiles.Add(perfil);
                }
                cone.Obtener().Close();
                return listaPerfiles;
            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
        }
    }
}
