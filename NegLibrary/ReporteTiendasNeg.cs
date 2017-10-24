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

        public List<ReporteTiendas> listaConsumidoresRegistradosDia(DateTime? fechaInicioRegistro, DateTime? fechaTerminoRegistro)
        {
            return reporteTiendasDao.listaConsumidoresRegistradosDia(fechaInicioRegistro, fechaTerminoRegistro);
        }

        public List<ReporteTiendas> listaConsumidoresRegistradosMes(DateTime? fechaInicioRegistro, DateTime? fechaTerminoRegistro)
        {
            return reporteTiendasDao.listaConsumidoresRegistradosMes(fechaInicioRegistro, fechaTerminoRegistro);
        }

        public List<ValoracionOferta> listaValoracionesPorEmpresa()
        {
            return reporteTiendasDao.listaValoracionesPorEmpresa();
        }

        public List<Rubro> listaCuponesGeneradosPorRubro()
        {
            return reporteTiendasDao.listaCuponesGeneradosPorRubro();
        }
    }
}
