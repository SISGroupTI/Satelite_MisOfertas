using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class DetalleOfertaNeg
    {
        DAODetalleOferta daoDetalleOferta;
        DetalleOferta detalleOferta;
        List<DetalleOferta> detalleOfertasList = new List<DetalleOferta>();
        public DetalleOfertaNeg()
        {
            if (daoDetalleOferta == null)
                daoDetalleOferta = new DAODetalleOferta();
        }

        public List<DetalleOferta> DetalleOfertasList { get => detalleOfertasList; set => detalleOfertasList = value; }
        public Boolean AgregarDetalleList(Producto producto,int minimo,int maximo)
        {
            try
            {
                DetalleOferta detalleOferta = new DetalleOferta();
                detalleOferta.Producto = producto;
                detalleOferta.CantidadMinima = minimo;
                detalleOferta.CantidadMaxima = maximo;
                detalleOfertasList.Add(detalleOferta);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public Boolean EliminarDetalleList(DetalleOferta detalleOferta)
        {
            foreach (DetalleOferta detalle in DetalleOfertasList)
            {
                if (detalleOferta.Equals(detalle))
                {
                    DetalleOfertasList.Remove(detalle);
                    return true;
                }
            }
            return false;
        }
        public Boolean AsignarOfertaADetalles(Oferta ofe)
        {
            List<DetalleOferta> aux = new List<DetalleOferta>();
            foreach (DetalleOferta detalle in detalleOfertasList)
            {
                detalle.Oferta = ofe;
                aux.Add(detalle);
            }
            DetalleOfertasList = aux;
            return true;
        }
        public Boolean RegistrarDetalle(List<DetalleOferta> lista)
        {
            return daoDetalleOferta.RegistrarDetalleOferta(lista);
        }
        public List<DetalleOferta> BuscarDetalleOferta(Oferta oferta)
        {
            return daoDetalleOferta.BuscarDetalleOferta(oferta);
        }
        public bool RegistrarDetalle(Producto producto, int minimo, int maximo, Oferta oferta)
        {
            DetalleOferta detalleOferta = new DetalleOferta();
            detalleOferta.Producto = producto;
            detalleOferta.CantidadMinima = minimo;
            detalleOferta.CantidadMaxima = maximo;
            detalleOferta.Oferta = oferta;
            List<DetalleOferta> lista = new List<DetalleOferta>();
            DetalleOfertasList.Add(detalleOferta);
            lista.Add(detalleOferta);
            return daoDetalleOferta.RegistrarDetalleOferta(lista);
        }
        public bool EliminarDetalle(DetalleOferta detalle)
        {
            return daoDetalleOferta.EliminarDetalle(detalle);
        }
    }
}
