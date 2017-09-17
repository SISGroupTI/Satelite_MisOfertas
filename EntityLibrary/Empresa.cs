using System;

namespace EntityLibrary
{
    public class Empresa
    {
        private int idEmpresa;
        private int rutEmpresa;
        private char dvEmpresa;
        private string nombreEmpresa;
        private DateTime fechaIncorporacion;
        private DateTime fechaModificacion;
        private DateTime fechaEliminacion;
        private int isActivo;

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public int RutEmpresa { get => rutEmpresa; set => rutEmpresa = value; }
        public char DvEmpresa { get => dvEmpresa; set => dvEmpresa = value; }
        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public DateTime FechaIncorporacion { get => fechaIncorporacion; set => fechaIncorporacion = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public DateTime FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }

        public Empresa(int idEmpresa, int rutEmpresa, char dvEmpresa, string nombreEmpresa, DateTime fechaIncorporacion, DateTime fechaModificacion, DateTime fechaEliminacion, int isActivo)
        {
            this.IdEmpresa = idEmpresa;
            this.rutEmpresa = rutEmpresa;
            this.DvEmpresa = dvEmpresa;
            this.NombreEmpresa = nombreEmpresa;
            this.FechaIncorporacion = fechaIncorporacion;
            this.FechaModificacion = fechaModificacion;
            this.FechaEliminacion = fechaEliminacion;
            this.isActivo = isActivo;
        }

        public Empresa()
        {
        }
    }
}