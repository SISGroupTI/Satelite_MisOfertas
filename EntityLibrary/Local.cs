using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary
{
    public class Local
    {
        private int idLocal;
        private Empresa empresa;
        private int numeroLocal;
        private String direccion;
        private DateTime fechaRegistro;
        private DateTime fechaEliminacion;

        public int IdLocal { get => idLocal; set => idLocal = value; }
        public Empresa Empresa { get => empresa; set => empresa = value; }
        public int NumeroLocal { get => numeroLocal; set => numeroLocal = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }

        public Local(int idLocal, Empresa empresa, int numeroLocal, string direccion, DateTime fechaRegistro, DateTime fechaEliminacion)
        {
            this.idLocal = idLocal;
            this.empresa = empresa;
            this.numeroLocal = numeroLocal;
            this.direccion = direccion;
            this.fechaRegistro = fechaRegistro;
            this.fechaEliminacion = fechaEliminacion;
        }

        public Local()
        {
        }

    }
}
