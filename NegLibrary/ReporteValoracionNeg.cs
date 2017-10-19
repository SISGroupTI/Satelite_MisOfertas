using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class ReporteValoracionNeg
    {
        DAOReporteValoracion reporteValoracionDao;
        public ReporteValoracionNeg()
        {
            if (reporteValoracionDao == null)
                reporteValoracionDao = new DAOReporteValoracion();

        }

        public List<ReporteValoracion> listaRegistrosReporteValoracion(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return reporteValoracionDao.listaRegistroValoracion(fechaInicio, fechaFin);
        }
    }
}
