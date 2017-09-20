using ConxionLibrary;
using EntityLibrary;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLibrary
{
    public class DAOEmpresa
    {
        private Conexion cone;
        public DAOEmpresa()
        {
            cone = new Conexion();
        }
        public Boolean RegistrarEmpresa(Empresa empresa)
        {
            try
            { 
                /*
                 * Se guardan los campos del objeto encapsulado
                 * y se asignan a variables locales del metodo
                 * */
                int rut = empresa.RutEmpresa;
                char dv = empresa.DvEmpresa;
                String nombre = empresa.NombreEmpresa;
                Int16 isActivo = 1;
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_REGISTRO_EMPRESA";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                /*
                     * En este apartado se declaran los parametros que contiene el procedimiento Almacenado
                     * el primer parametro del Add() es el nombre de la variable descrita en la BD
                     * el segundo parameto del Add() es el tipo de variable de la base de datos
                     * Finalmente a este parametro descrito anteriormente se le asigna el valor
                     * Opcionalmente se puede declarar la direccion de este (parametro In o Out)
                     * */
                cmd.Parameters.Add("p_RUT_EMPRESA", OracleDbType.Int16).Value = rut;
                cmd.Parameters.Add("p_DV_EMPRESA", OracleDbType.Char).Value = dv;
                cmd.Parameters.Add("p_NOMBRE_EMPRESA", OracleDbType.Varchar2).Value = nombre;
                cmd.Parameters.Add("p_IS_ACTIVO", OracleDbType.Int16).Value = isActivo;
                /*
                 * Se valida si la conexion esta cerrada esto para minimizar 
                 * errores tales como "La conexion ya esta abierta"
                 */
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
        public Empresa BuscarEmpresaRut(Empresa empresa)
        {
            try
            {
                int rut = empresa.RutEmpresa;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_EMPRESA_POR_RUT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_RUT_EMPRESA", OracleDbType.Int32).Value = rut;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empresa.IdEmpresa = dr.GetInt32(0);
                    empresa.IsActivo = dr.GetInt32(7);
                    cone.Obtener().Close();
                    return empresa;
                }
                cone.Obtener().Close();
                return null;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
