using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class OfertaBI
    {
        /*
         *clase orientada al almacenamiento de los registros obtenidos desde la consulta
         * para generar el archivo csv de las ofertas que fueron accedidas por los usuarios
         **/

        private int idOferta;
        private String nombreEmpresa;
        private int numeroLocal;
        private String rubro;
        private String nombreProducto;
        private String tituloOferta;
        private int  precioOferta;
        private DateTime fechaCreacion;
        private DateTime fechaPublicacion;
        private DateTime fechaFinalizacion;
        private int cantValoracionNegativas;
        private int cantValoracionMedias;
        private int cantValoracionPositivas;
        private int cantValoracionTotal;
        private int cantVisitas;

        public OfertaBI() { }
        public int IdOferta { get => idOferta; set => idOferta = value; }
        public String NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public int NumeroLocal { get => numeroLocal; set => numeroLocal = value; }
        public String Rubro { get => rubro; set => rubro = value; }
        public String NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public String TituloOferta { get => tituloOferta; set => tituloOferta = value; }
        public int PrecioOferta { get => precioOferta; set => precioOferta = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public DateTime FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public DateTime FechaFinalizacion { get => fechaFinalizacion; set => fechaFinalizacion = value; }
        public int CantValoracionNegativas { get => cantValoracionNegativas; set => cantValoracionNegativas = value; }
        public int CantValoracionMedias { get => cantValoracionMedias; set => cantValoracionMedias = value; }
        public int CantValoracionPositivas { get => cantValoracionPositivas; set => cantValoracionPositivas = value; }
        public int CantValoracionTotal { get => cantValoracionTotal; set => cantValoracionTotal = value; }
        public int CantVisitas { get => cantVisitas; set => cantVisitas = value; }

    }
}
