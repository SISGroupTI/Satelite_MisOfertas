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
            encargado.Nombre_usuario = "al.cardenas";
            encargado.Contrasena = "lamoda";
            encargado.Id_perfil = 3;
            administrador = new Trabajador();
            administrador.Nombre_usuario = "so.braumuller";
            administrador.Contrasena = "lachora";
            administrador.Id_perfil = 2;
            gerente = new Trabajador();
            gerente.Nombre_usuario = "ia.cardenas";
            gerente.Contrasena = "4961.qwas";
            gerente.Id_perfil = 1;
        }

        public int compararLista(String p_usuario, String p_contrasena)
        {
            for (int i = 0; i <trabajadores.Length; i++)
            {
                String usuario = trabajadores[i].Nombre_usuario;
                String contrasena = trabajadores[i].Contrasena;
                if (usuario.Equals(p_usuario) && contrasena.Equals(p_contrasena))
                {
                    return trabajadores[i].Id_perfil;
                }
            }
            return 0;
        }
    }

}
