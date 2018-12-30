/*
Diseño en Capas, Capa Logica
esta capa se comunica con la
capa de datos y con la interfaz.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using Bitesoft.System.DT;
using Bitesoft.System.ET;
using System.Windows.Forms;
namespace Bitesoft.System.LG
{
    public class LUsuario
    {
        /// <summary>
        /// Metodo que recibe los datos del usuario para ser registrado en la base de datos.
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pContraseña"></param>
        /// <param name="pNombre"></param>
        /// <param name="pApellido"></param>
        /// <param name="pCargo"></param>
        /// <param name="pAlmacen"></param>
        public static void Registrar(string pUsuario,string pContraseña,string pNombre,string pApellido, string pCargo,string pAlmacen)
        {
            if(pUsuario == string.Empty) { EMensaje.Informacion("Indique su C.I para el usuario","Informacion"); }
            if (pContraseña == string.Empty) { EMensaje.Informacion("Indique su Contraseña", "Informacion"); }
            if (pNombre == string.Empty) { EMensaje.Informacion("Indique su Nombre", "Informacion"); }
            if (pApellido == string.Empty) { EMensaje.Informacion("Indique su Apellido", "Informacion"); }
            if (pCargo == string.Empty) { EMensaje.Informacion("Indique su Cargo", "Informacion"); }
            if (pAlmacen == string.Empty) { EMensaje.Informacion("Indique su Almacen", "Informacion"); }
            {
                EUsuarios.Usuario = pUsuario;
                EUsuarios.Contraseña = pContraseña;
                EUsuarios.Nombre = pNombre;
                EUsuarios.Apellido = pApellido;
                EUsuarios.Cargo = pCargo;
                EUsuarios.Almacen = pAlmacen;
                Usuarios.Registrar();
                EMensaje.Informacion("Proceso Completado","Informacion");
            }
        }
        /// <summary>
        /// Metodo que recibe los datos que sera modificado segun el usuario indicado.
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pContraseña"></param>
        /// <param name="pNombre"></param>
        /// <param name="pApellido"></param>
        /// <param name="pCargo"></param>
        /// <param name="pAlmacen"></param>
        public static void Editar(string pUsuario, string pContraseña, string pNombre, string pApellido, string pCargo, string pAlmacen)
        {
            if (pUsuario == string.Empty) { EMensaje.Informacion("Indique su C.I para el usuario", "Informacion"); }
            if (pContraseña == string.Empty) { EMensaje.Informacion("Indique su Contraseña", "Informacion"); }
            if (pNombre == string.Empty) { EMensaje.Informacion("Indique su Nombre", "Informacion"); }
            if (pApellido == string.Empty) { EMensaje.Informacion("Indique su Apellido", "Informacion"); }
            if (pCargo == string.Empty) { EMensaje.Informacion("Indique su Cargo", "Informacion"); }
            if (pAlmacen == string.Empty) { EMensaje.Informacion("Indique su Almacen", "Informacion"); }
            {
                EUsuarios.Usuario = pUsuario;
                EUsuarios.Contraseña = pContraseña;
                EUsuarios.Nombre = pNombre;
                EUsuarios.Apellido = pApellido;
                EUsuarios.Cargo = pCargo;
                EUsuarios.Almacen = pAlmacen;
                Usuarios.Editar();
                EMensaje.Informacion("Proceso Completado", "Informacion");
            }
        }
        /// <summary>
        /// Metodo que valida si el usuario existe, segun el parametro recibido.
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public static bool Validar(string pUsuario)
        {
            if (pUsuario == "") { EMensaje.Informacion("Indique el C.I del Usuario", "Informacion"); }
            {
                EUsuarios.Usuario = pUsuario;

                if (Usuarios.Validar().Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Metodo que busca al usuario, segun el parametro recibido.
        /// </summary>
        /// <param name="pUsuario"></param>
        public static void Buscar(string pUsuario)
        {
            if (pUsuario == "") { EMensaje.Informacion("Indique el C.I del  a buscar", "Informacion"); }
            {
                EUsuarios.Usuario = pUsuario;
                Usuarios.Buscar();
            }
        }
        /// <summary>
        /// Metodo que carga en un combobox la lista de usuario registrados.
        /// </summary>
        /// <param name="Box"></param>
        public static void Listar_Usuarios(ComboBox Box)
        {
            Usuarios.Listar_Usuarios(Box);
            EMensaje.Informacion("Usuarios cargados, selecione en la lista","Informacion");
        }
        /// <summary>
        /// Metodo que asigna los valores a la entidad usuarios.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Usuario"></param>
        public static void Datos_Usuario(string Nombre,string Apellido,string Usuario)
        {
            EUsuarios.Nombre = Nombre;
            EUsuarios.Apellido = Apellido;
            EUsuarios.Usuario = Usuario;
        }
    }
}
