using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class TipoProductoNeg
    {
        DAOTipoProducto daoTipoProducto;
        public TipoProductoNeg()
        {
            if (daoTipoProducto == null)
                daoTipoProducto = new DAOTipoProducto();
        }
        public List<TipoProducto> ListarProducto() {
            return daoTipoProducto.ListarTipoProductos();
        }
    }
}
