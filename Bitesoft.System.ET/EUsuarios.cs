/*
Diseño en Capas, Capa Entidad
Capa donde estan los objetos 
utilizado a nivel de sistema.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
namespace Bitesoft.System.ET
{
    public class EUsuarios
    {
        /// <summary>
        /// Atributos privados de la clase EMovimientos.
        /// </summary>
        private static string id;
        private static string usuario;
        private static string contraseña;
        private static string nombre;
        private static string apellido;
        private static string cargo;
        private static string almacen;

        /// <summary>
        /// Propiedades para acceder a los atributos privados de la clase.
        /// </summary>
        public static string ID { get { return id; } set { id = value; } }
        public static string Usuario { get { return usuario; } set { usuario = value; } }
        public static string Contraseña { get { return contraseña; } set { contraseña = value; } }
        public static string Nombre { get { return nombre; } set { nombre = value; } }
        public static string Apellido { get { return apellido; } set { apellido = value; } }
        public static string Cargo { get { return cargo; } set { cargo = value; } }
        public static string Almacen { get { return almacen; } set { almacen = value; } }

        /// <summary>
        /// Destructor que vacia los atributo una vez ya dejen de ser utilizados.
        /// </summary>
        ~EUsuarios()
        {
            id = string.Empty;
            usuario = string.Empty;
            contraseña = string.Empty;
            nombre = string.Empty;
            apellido = string.Empty;
            cargo = string.Empty;
            almacen = string.Empty;
        }
    }
}
