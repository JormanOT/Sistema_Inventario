/*- 
Diseño en Capas, Capa de Datos
Esta Capa se comunica directamente 
Con la Base de datos para añadir
Registros, Eliminarlo, Modificarlo.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitesoft.System.DT;
using Bitesoft.System.ET;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace Bitesoft.System.DT
{
    public class Usuarios
    {
        /// <summary>
        /// Cadena de conexion a la base de datos local.
        /// </summary>
        static EConexion _Conexion = new EConexion("SQL");
        static SqlConnection Conexion = new SqlConnection();

        /// <summary>
        /// Metodo que registra los datos del usuario a la base de datos.
        /// </summary>
        public static void Registrar()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Usuario_Registrar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@1", SqlDbType.Char,55).Value = EUsuarios.Usuario;
                    cmd.Parameters.Add("@2", SqlDbType.Char, 55).Value = EUsuarios.Contraseña;
                    cmd.Parameters.Add("@3", SqlDbType.Char, 55).Value = EUsuarios.Nombre;
                    cmd.Parameters.Add("@4", SqlDbType.Char, 55).Value = EUsuarios.Apellido;
                    cmd.Parameters.Add("@5", SqlDbType.Char, 55).Value = EUsuarios.Cargo;
                    cmd.Parameters.Add("@6", SqlDbType.Char, 55).Value = EUsuarios.Almacen;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Usuarios/Registrar");
            }
        }

        /// <summary>
        /// Metodo que edita los datos del usuario de la base de datos.
        /// </summary>
        public static void Editar()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Usuario_Editar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@1", SqlDbType.Char, 55).Value = EUsuarios.Usuario;
                    cmd.Parameters.Add("@2", SqlDbType.Char, 55).Value = EUsuarios.Contraseña;
                    cmd.Parameters.Add("@3", SqlDbType.Char, 55).Value = EUsuarios.Nombre;
                    cmd.Parameters.Add("@4", SqlDbType.Char, 55).Value = EUsuarios.Apellido;
                    cmd.Parameters.Add("@5", SqlDbType.Char, 55).Value = EUsuarios.Cargo;
                    cmd.Parameters.Add("@6", SqlDbType.Char, 55).Value = EUsuarios.Almacen;
                    cmd.Parameters.Add("@id", SqlDbType.Char,55).Value = EUsuarios.ID;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Usuarios/Editar");
            }
        }
        /// <summary>
        /// Metodo que valida el usuario exista en la base de datos.
        /// </summary>
        /// <returns></returns>
        public static DataTable Validar()
        {
            DataTable dt = new DataTable();
            try
            {
                Conexion.ConnectionString = _Conexion.Conexion;
                Conexion.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "Usuario_Validar";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conexion;
                Cmd.Parameters.Add("@Usuario", SqlDbType.Char, 50).Value = EUsuarios.Usuario;
                using (SqlDataAdapter adapter = new SqlDataAdapter(Cmd))
                {
                    adapter.Fill(dt);
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Usuarios/Validar");
            }
            return dt;
        }
        /// <summary>
        /// Metodo que busca al usuario en la base de datos y vacial sus dato en la entidad.
        /// </summary>
        public static void Buscar()
        {
            try
            {
                Conexion.ConnectionString = _Conexion.Conexion;
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Usuario_Buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                cmd.Parameters.Add("@Usuario", SqlDbType.Char, 55).Value = EUsuarios.Usuario;
                SqlDataReader Lector;
                Lector = cmd.ExecuteReader();
                while (Lector.Read())
                {
                    EUsuarios.Usuario = Lector["Usuario"].ToString();
                    EUsuarios.Contraseña = Lector["Contraseña"].ToString();
                    EUsuarios.Nombre = Lector["Nombre"].ToString();
                    EUsuarios.Apellido = Lector["Apellido"].ToString();
                    EUsuarios.Cargo = Lector["Cargo"].ToString();
                    EUsuarios.Almacen = Lector["Almacen"].ToString();
                    EUsuarios.ID = Lector["id"].ToString();
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Usuarios/Buscar");
            }
        }

        /// <summary>
        /// Metodo que vacia en una lista los usuario encontrados en la base de datos.
        /// </summary>
        /// <param name="Box"></param>
        public static void Listar_Usuarios(ComboBox Box)
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Listar_Usuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                SqlDataReader Lector;
                Lector = cmd.ExecuteReader();
                while(Lector.Read())
                {
                    Box.Items.Add(Lector["Usuario"].ToString());
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Usuarios/Listar_Usuarios");
            }
        }
    }
}
