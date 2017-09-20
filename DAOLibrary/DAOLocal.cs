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
    public class DAOLocal
    {
        private Conexion cone;
        private List<Local> locales = new List<Local>();
        public DAOLocal()
        {
            cone = new Conexion();
        }

        public Boolean RegistrarLocal(Empresa empresa, List<Local> locales)
        {
            try
            {
                /*
                 * Se guardan los campos del objeto encapsulado
                 * y se asignan a variables locales del metodo
                 * */
                int idEmpresa = empresa.IdEmpresa;
                int numeroLocal;
                String direccion;
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // En este caso se recorre una lista de locales que por medio de un siglo
                // Se va ejecutando la query
                foreach (Local local in locales)
                {
                    numeroLocal = local.NumeroLocal;
                    direccion = local.Direccion;
                    // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                    cmd.CommandText = "SP_REGISTRO_LOCAL";
                    // Se le indica el tipo de comando en este caso son StoredProcedures
                    cmd.CommandType = CommandType.StoredProcedure;
                    /*
                     * En este apartado se declaran los parametros que contiene el procedimiento Almacenado
                     * el primer parametro del Add() es el nombre de la variable descrita en la BD
                     * el segundo parameto del Add() es el tipo de variable de la base de datos
                     * Finalmente a este parametro descrito anteriormente se le asigna el valor
                     * Opcionalmente se puede declarar la direccion de este (parametro In o Out)
                     * */
                    cmd.Parameters.Add("p_ID_EMPRESA", OracleDbType.Int32).Value = idEmpresa;
                    cmd.Parameters.Add("p_NUMERO_LOCAL", OracleDbType.Int32).Value = numeroLocal;
                    cmd.Parameters.Add("p_DIRECCION", OracleDbType.Varchar2).Value = direccion;
                    /*
                    * Se valida si la conexion esta cerrada esto para minimizar 
                    * errores tales como "La conexion ya esta abierta"
                    */
                    if (cone.Obtener().State.Equals(ConnectionState.Closed))
                    {
                        cone.Obtener().Open();
                    }
                    cmd.ExecuteNonQuery();
                    cone.Obtener().Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return false;
            }
        }


    }
}
