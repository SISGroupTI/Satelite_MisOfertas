using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class ReporteTiendasNeg
    {
        DAOReporteTiendas reporteTiendasDao;
        public ReporteTiendasNeg()
        {
            if (reporteTiendasDao == null)
                reporteTiendasDao = new DAOReporteTiendas();
        }

        public List<ReporteTiendas> listaConsumidoresRegistradosDia()
        {
            return reporteTiendasDao.listaConsumidoresRegistradosDia();
        }

        public List<ReporteTiendas> listaConsumidoresRegistradosMes()
        {
            return reporteTiendasDao.listaConsumidoresRegistradosMes();
        }
    }
}
