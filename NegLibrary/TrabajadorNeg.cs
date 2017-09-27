
using DAOLibrary;
using EntityLibrary;
using System;
using BusinessLibrary;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace NegLibrary
{
    public class TrabajadorNeg
    {
        private List<Trabajador> trabajadores;
        private List<Object> localesObject = new List<Object>();
        DAOTrabajador DaoTrabajador;
        public TrabajadorNeg()
        {
            if (trabajadores == null)
                trabajadores = new List<Trabajador>();
            if (DaoTrabajador == null)
                DaoTrabajador = new DAOTrabajador();


        }
                

        public List<Trabajador> listarTrabajadores()
        {
            return DaoTrabajador.listarTrabajadores();
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

        public Boolean RegistrarTrabajador(Local local, Perfil perfil, Trabajador trab)
        {
            List<Trabajador> trabajadores = new List<Trabajador>();
            trabajadores.Add(trab);
            return DaoTrabajador.RegistrarTrabajador(trab);
        }

        public Boolean EliminarTrabajadores(Trabajador trabajador)
        {
            return DaoTrabajador.EliminarTrabajador(trabajador);
        }
    }
}
