using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Descuento
    {
        private int idDescuento;
        private int puntos;
        private float descuento;
        private int tope;
        private String condiciones;
        private DateTime fechaEmision;
        private String listaRubros;
        private Consumidor consumidor;

        public Descuento()
        {

        }

        public Descuento(int idDescuento, int puntos, float descuento, int tope, String condiciones, DateTime fechaEmision, String rubros)
        {
            this.idDescuento = idDescuento;
            this.puntos = puntos;
            this.descuento = descuento;
            this.tope = tope;
            this.condiciones = condiciones;
            this.fechaEmision = fechaEmision;
            this.listaRubros = rubros;
        }

        public int IdDescuento { get => idDescuento; set => idDescuento = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public float Descuentos { get => descuento; set => descuento = value; }
        public int Tope { get => tope; set => tope = value; }
        public String Condiciones { get => condiciones; set => condiciones = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }

        public Consumidor Consumidor { get => consumidor; set => consumidor = value; }

        public String Rubros { get => listaRubros; set => listaRubros = value; }
    }
}
