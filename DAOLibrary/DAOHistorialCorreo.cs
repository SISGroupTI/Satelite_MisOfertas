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
    public class DAOHistorialCorreo
    {
        Conexion conexion;
        public DAOHistorialCorreo()
        {
            if (conexion == null)
                conexion = new Conexion();
        }

        public List<HistorialCorreo> listaCantidadCorreosEnviados(DateTime? fechaInicioEnvio, DateTime? fechaTerminoEnvio)
        {
            try
            {
                HistorialCorreo historialCorreo;
                Oferta oferta;
                Local local;
                Empresa empresa;

                List<HistorialCorreo> listaHistorialCorreos = new List<HistorialCorreo>();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_REPORTE_CORREOS_ENV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_FECHA_ENVIO_INICIO", OracleDbType.Date).Value = fechaInicioEnvio;
                cmd.Parameters.Add("p_FECHA_ENVIO_TERMINO", OracleDbType.Date).Value = fechaTerminoEnvio;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    historialCorreo = new HistorialCorreo();
                    historialCorreo.CantCorreosEnviados = dr.GetInt32(0);
                    historialCorreo.FechaEnvio = dr.GetDateTime(1);

                    empresa = new Empresa();
                    empresa.NombreEmpresa = dr.GetString(6);

                    local = new Local();
                    local.Empresa = empresa;
                    local.NumeroLocal = dr.GetInt32(5);

                    oferta = new Oferta();
                    oferta.IdOferta = dr.GetInt32(2);
                    oferta.TituloOferta = dr.GetString(3);
                    oferta.CodigoOferta = dr.GetInt32(4);
                    oferta.Local = local;

                    historialCorreo.Oferta = oferta;
                    listaHistorialCorreos.Add(historialCorreo);
                }


                conexion.Obtener().Close();
                return listaHistorialCorreos;
            }
            catch (Exception er)
            {
                return null;
            }
        }
    }
}
