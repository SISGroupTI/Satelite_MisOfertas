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
    public class DAOReporteTiendas
    {
        Conexion conexion;

        public DAOReporteTiendas()
        {
            if (conexion == null)
                conexion = new Conexion();
        }

        public List<ReporteTiendas> listaConsumidoresRegistradosDia(DateTime? fechaInicioRegistro, DateTime? fechaTerminoRegistro)
        {

            try
            {
                List<ReporteTiendas> listaConsumidoresDia = new List<ReporteTiendas>();
                ReporteTiendas reporteTiendas;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_CONS_REGISTRADOS_DIA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_FECHA_REGISTRO_INICIO", OracleDbType.Date).Value = fechaInicioRegistro;
                cmd.Parameters.Add("p_FECHA_REGISTRO_TERMINO", OracleDbType.Date).Value = fechaTerminoRegistro;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reporteTiendas = new ReporteTiendas();
                    reporteTiendas.AnioRegistro = dr.GetInt32(0);
                    reporteTiendas.MesRegistro = dr.GetInt32(1);
                    reporteTiendas.DiaRegistro = dr.GetInt32(2);
                    reporteTiendas.ConsumidoresRegistradosDia = dr.GetInt32(3);
                    listaConsumidoresDia.Add(reporteTiendas);

                }

                conexion.Obtener().Close();
                return listaConsumidoresDia;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }

        public List<ReporteTiendas> listaConsumidoresRegistradosMes(DateTime? fechaInicioRegistro, DateTime? fechaTerminoRegistro)
        {

            try
            {
                List<ReporteTiendas> listaConsumidoresMes = new List<ReporteTiendas>();
                ReporteTiendas reporteTiendas;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_CONS_REGISTRADOR_MES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_FECHA_REGISTRO_INICIO", OracleDbType.Date).Value = fechaInicioRegistro;
                cmd.Parameters.Add("p_FECHA_REGISTRO_TERMINO", OracleDbType.Date).Value = fechaTerminoRegistro;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reporteTiendas = new ReporteTiendas();
                    reporteTiendas.AnioRegistro = dr.GetInt32(0);
                    reporteTiendas.MesRegistro = dr.GetInt32(1);
                    reporteTiendas.ConsumidoresRegistradosMes = dr.GetInt32(2);
                    listaConsumidoresMes.Add(reporteTiendas);

                }

                conexion.Obtener().Close();
                return listaConsumidoresMes;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }

        public List<ValoracionOferta> listaValoracionesPorEmpresa()
        {
            try
            {

                List<ValoracionOferta> listaValoraciones = new List<ValoracionOferta>();
                ValoracionOferta valoracionOferta;
                Empresa empresa;
                Local local;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_EMPRESA_VALORACIONES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    valoracionOferta = new ValoracionOferta();
                    empresa = new Empresa();
                    local = new Local();

                    valoracionOferta.CantValoracionesNegativas = dr.GetInt32(4);
                    valoracionOferta.CantValoracionMedias = dr.GetInt32(5);
                    valoracionOferta.CantValoracionesPositivas = dr.GetInt32(6);
                    valoracionOferta.CantTotalValoraciones = dr.GetInt32(7);

                    empresa.RutEmpresa = dr.GetInt32(0);
                    //empresa.DvEmpresa = dr.GetString(1);
                    empresa.NombreEmpresa = dr.GetString(2);
                    local.NumeroLocal = dr.GetInt32(3);

                    valoracionOferta.Empresa = empresa;
                    valoracionOferta.Local = local;

                    listaValoraciones.Add(valoracionOferta);

                }


                conexion.Obtener().Close();
                return listaValoraciones;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }

        public List<Rubro> listaCuponesGeneradosPorRubro()
        {
            try
            {
                List<Rubro> listaCuponesGenerados = new List<Rubro>();
                Rubro rubro;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_REPORTE_CUPN_RUBRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (conexion.Obtener().State.Equals(ConnectionState.Closed))
                {
                    conexion.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rubro = new Rubro();
                    rubro.IdRubro = dr.GetInt32(0);
                    rubro.DescripcionRubro = dr.GetString(1);
                    rubro.CantidadCuponesGenerados = dr.GetInt32(2);
                    listaCuponesGenerados.Add(rubro);
                }

                conexion.Obtener().Close();
                return listaCuponesGenerados;
            }
            catch (Exception e)
            {
                conexion.Obtener().Close();
                return null;
            }
        }
    }
}
