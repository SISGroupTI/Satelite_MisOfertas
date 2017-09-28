using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Producto
    {
        private int idProducto;
        private Estado estado;
        private Local local;
        private int codigoProducto;
        private string descripcion;
        private int precioNormal;
        private int precioOferta;
        private DateTime fechaCaducidad;
        private DateTime fechaRegistro;
        private DateTime fechaModificacion;
        private DateTime fechaEliminacion;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public Local Local { get => local; set => local = value; }
        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int PrecioNormal { get => precioNormal; set => precioNormal = value; }
        public int PrecioOferta { get => precioOferta; set => precioOferta = value; }
        public DateTime FechaCaducidad { get => fechaCaducidad; set => fechaCaducidad = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public DateTime FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }

        public Producto()
        {
        }

        public Producto(int idProducto, Estado estado, Local local, int codigoProducto, string descripcion, int precioNormal, int precioOferta, DateTime fechaCaducidad, DateTime fechaRegistro, DateTime fechaModificacion, DateTime fechaEliminacion)
        {
            this.IdProducto = idProducto;
            this.Estado = estado;
            this.Local = local;
            this.CodigoProducto = codigoProducto;
            this.Descripcion = descripcion;
            this.PrecioNormal = precioNormal;
            this.PrecioOferta = precioOferta;
            this.FechaCaducidad = fechaCaducidad;
            this.FechaRegistro = fechaRegistro;
            this.FechaModificacion = fechaModificacion;
            this.FechaEliminacion = fechaEliminacion;

        }

        public Producto(Local local, int codigo, string descripcion, int precioNormal, int precioOferta, Estado es, DateTime fechaCaducidad)
        {
            this.Local = local;
            this.CodigoProducto = codigo;
            this.descripcion = descripcion;
            this.precioNormal = precioNormal;
            this.precioOferta = precioOferta;
            this.Estado = es;
            this.fechaCaducidad = fechaCaducidad;
        }
    }
}
