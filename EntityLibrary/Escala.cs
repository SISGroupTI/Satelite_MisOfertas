using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Escala
    {
        private int idEscala;
        private String nota;

        public Escala()
        {

        }

        public Escala(int idEscala, String nota)
        {
            this.idEscala = idEscala;
            this.nota = nota;
        }

        public int IdEscala { get => idEscala; set => idEscala = value; }
        public String Nota { get => nota; set => nota = value; }
    }
}
