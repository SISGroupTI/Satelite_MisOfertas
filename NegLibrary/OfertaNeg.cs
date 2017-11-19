using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class OfertaNeg
    {
        DAOOferta daoOferta;
        Oferta oferta;

        public Oferta Oferta { get => oferta; set => oferta = value; }

        public OfertaNeg()
        {
            if (daoOferta == null)
                daoOferta = new DAOOferta();
        }

        public Oferta RegistrarOferta(String descripcion,String condiciones,Rubro rubro,Local local,Estado estado,DateTime fechaFinalizacion,DateTime fechaPublicacion,String titulo,int codigoOferta,int precio,int isVisible,int isDiponible)
        {
            Oferta oferta = new Oferta();
            oferta.CodigoOferta = codigoOferta;
            oferta.Condiciones = condiciones;
            oferta.DescripcionOferta = descripcion;
            oferta.Estado = estado;
            oferta.Local = local;
            oferta.Rubro = rubro;
            oferta.Estado = estado;
            oferta.FechaFinalizacion = fechaFinalizacion;
            oferta.FechaInicio = fechaPublicacion;
            oferta.TituloOferta = titulo;
            oferta.Precio = precio;
            oferta.IsVisible = isVisible;
            oferta.IsDisponible = isDiponible;
            return daoOferta.RegistrarOferta(oferta);
        }
        public Oferta BuscarOferta(String descripcion,String condiciones,Rubro rubro,Local local,Estado estado,DateTime fechaFinalizacion,DateTime fechaPublicacion,String titulo,int codigoOferta,int precio,int isVisible,int isDiponible)
        {
            Oferta oferta = new Oferta();
            oferta.CodigoOferta = codigoOferta;
            oferta.Condiciones = condiciones;
            oferta.DescripcionOferta = descripcion;
            oferta.Estado = estado;
            oferta.Local = local;
            oferta.Rubro = rubro;
            oferta.Estado = estado;
            oferta.FechaFinalizacion = fechaFinalizacion;
            oferta.FechaInicio = fechaPublicacion;
            oferta.TituloOferta = titulo;
            oferta.Precio = precio;
            oferta.IsVisible = isVisible;
            oferta.IsDisponible = isVisible;
            return daoOferta.BuscarOferta(oferta);
        }
        public List<Oferta> ListarOfertas() { return daoOferta.ListarOfertas(); }
        public Boolean EliminarOferta(Oferta oferta)
        {
            return daoOferta.EliminarOferta(oferta);
        }
        public Oferta ModificarOferta(String descripcion, String condiciones, Rubro rubro, Local local, Estado estado, DateTime fechaFinalizacion, DateTime fechaPublicacion, String titulo, int codigoOferta, int precio, int isDiponible)
        {
            Oferta oferta = new Oferta();
            oferta.CodigoOferta = codigoOferta;
            oferta.Condiciones = condiciones;
            oferta.DescripcionOferta = descripcion;
            oferta.Estado = estado;
            oferta.Local = local;
            oferta.Rubro = rubro;
            oferta.Estado = estado;
            oferta.FechaFinalizacion = fechaFinalizacion;
            oferta.FechaInicio = fechaPublicacion;
            oferta.TituloOferta = titulo;
            oferta.Precio = precio;
            oferta.IsDisponible = isDiponible;
            oferta.IdOferta = Oferta.IdOferta;
            return daoOferta.ModificarOferta(oferta);
        }

        public List<Oferta> listarOfertasMasVisitadas()
        {
            return daoOferta.listarOfertasMasVisitadas();
        }

        public List<Oferta> listarOfertasMasVisitadasMenuPrincipal(Oferta oferta)
        {
            return daoOferta.listarOfertasMasVisitadasMenuPrincipal(oferta);
        }

        public int cantidadTotalOfertas()
        {
            return daoOferta.cantidadTotalOfertas();
        }
        public List<OfertaBI> listaOfertasBI(DateTime? fechaCreacionInicio, DateTime? fechaCreacionTermino)
        {
            return daoOferta.listaOfertasBI(fechaCreacionInicio, fechaCreacionTermino);
        }
    }
}
