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
            try {
                
                int id_local = pro.Local.IdLocal;
                int codigo_producto = pro.CodigoProducto;
                String descripcion = pro.Descripcion;
                int precio_normal = pro.PrecioNormal;
                int precio_oferta = pro.PrecioOferta;
                DateTime fecha_caducidad = pro.FechaCaducidad;
                int id_estado = pro.Estado.IdEstado;
                int id_rubro = pro.Rubro.IdRubro;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_REGISTRO_PRODUCTO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int32).Value = id_local;
                cmd.Parameters.Add("p_CODIGO_PRODUCTO", OracleDbType.Int32).Value = codigo_producto;
                cmd.Parameters.Add("p_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                cmd.Parameters.Add("p_PRECIO_NORMAL", OracleDbType.Int32).Value = precio_normal;
                cmd.Parameters.Add("p_PRECIO_OFERTA", OracleDbType.Int32).Value = precio_oferta;
                cmd.Parameters.Add("p_FECHA_CADUCIDAD", OracleDbType.Date).Value = fecha_caducidad;
                cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int32).Value = id_estado;
                cmd.Parameters.Add("p_ID_RUBRO", OracleDbType.Int32).Value = id_rubro;

                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }
                cmd.ExecuteNonQuery();
                cone.Obtener().Close();
                return true;
            } catch(Exception e)
            {
                cone.Obtener().Close();
                return false;
            }

        }
        public Boolean ModificarProducto(Producto pro)
        {
            try
            {
                /*
             * Se guardan los campos del objeto encapsulado
             * y se asignan a variables locales del metodo
             * */
                int id_producto = pro.IdProducto;
                int id_local = pro.Local.IdLocal;
                int codigo_producto = pro.CodigoProducto;
                String descripcion = pro.Descripcion;
                int precio_normal = pro.PrecioNormal;
                int precio_oferta = pro.PrecioOferta;
                DateTime fecha_caducidad = pro.FechaCaducidad;
                int id_estado = pro.Estado.IdEstado;
                int id_rubro = pro.Rubro.IdRubro;
                // Se instancia un OracleCommand encargado de armar la consulta y ejecutarla
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                // Se le asigna el nombre del SP (Ojo tiene que ser igual a la BD sin comillas)
                cmd.CommandText = "SP_MODIFICAR_PRODUCTO";
                // Se le indica el tipo de comando en este caso son StoredProcedures
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ID_PRODUCTO", OracleDbType.Int32).Value = id_producto;
                cmd.Parameters.Add("p_ID_LOCAL", OracleDbType.Int32).Value = id_local;
                cmd.Parameters.Add("p_CODIGO_PRODUCTO", OracleDbType.Int32).Value = codigo_producto;
                cmd.Parameters.Add("p_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                cmd.Parameters.Add("p_PRECIO_NORMAL", OracleDbType.Int32).Value = precio_normal;
                cmd.Parameters.Add("p_PRECIO_OFERTA", OracleDbType.Int32).Value = precio_oferta;
                cmd.Parameters.Add("p_FECHA_CADUCIDAD", OracleDbType.Date).Value = fecha_caducidad;
                cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int32).Value = id_estado;
                cmd.Parameters.Add("p_ID_RUBRO", OracleDbType.Int32).Value = id_rubro;

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
                cmd.Parameters.Add("p_ID_ESTADO", OracleDbType.Int32).Value = 2;

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
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_PRODUCTO_MENU";
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
                Rubro rubro;
                List<Producto> listaPro = new List<Producto>();
                while (dr.Read())
                {
                    producto = new Producto();
                    local = new Local();
                    estado = new Estado();
                    rubro = new Rubro();
                    //Producto
                    producto.IdProducto = dr.GetInt32(0);
                    producto.CodigoProducto = dr.GetInt32(1);
                    producto.Descripcion = dr.GetString(2);
                    producto.PrecioNormal = dr.GetInt32(3);
                    producto.PrecioOferta = dr.GetInt32(4);
                    producto.FechaRegistro = dr.GetDateTime(5);
                    //Estado
                    estado.IdEstado = dr.GetInt32(8);
                    estado.NombreEstado = dr.GetString(9);
                    //local
                    local.IdLocal = dr.GetInt32(6);
                    local.Direccion = dr.GetString(7);
                    //asignacion de objeto a la clase
                    //Rubro
                    rubro.IdRubro = dr.GetInt32(11);
                    rubro.DescripcionRubro = dr.GetString(12);
                    TipoRubro tipo = new TipoRubro();
                    tipo.IdTipoRubro = dr.GetInt32(13);
                    rubro.TipoRubro = tipo;
                    
                    producto.Rubro = rubro;
                    producto.Local = local;
                    producto.Estado = estado;
                    if (producto.Rubro.TipoRubro.IdTipoRubro == 1)
                    {
                        producto.FechaCaducidad = dr.GetDateTime(10);

                    }
                    listaPro.Add(producto);

                }
                cone.Obtener().Close();
                return listaPro;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public List<Producto> ListarProductoPorRubro(Rubro rubro)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                // Se le asigna la conexion
                cmd.Connection = cone.Obtener();
                cmd.CommandText = "SP_SELECT_PRODUCTO_RUBRO";
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_ID_RUBRO", OracleDbType.Int32).Value = rubro.IdRubro;
                cmd.Parameters.Add("p_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                if (cone.Obtener().State == ConnectionState.Closed)
                {
                    cone.Obtener().Open();
                }

                OracleDataReader dr = cmd.ExecuteReader();
                Producto producto;
                Local local;
                Estado estado;
                Rubro ru;
                List<Producto> listaPro = new List<Producto>();
                while (dr.Read())
                {
                    producto = new Producto();
                    local = new Local();
                    estado = new Estado();
                    ru = new Rubro();
                    //Producto
                    producto.IdProducto = dr.GetInt32(0);
                    producto.CodigoProducto = dr.GetInt32(1);
                    producto.Descripcion = dr.GetString(2);
                    producto.PrecioNormal = dr.GetInt32(3);
                    producto.PrecioOferta = dr.GetInt32(4);
                    producto.FechaRegistro = dr.GetDateTime(5);
                    //Estado
                    estado.IdEstado = dr.GetInt32(8);
                    estado.NombreEstado = dr.GetString(9);
                    //local
                    local.IdLocal = dr.GetInt32(6);
                    local.Direccion = dr.GetString(7);
                    //asignacion de objeto a la clase
                    ru.IdRubro = dr.GetInt32(11);
                    ru.DescripcionRubro = dr.GetString(12);
                    TipoRubro tipo = new TipoRubro();
                    tipo.IdTipoRubro = dr.GetInt32(13);
                    rubro.TipoRubro = tipo;
                    
                    producto.Rubro = rubro;
                    producto.Local = local;
                    producto.Estado = estado;
                    if (producto.Rubro.TipoRubro.IdTipoRubro == 1)
                    {
                        producto.FechaCaducidad = dr.GetDateTime(10);

                    }
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

