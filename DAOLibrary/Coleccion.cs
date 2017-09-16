using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLibrary;


namespace DAOLibrary
{
    public class Coleccion
    {
        private Trabajador[] trabajadores;
        private Trabajador encargado, administrador, gerente;
        
        public Coleccion()
        {
            if (Trabajadores == null)
            {
                Trabajadores = new Trabajador[3];
                setTrabajadores();
                trabajadores[0]=encargado;
                trabajadores[1]=administrador;
                trabajadores[2]=gerente;
            }
        }

        public Trabajador[] Trabajadores { get => trabajadores; set => trabajadores = value; }

        private void setTrabajadores()
        {
            encargado = new Trabajador();
            encargado.NombreUsuario = "al.cardenas";
            encargado.Contrasena = "lamoda";
            encargado.Perfil= new Perfil(3,"encargada");
            administrador = new Trabajador();
            administrador.NombreUsuario = "so.braumuller";
            administrador.Contrasena = "lachora";
            administrador.Perfil = new Perfil(2, "administradora");
            gerente = new Trabajador();
            gerente.NombreUsuario = "ia.cardenas";
            gerente.Contrasena = "4961.qwas";
            gerente.Perfil = new Perfil(1, "gerente");
        }

        public long compararLista(String p_usuario, String p_contrasena)
        {
            for (int i = 0; i <trabajadores.Length; i++)
            {
                String usuario = trabajadores[i].NombreUsuario;
                String contrasena = trabajadores[i].Contrasena;
                if (usuario.Equals(p_usuario) && contrasena.Equals(p_contrasena))
                {
                    return trabajadores[i].Perfil.IdPerfil;
                }
            }
            return 0;
        }
    }

}
