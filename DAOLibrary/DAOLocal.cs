using ConxionLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLibrary
{
    public class DAOLocal
    {
        private Conexion cone;
        private List<Local> locales = new List<Local>();
        public DAOLocal()
        {
            cone = new Conexion();
        }


    }
}
