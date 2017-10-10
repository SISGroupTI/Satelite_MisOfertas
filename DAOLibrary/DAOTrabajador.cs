using ConxionLibrary;
using EntityLibrary;
using Helpers;
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
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cone.Obtener();
            cmd.CommandText = "SP_INICIO_SESION_TRABAJADOR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_NOMBRE_USUARIO", OracleDbType.Varchar2).Value = nombre_usuario;
            cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
            try
            {
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
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
                    trabajador.Perfil = new Perfil(dr.GetInt32(9), dr.GetString(8));
                    trabajador.Contrasena = dr.GetString(14);
                    Empresa empresa = new Empresa();
                    empresa.NombreEmpresa = dr.GetString(13);
                    empresa.IdEmpresa = dr.GetInt32(12);
                    Local local = new Local();
                    local.IdLocal = dr.GetInt32(10);
                    local.NumeroLocal = dr.GetInt32(11);
                    local.Empresa = empresa;
                    trabajador.Local = local;
                }
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

       public List<Trabajador> ListarTrabajadores()
        {
            try
            {               
                Trabajador trabajador;
                List<Trabajador> listaTrabajadores = new List<Trabajador>();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_TRABAJADOR_MENU";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                if (cone.Obtener().State.Equals(ConnectionState.Closed))
                {
                    cone.Obtener().Open();
                }
                OracleDataReader dr = cmd.ExecuteReader();
                Perfil perfil;
                Local local;
                while (dr.Read())
                {
                    trabajador = new Trabajador();
                    trabajador.IdTrabajador = dr.GetInt16(0);
                    trabajador.Nombre = dr.GetString(4);
                    trabajador.Rut = dr.GetInt32(2);
                    trabajador.Dv = dr.GetString(3);
                    local = new Local();
                    local.IdLocal = dr.GetInt32(9);
                    trabajador.CorreoCorporativo = dr.GetString(6);
                    perfil = new Perfil();
                    perfil.IdPerfil = dr.GetInt32(12);
                    trabajador.NombreUsuario = dr.GetString(1);
                    trabajador.Apellidos = dr.GetString(5);
                    trabajador.Perfil = perfil;
                    trabajador.Local = local;
                    trabajador.Contrasena = dr.GetString(14);
                    trabajador.FechaIngreso = dr.GetDateTime(7);
                    listaTrabajadores.Add(trabajador);
                }
                cone.Obtener().Close();
                return listaTrabajadores;
            }
            catch (Exception e)
            {
                cone.Obtener().Close();
                return null;
            }
        }

        public Boolean RegistrarTrabajador(Trabajador trabajador)
        {
            try
            {
                

                long idPerfil = trabajador.Perfil.IdPerfil;
                int idLocal = trabajador.Local.IdLocal;
                String nombreUsuario = trabajador.NombreUsuario;
                int rut = trabajador.Rut;
                String dv = trabajador.Dv;
                String nombre = trabajador.Nombre;
                String apellidos = trabajador.Apellidos;
                String correoCorporativo = trabajador.CorreoCorporativo;
                String contrasena = PasswordStorage.CreateHash(trabajador.Contrasena);
                int isActivo = 1;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_REGISTRO_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_ID_PERFIL", OracleDbType.Int32).Value = idPerfil;
                cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int32).Value = idLocal;
                cmd.Parameters.Add("p_NOMBRE_USUARIO", OracleDbType.Varchar2).Value = nombreUsuario;
                cmd.Parameters.Add("p_RUT", OracleDbType.Int32).Value = rut;
                cmd.Parameters.Add("p_DV", OracleDbType.Char).Value = dv;
                cmd.Parameters.Add("p_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                cmd.Parameters.Add("p_APELLIDOS", OracleDbType.Varchar2).Value = apellidos;
                cmd.Parameters.Add("p_CORREO_CORPORATIVO", OracleDbType.Varchar2).Value = correoCorporativo;
                cmd.Parameters.Add("p_CONTRASENA", OracleDbType.Varchar2).Value = contrasena;
                cmd.Parameters.Add("IS_ACTIVO", OracleDbType.Int16).Value = isActivo;

                if (cone.Obtener().State==ConnectionState.Closed)
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

        public Boolean EliminarTrabajador(Trabajador trabajador)
        {
            try
            {
                long idTrabajador = trabajador.IdTrabajador;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_ELIMINAR_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_ID_TRABAJADOR", OracleDbType.Int32).Value = idTrabajador;
                cmd.Parameters.Add("p_IS_ACTIVO", OracleDbType.Int16).Value = 0;
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

        public Boolean ModificarTrabajador(Trabajador trabajador)
        {
            try
            {
                long idTrabajador = trabajador.IdTrabajador;
                long idPerfil = trabajador.Perfil.IdPerfil;
                int idLocal = trabajador.Local.IdLocal;
                String nombreUsuario = trabajador.NombreUsuario;
                int rut = trabajador.Rut;
                String dv = trabajador.Dv;
                String nombre = trabajador.Nombre;
                String apellidos = trabajador.Apellidos;
                String correoCorporativo = trabajador.CorreoCorporativo;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_MODIFICAR_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_TRABAJADOR", OracleDbType.Int32).Value = idTrabajador;
                cmd.Parameters.Add("p_ID_PERFIL", OracleDbType.Int32).Value = idPerfil;
                cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int32).Value = idLocal;
                cmd.Parameters.Add("p_NOMBRE_USUARIO", OracleDbType.Varchar2).Value = nombreUsuario;
                cmd.Parameters.Add("p_RUT", OracleDbType.Int32).Value = rut;
                cmd.Parameters.Add("p_DV", OracleDbType.Char).Value = dv;
                cmd.Parameters.Add("p_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                cmd.Parameters.Add("p_APELLIDOS", OracleDbType.Varchar2).Value = apellidos;
                cmd.Parameters.Add("p_CORREO_CORPORATIVO", OracleDbType.Varchar2).Value = correoCorporativo;
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
    }
}
