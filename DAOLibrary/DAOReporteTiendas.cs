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

        public List<ReporteTiendas> listaConsumidoresRegistradosDia()
        {

            try
            {
                List<ReporteTiendas> listaConsumidoresDia = new List<ReporteTiendas>();
                ReporteTiendas reporteTiendas;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_CONS_REGISTRADOS_DIA";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public List<ReporteTiendas> listaConsumidoresRegistradosMes()
        {

            try
            {
                List<ReporteTiendas> listaConsumidoresMes = new List<ReporteTiendas>();
                ReporteTiendas reporteTiendas;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Obtener();
                cmd.CommandText = "SP_SELECT_CONS_REGISTRADOR_MES";
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}
