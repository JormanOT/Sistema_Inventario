/*
Diseño en Capas, Capa Entidad
Capa donde estan los objetos 
utilizado a nivel de sistema.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
namespace Bitesoft.System.ET
{
    public class EInventario
    {
        /// <summary>
        /// Atributos privados de la clase EInventario.
        /// </summary>
        private static string codigo;
        private static string material;
        private static string existencia;
        private static string umd;
        private static double costo;
        private static double precio;
        private static string id;

        /// <summary>
        /// Propiedades para acceder a los atributos privados de la clase.
        /// </summary>
        public static double Precio { get { return precio; } set { precio = value; } }
        public static string Codigo { get { return codigo; } set{ codigo = value; } }
        public static string Material { get { return material; } set { material = value; } }
        public static string Existencia { get { return existencia; } set { existencia = value; } }
        public static string UMD { get { return umd; } set { umd = value; } }
        public static double Costo { get { return costo; } set { costo = value; } }
        public static string ID { get { return id; } set { id = value; } }

        /// <summary>
        /// Destructor que vacia los atributo una vez ya dejen de ser utilizados.
        /// </summary>
        ~EInventario()
        {
            codigo = string.Empty;
            material = string.Empty;
            existencia = string.Empty;
            umd = string.Empty;
            costo = 0.00;
            id = string.Empty;
        }
    }
}
