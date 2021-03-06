﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Rubro
    {
        private int idRubro;
        private String descripcionRubro;
        private TipoRubro tipoRubro;
        private int visitas;
        private int cantidadCuponesGenerados;

        public int IdRubro { get => idRubro; set => idRubro = value; }
        public string DescripcionRubro { get => descripcionRubro; set => descripcionRubro = value; }
        public TipoRubro TipoRubro { get => tipoRubro; set => tipoRubro = value; }
        public int Visitas { get => visitas; set => visitas = value; }
        public int CantidadCuponesGenerados { get => cantidadCuponesGenerados; set => cantidadCuponesGenerados = value; }

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
