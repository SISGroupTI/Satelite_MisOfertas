using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class ImagenesOfertaNeg
    {
        DAOImagenesOferta imagenesOfertaDao;

        public ImagenesOfertaNeg()
        {
            if (imagenesOfertaDao == null)
                imagenesOfertaDao = new DAOImagenesOferta();
        }

        public Boolean registrarImagenesOferta(List<ImagenOferta> imagenes)
        {
            return imagenesOfertaDao.ingresarImagenesOferta(imagenes);
        }

        public List<ImagenOferta> listarImagenesOfertaPorOferta(Oferta oferta)
        {
            return imagenesOfertaDao.listarImagenesOfertaPorOferta(oferta);
        }

        public Boolean eliminarImagenesOfertaPorOferta(Oferta oferta)
        {
            return imagenesOfertaDao.eliminarImagenesOfertaPorOferta(oferta);
        }
    }
}
