using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class TipoProducto
    {
        private int idTipoProducto;
        private String descripcion;

        public int IdTipoProducto { get => idTipoProducto; set => idTipoProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
