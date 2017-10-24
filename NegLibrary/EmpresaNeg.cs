using BusinessLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegLibrary
{
    public class EmpresaNeg
    {
        private DAOEmpresa daoEmpresa;
        private DAOLocal daoLocal;

        public EmpresaNeg()
        {
            if (daoEmpresa == null)
                daoEmpresa = new DAOEmpresa();
            if (daoLocal == null)
                daoLocal = new DAOLocal();
        }
        /*
         * Este metodo realiza la logica del negocio para el registro de un nueva 
         * empresa con su conjunto de locales
         * 
         * Params:
         * @rut = primeros 8 digitos del rut
         * @dv = verificador del rut
         * @nombre = nombre de la empresa
         * @localNeg = objeto de LocalNeg que contiene la lista de locales
         */
        public Boolean RegistrarEmpresa(int rut,char dv,String nombre,LocalNeg localNeg)
        {
            try
            {   // Se encapsulan los datos rut, dv y nombre en su clase
                Empresa empresa = new Empresa(rut,dv,nombre);
                // Se enviar esta empresa encapsulada a RegistrarEmpresa
                Boolean registrado =daoEmpresa.RegistrarEmpresa(empresa);
                // Si el registro se realizo procede a la busqueda de la empresa antes ingresada
                if (registrado)
                {
                    if (localNeg.Locales.Count>0)
                    {
                        //Se busca la empresa y se devuelve a esta
                        empresa = daoEmpresa.BuscarEmpresaRut(empresa);
                        //Si la empresa es distinta a nula la sentencia se realizo correctamente
                        //y podemos proceder a insertar los locales
                        if (empresa != null)
                        {
                            return daoLocal.RegistrarLocal(empresa, localNeg.Locales) == true ? true : false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public List<Empresa> ListarEmpresas()
        {
            return daoEmpresa.ListarEmpresas();
        }

        public Boolean ModificarEmpresa(int rut, char dv,String nombre,int idEmpresa)
        {
            Empresa empresa = new Empresa();
            empresa.RutEmpresa = rut;
            empresa.DvEmpresa = dv;
            empresa.NombreEmpresa = nombre;
            empresa.IdEmpresa = idEmpresa;
            return daoEmpresa.ModificarEmpresa(empresa);
        }

        public Boolean EliminarEmpresa(Empresa empresa)
        {
            return daoEmpresa.EliminarEmpresa(empresa);
        }
    }
}
