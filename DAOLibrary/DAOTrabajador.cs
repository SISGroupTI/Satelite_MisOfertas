using ConxionLibrary;
using EntityLibrary;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAOLibrary
{
    public class DAOTrabajador
    {
        private Conexion cone;
        public DAOTrabajador()
        {
            cone = new Conexion();
        }

        public Trabajador validarTrabajador(Trabajador trabajador)
        {
            /*
             * Se guardan los campos del objeto encapsulado
             * y se asignan a variables locales del metodo
             * */
            String nombre_usuario = trabajador.NombreUsuario;
            String contrasena = trabajador.Contrasena;
            // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
            OracleCommand cmd = new OracleCommand();
            // Se le asigna la conexion
            cmd.Connection = cone.Obtener();
            // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
            cmd.CommandText = "SP_INICIO_SESION_TRABAJADOR";
            // Se le indica el tipo de comando en este caso son StoredProcedures
            cmd.CommandType = CommandType.StoredProcedure;
            /*
             * En este apartado se declaran los parametros que contiene el procedimiento Almacenado
             * el primer parametro del Add() es el nombre de la variable descrita en la BD
             * el segundo parameto del Add() es el tipo de variable de la base de datos
             * Finalmente a este parametro descrito anteriormente se le asigna el valor
             * Opcionalmente se puede declarar la direccion de este (parametro In o Out)
             * */
            cmd.Parameters.Add("p_NOMBRE_USUARIO", OracleDbType.Varchar2).Value = nombre_usuario;
            cmd.Parameters.Add("p_CONTRASENA", OracleDbType.Varchar2).Value = contrasena;
            /*
             * Este es un caso especial ya que para este procedimiento almacenado como parametro
             * esta el SYS_refCursor y este tiene una direccion Out de la BD
             * Se realiza la misma accion que el otro pero este se le declara la direccion
             * definiendola como OutPut
             * */
            cmd.Parameters.Add(new OracleParameter( "p_CURSOR", OracleDbType.RefCursor)).Direction =ParameterDirection.Output;
            try
            {
                /*
                 * Se valida si la conexion esta cerrada esto para minimizar 
                 * errores tales como "La conexion ya esta abierta"
                 */
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                /*
                 * Se ejecuta el comando como ExecuteReader con el objetivo de que devuelve datos del
                 * procedimiento almacenado,este metodo se reliza siempre y cuando existan parametros de 
                 * salida, en caso contrario utilizar ExecuteNoQuery que solo devuelve un valor int
                 */
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //dr.GetInt32(0); el index hace referencia a la posicion del valor dentro del select
                    trabajador.IdTrabajador = dr.GetInt32(0);
                    trabajador.Rut = dr.GetInt32(2);
                    trabajador.Dv = dr.GetString(3);
                    trabajador.Nombre = dr.GetString(4);
                    trabajador.Apellidos = dr.GetString(5);
                    trabajador.CorreoCorporativo = dr.GetString(6);
                    trabajador.FechaIngreso = dr.GetDateTime(7);
                    trabajador.Nombre = dr.GetString(8);
                    trabajador.Perfil = new Perfil(dr.GetInt32(9),dr.GetString(8));
                    Empresa empresa = new Empresa();
                    empresa.NombreEmpresa = dr.GetString(13);
                    empresa.IdEmpresa = dr.GetInt32(12);
                    Local local = new Local();
                    local.IdLocal = dr.GetInt32(10);
                    local.NumeroLocal = dr.GetInt32(11);
                    local.Empresa = empresa;
                    trabajador.Local = local;
                    

                }
                //Se cierra la conexion
                cone.Obtener().Close();
                return trabajador;

            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
            cone.Obtener().Close();
            return null;
        }
    }
}
