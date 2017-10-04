using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Estado
    {
        private int idEstado;
        private String nombreEstado;

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string NombreEstado
        {
            get => nombreEstado; set => nombreEstado = value;

        }

        public Estado()
        {
        }

        public Estado(int idEstado, string nombreEstado)
        {
            this.IdEstado = idEstado;
            this.NombreEstado = nombreEstado;

        }
    }
}
