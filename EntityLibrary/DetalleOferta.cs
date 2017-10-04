using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class DetalleOferta
    {
        private int idDetalle;
        private Oferta oferta;
        private Producto producto;
        private int cantidadMinima;
        private int cantidadMaxima;
        private DateTime fechaIngreso;

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public Oferta Oferta { get => oferta; set => oferta = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public int CantidadMinima { get => cantidadMinima; set => cantidadMinima = value; }
        public int CantidadMaxima { get => cantidadMaxima; set => cantidadMaxima = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }

        public DetalleOferta(int idDetalle, Oferta oferta, Producto producto, int cantidadMinima, int cantidadMaxima, DateTime fechaIngreso)
        {
            this.idDetalle = idDetalle;
            this.oferta = oferta;
            this.producto = producto;
            this.cantidadMinima = cantidadMinima;
            this.cantidadMaxima = cantidadMaxima;
            this.fechaIngreso = fechaIngreso;
        }

        public DetalleOferta()
        {
        }
    }
}
