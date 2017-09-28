using BusinessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class PerfilNeg
    {
        private DAOPerfil daoPerfil;
        public PerfilNeg()
        {
            if (daoPerfil == null)
                daoPerfil = new DAOPerfil();
        }
        public List<Perfil> ListarPerfiles()
        {
            return daoPerfil.ListarPerfiles();
        }
    }
}
