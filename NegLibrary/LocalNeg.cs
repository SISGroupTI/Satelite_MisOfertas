using BusinessLibrary;
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
        DAOLocal daoLocal;
        public LocalNeg()
        {
            if (locales == null)
                locales = new List<Local>();
            if (daoLocal == null)
                daoLocal = new DAOLocal();
        }

        public List<Local> Locales { get => locales; set => locales = value; }

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
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public Boolean RegistraLocal(Empresa empresa, Local local)
        {
            return true;
        }

        public List<Local> ListarLocalesIdEmpresa(Empresa empresa)
        {
            return daoLocal.listarLocalIdEmpresa(empresa);
        }
    }
}
