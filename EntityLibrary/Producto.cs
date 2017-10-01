using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Producto
    {
        private int idProducto;
        private Local local;
        private int codigoProducto;
        private string descripcion;
        private int precioNormal;
        private int precioOferta;
        private DateTime fechaCaducidad;
        private DateTime fechaRegistro;
        private DateTime fechaModificacion;
        private DateTime fechaEliminacion;
        private Estado estado;
        private Rubro rubro;

        public int IdProducto { get => idProducto; set => idProducto = value; }
       
        public Local Local { get => local; set => local = value; }
        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int PrecioNormal { get => precioNormal; set => precioNormal = value; }
        public int PrecioOferta { get => precioOferta; set => precioOferta = value; }
        public DateTime FechaCaducidad { get => fechaCaducidad; set => fechaCaducidad = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public DateTime FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public Rubro Rubro { get => rubro; set => rubro = value; }

        public Producto( Local local, int codigoProducto, string descripcion, int precioNormal, int precioOferta, DateTime fechaCaducidad,  Estado estado)
        {
            this.local = local;
            this.codigoProducto = codigoProducto;
            this.descripcion = descripcion;
            this.precioNormal = precioNormal;
            this.precioOferta = precioOferta;
            this.fechaCaducidad = fechaCaducidad;
            this.estado = estado;
        }

        public Producto()
        {
        }
    }
}