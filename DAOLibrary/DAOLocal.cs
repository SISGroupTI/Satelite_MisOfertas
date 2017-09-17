using ConxionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLibrary
{
    public class DAOLocal
    {
        private Conexion cone;
        public DAOLocal()
        {
            cone = new Conexion();
        }
    }
}
