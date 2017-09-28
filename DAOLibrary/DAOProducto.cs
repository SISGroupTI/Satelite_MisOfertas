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
    public class DAOProducto
    {
        private Conexion cone;
        public DAOProducto()
        {
            cone = new Conexion();
        }

        public Boolean registrarProducto(Producto pro)
        {
            /*
             * Se guardan los campos del objeto encapsulado
             * y se asignan a variables locales del metodo
             * */
            Estado id_estado = pro.Estado;
            Local id_local = pro.Local;
            int codigo_producto = pro.CodigoProducto;
            String descripcion = pro.Descripcion;
            int precio_normal = pro.PrecioNormal;
            int precio_oferta = pro.PrecioOferta;
            DateTime fecha_caducidad = pro.FechaCaducidad;

            // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
            OracleCommand cmd = new OracleCommand();
            // Se le asigna la conexion
            cmd.Connection = cone.Obtener();
            // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
            cmd.CommandText = "SP_REGISTRAR_PRODUCTO";
            // Se le indica el tipo de comando en este caso son StoredProcedures
            cmd.CommandType = CommandType.StoredProcedure;
            /*
             * En este apartado se declaran los parametros que contiene el procedimiento Almacenado
             * Llenar los parametros del Add() de cada dato, por ejemplo
             * el primer parametro del Add() es el nombre de la variable descrita en la BD
             * el segundo parameto del Add() es el tipo de variable de la base de datos.
             * Finalmente a este parametro descrito anteriormente se le asigna el valor
             * Opcionalmente se puede declarar la direccion de este (parametro In o Out)
             * */
            cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int32).Value = id_estado;
            cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int32).Value = id_local;
            cmd.Parameters.Add("p_CODIGO_PRODUCTO", OracleDbType.Int32).Value = codigo_producto;
            cmd.Parameters.Add("p_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
            cmd.Parameters.Add("p_PRECIO_NORMAL", OracleDbType.Int32).Value = precio_normal;
            cmd.Parameters.Add("p_PRECIO_OFERTA", OracleDbType.Int32).Value = precio_oferta;
            cmd.Parameters.Add("p_FECHA_CADUCIDAD", OracleDbType.Date).Value = fecha_caducidad;
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

        public Boolean ModificarProducto(Producto pro)
        {
            try
            {
                /*
             * Se guardan los campos del objeto encapsulado
             * y se asignan a variables locales del metodo
             * */
                Estado id_estado = pro.Estado;
                Local id_local = pro.Local;
                int codigo_producto = pro.CodigoProducto;
                String descripcion = pro.Descripcion;
                int precio_normal = pro.PrecioNormal;
                int precio_oferta = pro.PrecioOferta;
                DateTime fecha_caducidad = pro.FechaCaducidad;

                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_MODIFICAR_PRODUCTO";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int32).Value = id_estado;
                cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int32).Value = id_local;
                cmd.Parameters.Add("p_CODIGO_PRODUCTO", OracleDbType.Int32).Value = codigo_producto;
                cmd.Parameters.Add("p_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                cmd.Parameters.Add("p_PRECIO_NORMAL", OracleDbType.Int32).Value = precio_normal;
                cmd.Parameters.Add("p_PRECIO_OFERTA", OracleDbType.Int32).Value = precio_oferta;
                cmd.Parameters.Add("p_FECHA_CADUCIDAD", OracleDbType.Date).Value = fecha_caducidad;
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

                return false;
            }
        }

        public Boolean EliminarProducto(Producto pro)
        {
            try
            {
                Int32 id_producto = pro.IdProducto;
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_ELIMINAR_PRODUCTO";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_ID_PRODUCTO", OracleDbType.Int32).Value = id_producto;
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

                return false;
            }

        }

        public List<Producto> ListaProducto()
        {
            try
            {
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_SELECT_PRODUCTO_MENU";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                Producto producto;
                Local local;
                Estado estado;
                List<Producto> listaPro=new List<Producto>();
                while (dr.Read())
                {
                    producto = new Producto();
                    local = new Local();
                    estado = new Estado();
                    //Producto
                    producto.IdProducto = dr.GetInt32(0);
                    producto.CodigoProducto = dr.GetInt32(1);
                    producto.Descripcion = dr.GetString(2);
                    producto.PrecioNormal = dr.GetInt32(3);
                    producto.PrecioOferta = dr.GetInt32(4);
                    producto.FechaRegistro = dr.GetDateTime(5);
                    //estado
                    estado.IdEstado = dr.GetInt32(6);
                    estado.NombreEstado = dr.GetString(7);
                    //local
                    local.IdLocal = dr.GetInt32(8);
                    local.Direccion = dr.GetString(9);
                    //asignacion de objeto a la clase
                    producto.Local = local;
                    producto.Estado = estado;
                    //paso el producto llenado a la lista
                    listaPro.Add(producto);
                   
                }
                cone.Obtener().Close();
                return listaPro;
            }
            catch
            {
                return null;
            }
        }
    }
 }

