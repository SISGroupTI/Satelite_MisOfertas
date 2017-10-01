using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Rubro
    {
        private int idRubro;
        private String descripcionRubro;

        public int IdRubro { get => idRubro; set => idRubro = value; }
        public string DescripcionRubro { get => descripcionRubro; set => descripcionRubro = value; }

        public Rubro(int idRubro, string descripcionRubro)
        {
            this.idRubro = idRubro;
            this.descripcionRubro = descripcionRubro;
        }

        public Rubro()
        {
        }
    }
}
