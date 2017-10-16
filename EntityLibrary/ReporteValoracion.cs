using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class ReporteValoracion
    {
        private Oferta oferta;
        private Rubro rubro;
        private Local local;
        private Empresa empresa;
        private int cant_valoraciones_negativas;
        private int cant_valoraciones_medias;
        private int cant_valoraciones_positivas;
        private int cant_valoraciones_total;
        private int cant_productos;
        private int cant_imagenes;

        public ReporteValoracion()
        {

        }

        public Oferta Oferta { get => oferta; set => oferta = value; }
        public Rubro Rubro { get => rubro; set => rubro = value; }
        public Local Local { get => local; set => local = value; }
        public Empresa Empresa { get => empresa; set => empresa = value; }
        public int CantValoracionNegativas { get => cant_valoraciones_negativas; set => cant_valoraciones_negativas = value; }
        public int CantValoracionMedia { get => cant_valoraciones_medias; set => cant_valoraciones_medias = value; }
        public int CantValoracionPositiva { get => cant_valoraciones_positivas; set => cant_valoraciones_positivas = value; }
        public int CantValoracionTotal { get => cant_valoraciones_total; set => cant_valoraciones_total = value; }
        public int CantProductos { get => cant_productos; set => cant_productos = value; }
        public int CantImagenes { get => cant_imagenes; set => cant_imagenes = value; }

        
    }
}

