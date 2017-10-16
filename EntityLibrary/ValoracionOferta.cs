using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class ValoracionOferta
    {
        private int idValoracion;
        private Oferta oferta;
        private Consumidor consumidor;
        private Escala escala;
        private String rutaFotoValoracion;
        private DateTime fechaValoracion;

        //Atributos asignados al conteo de las valoraciones realizadas
        private int cantValoracionesNegativas;
        private int cantValoracionMedias;
        private int cantValoracionesPositivas;
        private int cantTotalValoraciones;

        public ValoracionOferta() { }

        public ValoracionOferta(int idValoracion, Oferta oferta, Consumidor consumidor, Escala escala, String ruta, DateTime fechaValoracion)
        {
            this.idValoracion = idValoracion;
            this.oferta = oferta;
            this.consumidor = consumidor;
            this.escala = escala;
            this.rutaFotoValoracion = ruta;
            this.fechaValoracion = fechaValoracion;
        }

        public int IdValoracion { get => idValoracion; set => idValoracion = value; }
        public Oferta Oferta { get => oferta; set => oferta = value; }
        public Consumidor Consumidor { get => consumidor; set => consumidor = value; }
        public Escala Escala { get => escala; set => escala = value; }
        public String RutaFotoValoracion { get => rutaFotoValoracion; set => rutaFotoValoracion = value; }
        public DateTime FechaValoracion { get => fechaValoracion; set => fechaValoracion = value; }
        public int CantValoracionesNegativas { get => cantValoracionesNegativas; set => cantValoracionesNegativas = value; }
        public int CantValoracionMedias { get => cantValoracionMedias; set => cantValoracionMedias = value; }
        public int CantValoracionesPositivas { get => cantValoracionesPositivas; set => cantValoracionesPositivas = value; }
        public int CantTotalValoraciones { get => cantTotalValoraciones; set => cantTotalValoraciones = value; }
    }
}
