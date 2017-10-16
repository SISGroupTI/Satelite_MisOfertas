using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class ReporteTiendas
    {
        private int consumidoresRegistradosDia;
        private int consumidoresRegistradorMes;
        private int consumidoresRegistradorAnio;
        private int anioRegistro;
        private int mesRegistro;
        private int diaRegistro;

        public ReporteTiendas()
        {

        }

        public int ConsumidoresRegistradosDia { get => consumidoresRegistradosDia; set => consumidoresRegistradosDia = value; }
        public int ConsumidoresRegistradosMes { get => consumidoresRegistradorMes; set => consumidoresRegistradorMes = value; }
        public int ConsumidoresRegistradosAnio { get => consumidoresRegistradorAnio; set => consumidoresRegistradorAnio = value; }
        public int AnioRegistro { get => anioRegistro; set => anioRegistro = value; }
        public int MesRegistro { get => mesRegistro; set => mesRegistro = value; }
        public int DiaRegistro { get => diaRegistro; set => diaRegistro = value; }

    }
}
