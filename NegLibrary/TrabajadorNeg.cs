
using DAOLibrary;
using EntityLibrary;
using System;

namespace NegLibrary
{
    public class TrabajadorNeg
    {
        Coleccion coleccion;

        public TrabajadorNeg()
        {
            if (coleccion == null)
            {
                coleccion = new Coleccion();
            }
        }
        public long validarCredenciales(String usuario, String contrasena)
        {
            Trabajador trabajador = new Trabajador();
            trabajador.NombreUsuario = usuario;
            trabajador.Contrasena = contrasena;
            DAOTrabajador daoTrabajador = new DAOTrabajador();
            trabajador = daoTrabajador.validarTrabajador(trabajador);
            if (trabajador != null)
            {
                return trabajador.Perfil.IdPerfil;
            }
            else
            {
                return 0;
            }
        }
    }
}
