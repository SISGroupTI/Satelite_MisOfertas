using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    

    public class ImagenOferta
    {
        public String rutaimagen;
        public int is_principal;
        public Oferta oferta;

        public int Is_principal { get => is_principal; set => is_principal = value; }
        public String Imagen { get => rutaimagen; set=> rutaimagen = value; }

        public Oferta Oferta { get => oferta; set => oferta = value; }

        public ImagenOferta() { }

        public ImagenOferta(String rutaimagen, int is_principal, Oferta oferta){
            this.rutaimagen = rutaimagen;
            this.is_principal = is_principal;
            this.oferta = oferta;
        }


    }
}
