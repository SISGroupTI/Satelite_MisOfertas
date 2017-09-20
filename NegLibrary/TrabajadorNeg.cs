
using DAOLibrary;
using EntityLibrary;
using System;

namespace NegLibrary
{
    public class TrabajadorNeg
    {
 
        public TrabajadorNeg()
        {
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
                //Devuelve el perfil del trabajador para la validacion del 
                //LoginWindows.xaml.cs
                return trabajador.Perfil.IdPerfil;
            }
            else
            {
                return 0;
            }
        }
    }
}
