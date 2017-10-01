using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLibrary;
/*
 * Esta clase es una clase de ayuda para el testing de elementos
 * que aun no obtiene o trabajan con datos desde la BD
 * que posteriormente debe ser borrada
 * 
 */

namespace DAOLibrary
{
    public class Coleccion
    {
        private static TipoProducto tipoProducto;
        private  List<TipoProducto> tipoproductos = new List<TipoProducto>();
        public Coleccion()
        {
            TipoProducto perecible = new TipoProducto();
            perecible.IdTipoProducto = 1;
            perecible.Descripcion = "Perecible";
            TipoProducto noPerecible = new TipoProducto();
            noPerecible.IdTipoProducto = 2;
            noPerecible.Descripcion = "No Perecible";
            tipoproductos.Add(perecible);
            tipoproductos.Add(noPerecible);

        }

        public  List<TipoProducto> Tipoproductos { get => tipoproductos; set => tipoproductos = value; }
    }

}
