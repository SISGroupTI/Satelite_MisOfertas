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
            String nombre_usuario = trabajador.NombreUsuario;
            String contrasena = trabajador.Contrasena;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cone.Obtener();
            cmd.CommandText = "SP_INICIO_SESION_TRABAJADOR";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("p_NOMBRE_USUARIO", OracleDbType.Varchar2).Value = nombre_usuario;
            cmd.Parameters.Add("p_CONTRASENA", OracleDbType.Varchar2).Value = contrasena;
            cmd.Parameters.Add(new OracleParameter( "p_CURSOR", OracleDbType.RefCursor)).Direction =ParameterDirection.Output;
            try
            {
                cone.Obtener().Open();
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
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
                    return trabajador;

                }
                cone.Obtener().Close();
                

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
