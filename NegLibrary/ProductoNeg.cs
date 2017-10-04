using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class ProductoNeg
    {
        private DAOProducto daoProducto;
        private DAOLocal daoLocal;

        public ProductoNeg()
        {
            if (daoProducto == null)
                daoProducto = new DAOProducto();
            if (daoLocal == null)
                daoLocal = new DAOLocal();
        }
       
        public Boolean RegistrarProducto(Local local, int codigoProducto, String descripcion, int precioNormal, int precioOferta, DateTime fechaCaducidad,Estado estado,Rubro rubro)
        {
            try
            {   // Se encapsulan los datos 
                Producto pro = new Producto(local,codigoProducto,  descripcion, precioNormal, precioOferta, fechaCaducidad, estado);
                pro.Rubro = rubro;
                // Se enviar esta empresa encapsulada a RegistrarProducto
                return  daoProducto.registrarProducto(pro);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Producto> listarProducto()
        {
            try
            {
                return daoProducto.ListaProducto();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Boolean EliminarProducto(Producto p)
        {
            try
            {
                return daoProducto.EliminarProducto(p);
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Boolean ModificarProducto(Local local, int codigoProducto, String descripcion, int precioNormal, int precioOferta, DateTime fechaCaducidad, Estado estado, int id_producto,Rubro rubro)
        {

            try
            {   // Se encapsulan los datos 
                Producto pro = new Producto( local, codigoProducto, descripcion, precioNormal, precioOferta, fechaCaducidad, estado);
                pro.IdProducto = id_producto;
                pro.Rubro = rubro;
                // Se enviar esta empresa encapsulada a RegistrarProducto
                Boolean modificado = daoProducto.ModificarProducto(pro);
                // Si el registro se realizo procede a la busqueda del producto antes ingresada
                if (modificado) { return true; }
                else { return false; }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Producto> ListarProductosPorRubro(Rubro rubro)
        {
            return daoProducto.ListarProductoPorRubro(rubro);
        }
    }
}
