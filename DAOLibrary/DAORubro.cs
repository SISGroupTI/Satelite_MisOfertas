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
    public class DAORubro
    {
        Conexion cone;
        public DAORubro()
        {
            if (cone == null)
                cone = new Conexion();
        }

        public List<Rubro> ListarRubros()
        {
            List<Rubro> rubros = new List<Rubro>();
            Rubro rubro;
            try
            {
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_SELECT_RUBRO";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rubro = new Rubro();
                    rubro.IdRubro = dr.GetInt32(0);
                    rubro.DescripcionRubro = dr.GetString(1);
                    TipoRubro tipo = new TipoRubro();
                    tipo.IdTipoRubro = dr.GetInt32(2);
                    rubro.TipoRubro = tipo;
                    rubros.Add(rubro);

                }
                cone.Obtener().Close();
                return rubros;
            }
            catch
            {
                return null;
            }
        }

        public List<Rubro> listarRubrosMasVisitados()
        {
            try
            {

                List<Rubro> listaRubrosMasVisitados = new List<Rubro>();
                Rubro rubro;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_RUBROS_MAS_VISITADOS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rubro = new Rubro();
                    rubro.IdRubro = dr.GetInt32(0);
                    rubro.DescripcionRubro = dr.GetString(1);
                    rubro.Visitas = dr.GetInt32(2);
                    listaRubrosMasVisitados.Add(rubro);


                }
                cone.Obtener().Close();
                return listaRubrosMasVisitados;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
