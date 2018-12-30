/*
Diseño en Capas, Capa Entidad
Capa donde estan los objetos 
utilizado a nivel de sistema.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
namespace Bitesoft.System.ET
{
    public class EMovimientos
    {
        /// <summary>
        /// Atributos privados de la clase EMovimientos.
        /// </summary>
        private static string movimiento;
        private static string material;
        private static string codigo;
        private static string documento;
        private static string descripcion;
        private static string cantidad;
        private static string fecha;
        private static string usuario;
        private static string mes;
        private static string año;

        /// <summary>
        /// Propiedades para acceder a los atributos privados de la clase.
        /// </summary>
        public static string Material { get { return material; } set { material = value; } }
        public static string Movimiento { get { return movimiento; } set { movimiento = value; } }
        public static string Codigo { get { return codigo; } set { codigo = value; } }
        public static string Documento { get { return documento; } set { documento = value; } }
        public static string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public static string Cantidad { get { return cantidad; } set { cantidad = value; } }
        public static string Fecha { get { return fecha; } set { fecha = value; } }
        public static string Usuario { get { return usuario; } set { usuario = value; } }
        public static string Mes { get { return mes; } set { mes = value; } }
        public static string Año { get { return año; } set { año = value; } }

        /// <summary>
        /// Destructor que vacia los atributo una vez ya dejen de ser utilizados.
        /// </summary>
        ~EMovimientos()
        {
            movimiento = string.Empty;
            codigo = string.Empty;
            documento = string.Empty;
            descripcion = string.Empty;
            cantidad = string.Empty;
            fecha = string.Empty;
            usuario = string.Empty;
            mes = string.Empty;
            año = string.Empty;
        }
    }
}
