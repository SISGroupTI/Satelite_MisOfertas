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
                local.IsActivo = 1;
                locales.Add(local);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        /*
         * Este metodo no elimina el local de la lista
         * si no lo que hace es reemplazar el local de la lista
         * haciendo un match entre en local que entra
         * y el local existente en la lista al cual se le setea el 
         * Is activo a 0 con el fin de devolver la misma lista
         * pero con este local ya modificado
         * */
        public Boolean EliminarLocalList(Local localIn)
        {
            int idLocal = localIn.IdLocal;
            foreach (Local local in Locales)
            {
                if (local.IdLocal==idLocal)
                {
                    Locales.Remove(local);
                    local.IsActivo = 0;
                    Locales.Add(local);
                    return true;
                }
            }
            return false;
        }

        public bool EliminarLocal(Local local)
        {
            local.IsActivo = 0;
            List<Local> locales = new List<Local>();
            locales.Add(local);
            return daoLocal.EliminarLocal(locales);
        }

        public List<Local> ListarLocalesIdEmpresa(Empresa empresa)
        {
            return daoLocal.listarLocalIdEmpresa(empresa);
        }

        public Boolean EliminarLocales()
        {
            return daoLocal.EliminarLocal(Locales);
        }

        public List<Local> ListarLocales()
        {
            return daoLocal.listarLocales();
        }
        public Boolean RegistrarLocal(Local local,Empresa empresa)
        {
            List<Local> locales = new List<Local>();
            locales.Add(local);
            return daoLocal.RegistrarLocal(empresa,locales);
        }
        public Boolean ModificarLocal(Local local)
        {
            return daoLocal.ModificarLocal(local);
        }
    }
}
