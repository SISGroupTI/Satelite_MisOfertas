using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class HistorialCorreoNeg
    {
        DAOHistorialCorreo historialCorreoDao;

        public HistorialCorreoNeg()
        {
            if (historialCorreoDao == null)
                historialCorreoDao = new DAOHistorialCorreo();
        }

        public List<HistorialCorreo> listarCantCorreosEnviados()
        {
            return historialCorreoDao.listaCantidadCorreosEnviados();
        }
    }
}
