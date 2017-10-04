using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class TipoRubro
    {
        private int idTipoRubro;
        private String descripcion;

        public int IdTipoRubro { get => idTipoRubro; set => idTipoRubro = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
