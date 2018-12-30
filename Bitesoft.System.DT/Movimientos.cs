/*- 
Diseño en Capas, Capa de Datos
Esta Capa se comunica directamente 
Con la Base de datos para añadir
Registros, Eliminarlo, Modificarlo.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using System;
using System.Data;
using System.Data.OleDb;
using Bitesoft.System.ET;
using System.Windows.Forms;
namespace Bitesoft.System.DT
{
    public class Movimientos
    {
        /// <summary>
        /// Cadena de Conexion a la base de datos local.
        /// </summary>
        static EConexion _Conexion = new EConexion("ACCESS");
        static OleDbConnection Conexion = new OleDbConnection(_Conexion.Conexion);
        /// <summary>
        /// Metodo que obtiene el ultimo documento registrado.
        /// </summary>
        public static void Obtener_Documento()
        {
            try
            {
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Obtener_Documento";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                OleDbDataReader Lector;
                Lector = cmd.ExecuteReader();
                while (Lector.Read())
                {
                    EMovimientos.Documento = Lector["Documento"].ToString();
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Movimiento/Obtener_Documento");
            }
        }
        /// <summary>
        /// Metodo que registra los movimientos de entradas y salidas en la base de datos.
        /// </summary>
        public static void Registrar_Movimiento()
        {
            try
            {
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Registrar_Movimiento";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@1",OleDbType.Char,55).Value = EMovimientos.Movimiento;
                    cmd.Parameters.Add("@2", OleDbType.Char, 55).Value = EMovimientos.Codigo;
                    cmd.Parameters.Add("@3", OleDbType.Char, 55).Value = EMovimientos.Material;
                    cmd.Parameters.Add("@4", OleDbType.Char, 55).Value = EMovimientos.Documento;
                    cmd.Parameters.Add("@5", OleDbType.Char, 55).Value = EMovimientos.Descripcion;
                    cmd.Parameters.Add("@6", OleDbType.Char, 55).Value = EMovimientos.Cantidad;
                    cmd.Parameters.Add("@7", OleDbType.Char, 55).Value = EMovimientos.Fecha;
                    cmd.Parameters.Add("@8", OleDbType.Char, 55).Value = EMovimientos.Usuario;
                    cmd.Parameters.Add("@9", OleDbType.Char, 55).Value = EMovimientos.Mes;
                    cmd.Parameters.Add("@10", OleDbType.Char, 55).Value = EMovimientos.Año;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error :" + ex,"Ruta del error : DT/Movimientos/Registrar_Movimiento");
            }
        }
        /// <summary>
        /// Metodo que registra el total de entradas y salidas, el base de datos total.
        /// </summary>
        /// <param name="Procedimiento"></param>
        public static void Registrar_Mov_Total(string Procedimiento)
        {
            try
            {
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = Procedimiento;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Codigo",OleDbType.Char,55).Value = EMovimientos.Codigo;
                    cmd.Parameters.Add("@Cantidad", OleDbType.Char, 55).Value = EMovimientos.Cantidad;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Movimientos/Registrar_Mov_Total");
            }
        }
        /// <summary>
        /// Metodo que actualiza los costo de entradas y salidas totales.
        /// </summary>
        public static void Actualizar_Mov_Total()
        {
            try
            {
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Actualizar_Mov_Total";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Codigo",OleDbType.Char,55).Value = EMovimientos.Codigo;
                    cmd.ExecuteNonQuery();
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Movimiento/Actualizar_Mov_Total");
            }
        }
        /// <summary>
        /// Metodo que vacia todos los movimientos de entradas y salidas en una sola tabla.
        /// </summary>
        /// <param name="Tabla"></param>
        public static void Obtener_Movimientos(ListView Tabla)
        {
            try
            {
                int I = 0;
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Obtener_Movimientos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                OleDbDataReader Lector;
                Lector = cmd.ExecuteReader();
                while(Lector.Read())
                {
                    Tabla.Items.Add(Lector["Codigo"].ToString());
                    Tabla.Items[I].SubItems.Add(Lector["Material"].ToString());
                    Tabla.Items[I].SubItems.Add(Lector["Descripcion"].ToString());
                    Tabla.Items[I].SubItems.Add(Lector["Cantidad"].ToString());
                    Tabla.Items[I].SubItems.Add(Lector["Fecha"].ToString());
                    I++;
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Movimiento/Obtner_Movimiento");
            }
        }
        /// <summary>
        /// Metodo que vacia los movimientos de entradas y/o salida en una tabla.
        /// </summary>
        /// <param name="Tabla"></param>
        public static void Obtener_Movimiento(ListView Tabla)
        {
            try
            {
                int I = 0;
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Obtener_Movimiento";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Movimiento",OleDbType.Char,55).Value = EMovimientos.Movimiento;
                    OleDbDataReader Lector;
                    Lector = cmd.ExecuteReader();
                    while(Lector.Read())
                    {
                        Tabla.Items.Add(Lector["Documento"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Codigo"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Descripcion"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Cantidad"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Fecha"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Usuario"].ToString());
                        I++;
                    }
                }
                Conexion.Close();
            }
            catch(Exception ex)
            {
                EMensaje.Error("Error : " + ex,"Ruta del error : DT/Movimientos/Obtener_Movimiento");
            }
        }
        /// <summary>
        /// Obtener movimiento segun el codigo del material y vaciarlo en una tabla.
        /// </summary>
        /// <param name="Tabla"></param>
        public static void Obtener_Mov_Codigo(ListView Tabla)
        {
            try
            {
                int I = 0;
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Obtener_Mov_Codigo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Codigo", OleDbType.Char, 55).Value = EMovimientos.Codigo;
                    OleDbDataReader Lector;
                    Lector = cmd.ExecuteReader();
                    while(Lector.Read())
                    {
                        Tabla.Items.Add(Lector["Movimiento"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Codigo"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Documento"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Descripcion"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Cantidad"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Fecha"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Usuario"].ToString());
                        I++;
                    }
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Movimientos/Obtener_Movimiento");
            }
        }
        /// <summary>
        /// Obtener movimiento segun la fecha de registro del material y vaciarlo en una tabla.
        /// </summary>
        /// <param name="Tabla"></param>
        public static void Obtener_Mov_Fecha(ListView Tabla)
        {
            try
            {
                int I = 0;
                Conexion.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Obtener_Mov_Fecha";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion;
                {
                    cmd.Parameters.Add("@Movimiento", OleDbType.Char, 55).Value = EMovimientos.Movimiento;
                    cmd.Parameters.Add("@Mes", OleDbType.Char, 55).Value = EMovimientos.Mes;
                    cmd.Parameters.Add("@Año", OleDbType.Char, 55).Value = EMovimientos.Año;
                    OleDbDataReader Lector;
                    Lector = cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        Tabla.Items.Add(Lector["Codigo"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Documento"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Descripcion"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Cantidad"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Fecha"].ToString());
                        Tabla.Items[I].SubItems.Add(Lector["Usuario"].ToString());
                        I++;
                    }
                    Conexion.Close();
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                EMensaje.Error("Error : " + ex, "Ruta del error : DT/Movimientos/Obtener_Movimiento");
            }
        }
    }
}
