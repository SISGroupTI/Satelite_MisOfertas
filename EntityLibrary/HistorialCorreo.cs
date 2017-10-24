using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class HistorialCorreo
    {
        private int idHistorialCorreo;
        private DateTime fechaEnvio;
        private int cantCorreosEnviados;

        private Oferta oferta;
        private Consumidor consumidor;

        public HistorialCorreo()
        {

        }

        public int IdHistorialCorreo { get => idHistorialCorreo; set => idHistorialCorreo = value; }
        public DateTime FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public int CantCorreosEnviados { get => cantCorreosEnviados; set => cantCorreosEnviados = value; }
        public Oferta Oferta { get => oferta; set => oferta = value; }
        public Consumidor Consumidor { get => consumidor; set => consumidor = value; }

    }
}

