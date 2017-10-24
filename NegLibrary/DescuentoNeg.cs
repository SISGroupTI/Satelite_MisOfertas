using EntityLibrary;
using BusinessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class DescuentoNeg
    {
        DAODescuento DaoDescuento;

        public DescuentoNeg()
        {
            if (DaoDescuento == null)
                DaoDescuento = new DAODescuento();
        }

        public List<Descuento> listarDescuento()
        {
            return DaoDescuento.listarDescuentos();
        }

    }
}
