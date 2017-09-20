using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class LocalNeg
    {
        private List<Local> locales;
        private List<Object> localesObject = new List<Object>();
        public LocalNeg()
        {
            if (locales == null)
                locales = new List<Local>();
        }

        public List<Local> Locales { get => locales; set => locales = value; }
        public List<object> LocalesObject { get => localesObject; set => localesObject = value; }

        /*
        * Este metodo tiene como funcion guardar en la lista
        * los locales que se vayan agregando desde la visual
        * cabe destacar que esta es solo una lista local
        */
        public Boolean GuardarLocalList(int numeroLocal, String direccion)
        {
            try
            {
                Local local = new Local(numeroLocal, direccion);
                locales.Add(local);
                localesObject.Add(local);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
