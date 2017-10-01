using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class EstadoNeg
    {
        DAOEstado daoEstado;
        public EstadoNeg()
        {
            if (daoEstado == null)
                daoEstado = new DAOEstado();
        }

        public List<Estado> ListarEstado() { return daoEstado.ListarEstados(); }
    }
}
