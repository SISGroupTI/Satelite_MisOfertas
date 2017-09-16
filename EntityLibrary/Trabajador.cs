// File:    Trabajador.cs
// Author:  Ian Cardenas
// Created: miércoles, 6 de septiembre de 2017 13:43:07
// Purpose: Definition of Class Trabajador

using System;
namespace EntityLibrary
{
    public class Trabajador
    {
        private long idTrabajador;
        private String nombreUsuario;
        private int rut;
        private String dv;
        private String nombre;
        private String apellidos;
        private String correoCorporativo;
        private DateTime fechaIngreso;
        private DateTime fechaModificacion;
        private int fechaEliminacion;
        private String contrasena;
        private short isActivo;
        private Perfil perfil;

        public long IdTrabajador { get => idTrabajador; set => idTrabajador = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public int Rut { get => rut; set => rut = value; }
        public string Dv { get => dv; set => dv = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string CorreoCorporativo { get => correoCorporativo; set => correoCorporativo = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public int FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public short IsActivo { get => isActivo; set => isActivo = value; }
        public Perfil Perfil { get => perfil; set => perfil = value; }

        public Trabajador()
        {
        }

        public Trabajador(long idTrabajador, string nombreUsuario, int rut, string dv, string nombre, string apellidos, string correoCorporativo, DateTime fechaIngreso, DateTime fechaModificacion, int fechaEliminacion, string contrasena, short isActivo, Perfil perfil)
        {
            this.idTrabajador = idTrabajador;
            this.nombreUsuario = nombreUsuario;
            this.rut = rut;
            this.dv = dv;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.correoCorporativo = correoCorporativo;
            this.fechaIngreso = fechaIngreso;
            this.fechaModificacion = fechaModificacion;
            this.fechaEliminacion = fechaEliminacion;
            this.contrasena = contrasena;
            this.isActivo = isActivo;
            this.perfil = perfil;
        }
    }
}
