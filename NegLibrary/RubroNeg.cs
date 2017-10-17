using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class RubroNeg
    {
        DAORubro daoRubro;
        public RubroNeg()
        {
            daoRubro = new DAORubro();
        }

        public List<Rubro> ListarRubro()
        {
            return daoRubro.ListarRubros();
        }

        public List<Rubro> listarRubrosMasVisitados()
        {
            return daoRubro.listarRubrosMasVisitados();
        }
    }
}
