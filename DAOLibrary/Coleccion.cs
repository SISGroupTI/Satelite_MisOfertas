using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLibrary;


namespace DAOLibrary
{
    class Coleccion
    {
        private List<Trabajador> trabajadores;
        private Trabajador encargado, administrador, gerente;

        private Coleccion()
        {
            if (Trabajadores == null)
            {
                Trabajadores = new List<Trabajador>();
                setTrabajadores();
                trabajadores.Add(encargado);
                trabajadores.Add(administrador);
                trabajadores.Add(gerente);
            }
        }

        public List<Trabajador> Trabajadores { get => trabajadores; set => trabajadores = value; }

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
    }
}
