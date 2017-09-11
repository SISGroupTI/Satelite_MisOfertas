namespace EntityLibrary
{
    public class Trabajador
    {
        private int _id_trabajador;
        private int _id_perfil;
        private int _id_local;
        private string _nombre_usuario;
        private int _rut;
        private char[] _dv;
        private string _nombre;
        private string _apellidos;
        private string _contrasena;

        public int Id_trabajador { get => _id_trabajador; set => _id_trabajador = value; }
        public int Id_perfil { get => _id_perfil; set => _id_perfil = value; }
        public int Id_local { get => _id_local; set => _id_local = value; }
        public string Nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
        public int Rut { get => _rut; set => _rut = value; }
        public char[] Dv { get => _dv; set => _dv = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }

        public Trabajador()
        {
        }
    }
}