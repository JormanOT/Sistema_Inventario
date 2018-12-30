/*
Diseño en Capas, Capa Entidad
Capa donde estan los objetos 
utilizado a nivel de sistema.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
namespace Bitesoft.System.ET
{
    public class EConexion
    {
        private string Motor;
        private string conexion;
        /// <summary>
        /// Contructor para decidir con que motor de dator se conectara el sistema
        /// Motores : SQL,ACCESS,ORACLE
        /// </summary>
        public EConexion(string _Motor)
        {
            Motor = _Motor;
            Conectar();
        }
        private void Conectar()
        {
            switch(Motor)
            {
                case "SQL":
                    conexion = @"Data Source=JORMAN-PC\BITESOFT;Initial Catalog=Almacen_Data;Integrated Security=True";
                    break;
                case "ORACLE":
                    /// <summary>
                    /// Conexion a base de datos ORACLE
                    /// </summary>
                    conexion = "Data Source=SYSTEM.1;Persist Security Info=True;Integrated Security=False;User ID=SYSTEM;Unicode=True";
                    break;
                case "ACCESS":
                    /// <summary>
                    /// Cadena de Conexion a base de datos ACCESS
                    /// </summary>
                    conexion = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = ./Datos/Base_Datos/Almacen_Data.accdb";
                    break;
                default:
                    conexion = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = ./Datos/Base_Datos/Almacen_Data.accdb";
                    break;
            }
        }
        /// <summary>
        /// Propiedad para acceder al atributo privado conexion.
        /// </summary>
        public  string Conexion { get { return conexion; } }
    }
}
