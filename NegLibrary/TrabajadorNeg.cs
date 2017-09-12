using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOLibrary;
using EntityLibrary;
namespace NegLibrary
{
    public class TrabajadorNeg
    {
        Coleccion coleccion;
        
        public TrabajadorNeg()
        {
            if (coleccion==null)
            {
                coleccion = new Coleccion();
            }
        }
        public int validarCredenciales(String usuario, String contrasena)
        {
            return coleccion.compararLista(usuario, contrasena);
        }
    }
}
