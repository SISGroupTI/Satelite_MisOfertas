using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class ValoracionOfertaNeg
    {
        DAOValoracionOferta valoracionOfertaDao;

        public ValoracionOfertaNeg()
        {
            if (valoracionOfertaDao == null)
                valoracionOfertaDao = new DAOValoracionOferta();
        }

        public ValoracionOferta listarCantValoracionesPorOferta(int idOferta)
        {
            Oferta oferta = new Oferta();
            oferta.IdOferta = idOferta;
            ValoracionOferta valoracion = new ValoracionOferta();
            return valoracionOfertaDao.listarCantValoracionesPorOferta(oferta, valoracion);
        }
    }
}
