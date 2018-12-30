/*- 
Diseño en Capas, Capa de Datos
Esta Capa se comunica directamente 
Con la Base de datos para añadir
Registros, Eliminarlo, Modificarlo.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/

using System;
using Bitesoft.System.ET;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Bitesoft.System.DT
{
    public class Inventario
    {
        /// <summary>
        /// Cadena de conexion a la base de datos local.
        /// </summary>
        static EConexion _Conexion = new EConexion("SQL");
       static SqlConnection Conexion = new SqlConnection(_Conexion.Conexion);

        /// <summary>
        /// Metodo que registra en base de datos el material.
        /// </summary>
        public static void Registrar()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Inventario_Registrar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("Codigo", SqlDbType.Char,55).Value = EInventario.Codigo;
                    cmd.Parameters.Add("Material", SqlDbType.Char, 100).Value = EInventario.Material;
                    cmd.Parameters.Add("Existencia", SqlDbType.Char, 55).Value = EInventario.Existencia;
                    cmd.Parameters.Add("UMD", SqlDbType.Char, 20).Value = EInventario.UMD;
                    cmd.Parameters.Add("Costo", SqlDbType.Char, 55).Value = EInventario.Costo;
                    cmd.Parameters.Add("Precio", SqlDbType.Char, 55).Value = EInventario.Precio;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();      
            }
            catch(Exception e)
            {
                EMensaje.Error("Error : " + e,"Ruta del Error : DT/Inventario/Registrar");
            }
        }
        /// <summary>
        /// Metodo que modifica el material en la base de datos.
        /// </summary>
        public static void Modificar()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Inventario_Modificar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("Codigo", SqlDbType.Char, 55).Value = EInventario.Codigo;
                    cmd.Parameters.Add("Material", SqlDbType.Char, 100).Value = EInventario.Material;
                    cmd.Parameters.Add("Existencia", SqlDbType.Char, 55).Value = EInventario.Existencia;
                    cmd.Parameters.Add("UMD", SqlDbType.Char, 20).Value = EInventario.UMD;
                    cmd.Parameters.Add("Costo", SqlDbType.Char, 55).Value = EInventario.Costo;
                    cmd.Parameters.Add("@ID", SqlDbType.Char,55).Value = EInventario.ID;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                EMensaje.Error("Error : " + e, "Ruta del Error : DT/Inventario/Modificar");
            }
        }
        /// <summary>
        /// Metodo que elimina material de la base de datos.
        /// </summary>
        public static void Eliminar()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Inventario_Eliminar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("ID", SqlDbType.Char, 55).Value = EInventario.ID;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                EMensaje.Error("Error : " + e, "Ruta del Error : DT/Inventario/Eliminar");
            }
        }
        /// <summary>
        /// Metodo que valida si el material existen en el inventario de la base de datos.
        /// </summary>
        /// <returns></returns>
        public static DataTable Validar()
        {
            DataTable dt = new DataTable();
            try
            {
                Conexion.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "Inventario_Validar";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conexion;
                Cmd.Parameters.Add("@Codigo", SqlDbType.Char, 50).Value = EInventario.Codigo;
                using (SqlDataAdapter adapter = new SqlDataAdapter(Cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Inventario/Validar");
            }
            Conexion.Close();
            return dt;
        }
        /// <summary>
        /// Metodo que buscar el material en la base de datos, y vacia sus datos en la entidad.
        /// </summary>
        public static void Buscar()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Inventario_Buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                cmd.Parameters.Add("@Codigo", SqlDbType.Char,55).Value = EInventario.Codigo;
                SqlDataReader Lector;
                Lector = cmd.ExecuteReader();
                while(Lector.Read())
                {
                    EInventario.Codigo = Lector["Codigo"].ToString();
                    EInventario.Material = Lector["Material"].ToString();
                    EInventario.Existencia = Lector["Existencia"].ToString();
                    EInventario.UMD = Lector["UMD"].ToString();
                    EInventario.Costo =  Convert.ToDouble(Lector["Costo"].ToString());
                    EInventario.Precio = Convert.ToDouble(Lector["Precio_Venta"].ToString());
                    EInventario.ID = Lector["id_Material"].ToString();
                }
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Inventario/Buscar");
            }
            Conexion.Close();
        }
        /// <summary>
        /// Metodo que actualizar la existencia actual del material.
        /// </summary>
        /// <param name="Valor"></param>
        public static void Actualizar_Inventario(string Valor)
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = Valor;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Codigo", SqlDbType.Char, 55).Value = EInventario.Codigo;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Char, 55).Value = EInventario.Existencia;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Inventario/Actualizar_Inventario");
            }
        }  
        /// <summary>
        /// Metodo que carga todos los elementos del inventario de la base de datos a una tabla.
        /// </summary>
        /// <param name="Tabla"></param>
                 
        public static void Lote_Inventario(ListView Tabla)
        {
            try
            {
                int I = 0;
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Lote_Inventario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                SqlDataReader Lector;
                Lector = cmd.ExecuteReader();
                while(Lector.Read())
                {
                    Tabla.Items.Add(Lector["Codigo"].ToString());
                    Tabla.Items[I].SubItems.Add(Lector["Material"].ToString());
                    Tabla.Items[I].SubItems.Add(string.Format("{0:n}",Convert.ToDouble(Lector["Costo"])));
                    Tabla.Items[I].SubItems.Add(Lector["Existencia"].ToString());
                    Tabla.Items[I].SubItems.Add(Lector["UMD"].ToString());
                    I++;
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Inventario/Lote_Inventario");
            }
        }
        /// <summary>
        /// Metodo que actualiza el costo total del material.
        /// </summary>
        public static void Actualizar_Costo()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Inventario_Actualizar_Costo_Total";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Codigo", SqlDbType.Char,55).Value = EInventario.Codigo;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Inventario/Actualizar_Costo");
            }
        }
        /// <summary>
        /// Metodo que registra en la base de datos el total del material en inventario.
        /// </summary>
        public static void Registrar_Inventario_Total()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Registrar_Inventario_Total";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@1", SqlDbType.Char, 55).Value = EInventario.Codigo;
                    cmd.Parameters.Add("@2", SqlDbType.Char, 55).Value = EInventario.Existencia;
                    cmd.Parameters.Add("@3", SqlDbType.Char, 55).Value = EInventario.Costo;
                    cmd.Parameters.Add("@4", SqlDbType.Char, 55).Value = EInventario.Precio;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Inventario/Registrar_Inventario_Total");
            }
        }
        /// <summary>
        /// Metodo que actualiza el total de las entradas y salidas del material en la base de datos.
        /// </summary>
        public static void Actualizar_Inventario_Total()
        {
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Actualizar_Inventario_Total";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Codigo", SqlDbType.Char,55).Value = EInventario.Codigo;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Inventario/Actualizar_Inventario_Final");
            }
        }
    }
}
