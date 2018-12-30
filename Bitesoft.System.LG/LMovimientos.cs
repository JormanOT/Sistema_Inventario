/*
Diseño en Capas, Capa Logica
esta capa se comunica con la
capa de datos y con la interfaz.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using System;
using Bunifu.Framework.UI;
using Bitesoft.System.DT;
using Bitesoft.System.ET;
using System.Windows.Forms;
namespace Bitesoft.System.LG
{
    public class LMovimientos
    {
        /// <summary>
        /// Metodo que trae el ultimo documento, y lo vacia en una cajita de texto recibida desde la interfaz.
        /// </summary>
        /// <param name="Ultimo_Valor"></param>
        public static void Obtener_Documento(BunifuMaterialTextbox Ultimo_Valor)
        {
            Movimientos.Obtener_Documento();
            if (EMovimientos.Documento == "")
            {
                Ultimo_Valor.Text = "1";
            }
            else
            {
                Ultimo_Valor.Text = Convert.ToString(Convert.ToInt32(EMovimientos.Documento) + 1);
            }
        }
        /// <summary>
        /// Metodo que registra los movimientos segun los parametros rebidos de la interfaz.
        /// </summary>
        /// <param name="Mov"></param>
        /// <param name="Cod"></param>
        /// <param name="Mat"></param>
        /// <param name="Doc"></param>
        /// <param name="Des"></param>
        /// <param name="Can"></param>
        /// <param name="Fe"></param>
        /// <param name="Usu"></param>
        /// <param name="Mes"></param>
        /// <param name="Año"></param>
        public static void Registrar_Movimiento(string Mov,string Cod, string Mat,string Doc,string Des, string Can,string Fe,string Usu,string Mes, string Año)
        {
            if(Des == "") { EMensaje.Informacion("Indique el texto breve","Informacion"); }
            if (Can == "") { EMensaje.Informacion("Indique la cantidad", "Informacion"); }
            {
                EMovimientos.Movimiento = Mov;
                EMovimientos.Codigo = Cod;
                EMovimientos.Material = Mat;
                EMovimientos.Documento = Doc;
                EMovimientos.Descripcion = Des;
                EMovimientos.Cantidad = Can;
                EMovimientos.Fecha = Fe;
                EMovimientos.Usuario = Usu;
                EMovimientos.Mes = Mes;
                EMovimientos.Año = Año;
                Movimientos.Registrar_Movimiento();
                EMensaje.Informacion("Proceso Completado","Informacion");
            }
        }
        /// <summary>
        /// Metodo que recibe como parametro el movimiento, y segun lo indicado vacia los datos en una tabla.
        /// </summary>
        /// <param name="Movimiento"></param>
        /// <param name="Tabla"></param>
        public static void Obtener_Movimiento(string Movimiento, ListView Tabla)
        {
            EMovimientos.Movimiento = Movimiento;
            Movimientos.Obtener_Movimiento(Tabla);
            EMensaje.Informacion("Documentos de " + Movimiento + " cargados correctamente !","Informacion");
        }
        /// <summary>
        /// Metodo que recibe como parametro el codigo, y segun lo indicado vacia los datos en una tabla.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Tabla"></param>
        public static void Obtener_Mov_Codigo(string Codigo,ListView Tabla)
        {
            EMovimientos.Codigo = Codigo;
            Movimientos.Obtener_Mov_Codigo(Tabla);
        }
        /// <summary>
        /// Metodo que recibe como parametro la fecha, y segun lo indicado vacia los datos en una tabla.
        /// </summary>
        /// <param name="Mov"></param>
        /// <param name="Mes"></param>
        /// <param name="Año"></param>
        /// <param name="Tabla"></param>
        public static void Obtener_Mov_Fecha(string Mov, string Mes, string Año, ListView Tabla)
        {
            EMovimientos.Movimiento = Mov;
            EMovimientos.Mes = Mes;
            EMovimientos.Año = Año;
            Movimientos.Obtener_Mov_Fecha(Tabla);
        }
        /// <summary>
        /// Metodo que vacia los datos de movimientos en una tabla.
        /// </summary>
        /// <param name="Tabla"></param>
        public static void Obtener_Movimientos(ListView Tabla)
        {
            Movimientos.Obtener_Movimientos(Tabla);
        }
        /// <summary>
        /// Metodo que registra los movimientos total segun el movimiento que reciba, el codigo y la cantidad.
        /// </summary>
        /// <param name="Procedimiento"></param>
        /// <param name="pCodigo"></param>
        /// <param name="pCantidad"></param>
        public static void Registrar_Mov_Total(string Procedimiento,string pCodigo, string pCantidad)
        {
            EMovimientos.Codigo = pCodigo;
            EMovimientos.Movimiento = pCantidad;
            Movimientos.Registrar_Mov_Total(Procedimiento);
            Movimientos.Actualizar_Mov_Total();
            Inventario.Actualizar_Inventario_Total();
        }
    }
}
