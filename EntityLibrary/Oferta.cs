using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Oferta
    {
        private int idOferta;
        private Rubro rubro;
        private Local local;
        private Estado estado;
        private int codigoOferta;
        private DateTime fechaCreacion;
        private DateTime fechaInicio;
        private DateTime fechaFinalizacion;
        private int precio;
        private int isVisible;
        private String tituloOferta;
        private String descripcionOferta;
        private String condiciones;
        private int isDisponible;
        private DateTime fechaModificacion;
        private DateTime fechaEliminacion;
        private int visitas;

        public Oferta(int idOferta, Rubro rubro, Local local, Estado estado, int codigoOferta, DateTime fechaCreacion, DateTime fechaInicio, DateTime fechaFinalizacion, int precio, int isVisible, string tituloOferta, string descripcionOferta, string condiciones, int isDisponible, DateTime fechaModificacion, DateTime fechaEliminacion)
        {
            this.idOferta = idOferta;
            this.rubro = rubro;
            this.local = local;
            this.estado = estado;
            this.codigoOferta = codigoOferta;
            this.fechaCreacion = fechaCreacion;
            this.fechaInicio = fechaInicio;
            this.fechaFinalizacion = fechaFinalizacion;
            this.precio = precio;
            this.isVisible = isVisible;
            this.tituloOferta = tituloOferta;
            this.descripcionOferta = descripcionOferta;
            this.Condiciones = condiciones;
            this.isDisponible = isDisponible;
            this.fechaModificacion = fechaModificacion;
            this.fechaEliminacion = fechaEliminacion;
        }

        public Oferta()
        {
        }

        public int IdOferta { get => idOferta; set => idOferta = value; }
        public Rubro Rubro { get => rubro; set => rubro = value; }
        public Local Local { get => local; set => local = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public int CodigoOferta { get => codigoOferta; set => codigoOferta = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFinalizacion { get => fechaFinalizacion; set => fechaFinalizacion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int IsVisible { get => isVisible; set => isVisible = value; }
        public string TituloOferta { get => tituloOferta; set => tituloOferta = value; }
        public string DescripcionOferta { get => descripcionOferta; set => descripcionOferta = value; }
        public string Condiciones { get => condiciones; set => condiciones = value; }
        public int IsDisponible { get => isDisponible; set => isDisponible = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public DateTime FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }
        public int Visitas { get => visitas; set => visitas = value; }
    }
}
