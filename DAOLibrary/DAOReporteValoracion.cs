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
    public class DAOReporteValoracion
    {
        Conexion conexion;

        public DAOReporteValoracion()
        {
            if (conexion == null)
                conexion = new Conexion();
        }

        public List<ReporteValoracion> listaRegistroValoracion(DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                List<ReporteValoracion> listaRegistros = new List<ReporteValoracion>();
                OracleCommand cmd = new OracleCommand();
                ReporteValoracion reporte;
                Oferta oferta;
                Rubro rubro;
                Local local;
                Empresa empresa;



                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_REPORTE_VALORACIONES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_FECHA_PUBLICACION_INICIO", OracleDbType.Date).Value = fechaInicio;
                cmd.Parameters.Add("p_FECHA_PUBLICACION_TERMINO", OracleDbType.Date).Value = fechaFin;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reporte = new ReporteValoracion();

                    oferta = new Oferta();
                    oferta.IdOferta = dr.GetInt32(0);
                    oferta.TituloOferta = dr.GetString(1);
                    oferta.FechaInicio = dr.GetDateTime(2);
                    oferta.FechaFinalizacion = dr.GetDateTime(3);
                    rubro = new Rubro();
                    rubro.IdRubro = dr.GetInt32(4);
                    rubro.DescripcionRubro = dr.GetString(5);
                    local = new Local();
                    local.Direccion = dr.GetString(6);
                    empresa = new Empresa();
                    empresa.NombreEmpresa = dr.GetString(7);

                    reporte.Oferta = oferta;
                    reporte.Rubro = rubro;
                    reporte.Local = local;
                    reporte.Empresa = empresa;


                    reporte.CantValoracionNegativas = dr.GetInt32(8);
                    reporte.CantValoracionMedia = dr.GetInt32(9);
                    reporte.CantValoracionPositiva = dr.GetInt32(10);
                    reporte.CantValoracionTotal = dr.GetInt32(11);
                    reporte.CantProductos = dr.GetInt32(12);
                    reporte.CantImagenes = dr.GetInt32(13);

                    listaRegistros.Add(reporte);

                }
                conexion.Obtener().Close();
                return listaRegistros;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }
    }
}
