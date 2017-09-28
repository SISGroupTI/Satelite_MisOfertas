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
        /*
         * Este metodo realiza la logica del negocio para el registro de un nuevo
         *producto con su conjunto de locales
         * 
         * Params:
         * @rut = primeros 8 digitos del rut
         * @dv = verificador del rut
         * @nombre = nombre de la empresa
         * @localNeg = objeto de LocalNeg que contiene la lista de locales
         */
        public Boolean RegistrarProducto(Local loc,int codigo, String descripcion, int precioNormal, int precioOferta,Estado es,DateTime fechaCaducidad)
        {
            try
            {   // Se encapsulan los datos 
                Producto pro= new Producto(loc,codigo,descripcion,precioNormal,precioOferta,es,fechaCaducidad);
                // Se enviar esta empresa encapsulada a RegistrarProducto
                Boolean registrado = daoProducto.registrarProducto(pro);
                // Si el registro se realizo procede a la busqueda del producto antes ingresada
                if (registrado) { return true; }
                else { return false; }
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

        public Boolean ModificarProducto(Local loc, int codigo, String descripcion, int precioNormal, int precioOferta, Estado es, DateTime fechaCaducidad)
        {

            try
            {   // Se encapsulan los datos 
                Producto pro = new Producto(loc, codigo, descripcion, precioNormal, precioOferta, es, fechaCaducidad);
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

    }
}

