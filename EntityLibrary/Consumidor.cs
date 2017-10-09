using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Consumidor
    {
        private int idConsumidor;
        private int rut;
        private char dv;
        private String nombre;
        private String apellidos;
        private String correo;
        private String contrasena;
        private int recibeOferta;
        private DateTime fechaRegistro;
        private DateTime fechaEliminacion;
        private int is_activo;

        public Consumidor()
        {

        }

        public Consumidor(int idConsumidor, int rut, char dv, String nombre, String apellidos, String correo,
            String contrasena, int recibeOferta, DateTime fechaRegistro, DateTime fechaEliminacion, int is_activo)
        {
            this.idConsumidor = idConsumidor;
            this.rut = rut;
            this.dv = dv;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.correo = correo;
            this.contrasena = contrasena;
            this.recibeOferta = recibeOferta;
            this.fechaRegistro = fechaRegistro;
            this.fechaEliminacion = fechaEliminacion;
            this.is_activo = is_activo;

        }

        public int IdConsumidor{ get => idConsumidor; set => idConsumidor = value; }
        public int Rut { get => rut; set => rut = value; }
        public char Dv { get => dv; set => dv = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos;set=>apellidos=value; }
        public String Correo { get => correo; set => correo = value; }
        public String Contrasena { get => contrasena; set => contrasena = value; }
        public int RecibeOferta { get => recibeOferta; set => recibeOferta = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }
        public int IsActivo { get => is_activo; set => is_activo = value; }
            



    }
}
