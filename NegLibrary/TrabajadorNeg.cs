
using DAOLibrary;
using EntityLibrary;
using System;
using Helpers;
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
        DAOTrabajador daoTrabajador;
        public TrabajadorNeg()
        {
            if (trabajadores == null)
                trabajadores = new List<Trabajador>();
            if (daoTrabajador == null)
                daoTrabajador = new DAOTrabajador();


        }
                

        public List<Trabajador> listarTrabajadores()
        {
            return daoTrabajador.ListarTrabajadores();
        }

        public Trabajador validarCredenciales(String usuario, String contrasena)
        {
            Trabajador trabajador = new Trabajador();
            trabajador.NombreUsuario = usuario;
            DAOTrabajador daoTrabajador = new DAOTrabajador();
            trabajador = daoTrabajador.validarTrabajador(trabajador);
            if (trabajador != null)
            {
                if (PasswordStorage.VerifyPassword(contrasena,trabajador.Contrasena))
                {
                    try
                    {
                        return trabajador;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Boolean RegistrarTrabajador(Local local, Perfil perfil, Trabajador trab)
        {
            trab.Local = local;
            trab.Perfil = perfil;
            return daoTrabajador.RegistrarTrabajador(trab);
        }

        public Boolean EliminarTrabajadores(Trabajador trabajador)
        {
            return daoTrabajador.EliminarTrabajador(trabajador);
        }

        public bool ModificarTrabajador(Local local, Perfil perfil, Trabajador trabajador)
        {
            trabajador.Local = local;
            trabajador.Perfil = perfil;
            return daoTrabajador.ModificarTrabajador(trabajador);
        }

        public int cantidadTotalTrabajadores()
        {
            return daoTrabajador.cantidadTotalTrabajadores();
        }
    }
}
