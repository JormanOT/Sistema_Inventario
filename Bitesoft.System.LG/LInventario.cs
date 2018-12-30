/*
Diseño en Capas, Capa Logica
esta capa se comunica con la
capa de datos y con la interfaz.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using Bitesoft.System.ET;
using Bitesoft.System.DT;
using System.Windows.Forms;
namespace Bitesoft.System.LG
{
    public class LInventario
    {
        /// <summary>
        /// Metodo que recibe los valores del material que se registrara en la base de datos del inventario.
        /// </summary>
        /// <param name="pCodigo"></param>
        /// <param name="pMaterial"></param>
        /// <param name="pExistencia"></param>
        /// <param name="pUMD"></param>
        /// <param name="pCosto"></param>
        /// <param name="pPrecio"></param>
        public static void Registrar(string pCodigo,string pMaterial,string pExistencia,string pUMD, double pCosto, double pPrecio)
        {
            if(pCodigo == "") { EMensaje.Informacion("Inserte el codigo del material","Informacion"); }
            if (pMaterial == "") { EMensaje.Informacion("Inserte el nombre del material", "Informacion"); }
            if (pExistencia == "") { EMensaje.Informacion("Inserte la existencia del material", "Informacion"); }
            if (pUMD == "") { EMensaje.Informacion("Inserte la medida", "Informacion"); }
            if(pCosto == 0.00) { EMensaje.Informacion("Indique el costo del material","Informacion"); }
            if (pPrecio == 0.00) { EMensaje.Informacion("Indique el Precio del material", "Informacion"); }
            else
            {
                EInventario.Codigo = pCodigo;
                EInventario.Material = pMaterial;
                EInventario.Existencia = pExistencia;
                EInventario.UMD = pUMD;
                EInventario.Costo = pCosto;
                EInventario.Precio = pPrecio;
                Inventario.Registrar();
                Inventario.Actualizar_Costo();
                Inventario.Registrar_Inventario_Total();
                Inventario.Actualizar_Inventario_Total();
                /*Llamo nuevamente al metodo para que se actualize tambien el costo final*/
                Inventario.Actualizar_Inventario_Total();
                EMensaje.Informacion("Proceso Completado","Informacion");
            }
        }
        /// <summary>
        /// Metodo que modifica el material, segun los valores recibidos por la interfaz.
        /// </summary>
        /// <param name="pCodigo"></param>
        /// <param name="pMaterial"></param>
        /// <param name="pExistencia"></param>
        /// <param name="pUMD"></param>
        /// <param name="pCosto"></param>
        /// <param name="pPrecio"></param>
        public static void Modificar(string pCodigo, string pMaterial, string pExistencia, string pUMD, double pCosto, double pPrecio)
        {
            if (pCodigo == "") { EMensaje.Informacion("Inserte el codigo del material", "Informacion"); }
            if (pMaterial == "") { EMensaje.Informacion("Inserte el nombre del material", "Informacion"); }
            if (pExistencia == "") { EMensaje.Informacion("Inserte la existencia del material", "Informacion"); }
            if (pUMD == "") { EMensaje.Informacion("Inserte la medida", "Informacion"); }
            if (pCosto == 0.00) { EMensaje.Informacion("Indique el costo del material", "Informacion"); }
            if (pPrecio == 0.00) { EMensaje.Informacion("Indique el Precio del material", "Informacion"); }
            else
            {
                EInventario.Codigo = pCodigo;
                EInventario.Material = pMaterial;
                EInventario.Existencia = pExistencia;
                EInventario.UMD = pUMD;
                EInventario.Costo = pCosto;
                EInventario.Precio = pPrecio;
                Inventario.Modificar();
                Inventario.Actualizar_Costo();
                EMensaje.Informacion("Proceso Completado", "Informacion");
            }
        }
        /// <summary>
        /// Metodo que llama a la funcion eliminar de la clase inventario.
        /// </summary>
        public static void Eliminar()
        {
            {
                Inventario.Eliminar();
                EMensaje.Informacion("Proceso Completado", "Informacion");
            }
        }
        /// <summary>
        /// Metodo que valida que el material es existente.
        /// </summary>
        /// <param name="pCodigo"></param>
        /// <returns></returns>
        public static bool Validar(string pCodigo)
        {
            if(pCodigo == "") { EMensaje.Informacion("Indique el codigo del material","Informacion"); }
            {
                EInventario.Codigo = pCodigo;

                if (Inventario.Validar().Rows.Count > 0)
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
        /// Metodo que busca el material segun el parametro que reciba.
        /// </summary>
        /// <param name="pCodigo"></param>
        public static void Buscar(string pCodigo)
        {
            if(pCodigo == "") { EMensaje.Informacion("Indique el codigo del material a buscar","Informacion");}
            {
                EInventario.Codigo = pCodigo;
                Inventario.Buscar();
            }
        }
        /// <summary>
        /// Metodo que actualiza el inventario, segun el material y  la cantidad.
        /// </summary>
        /// <param name="Valor"></param>
        /// <param name="Material"></param>
        /// <param name="Cantidad"></param>
        public static void Actualizar_Inventario(string Valor, string Material,string Cantidad)
        {
            EInventario.Codigo = Material;
            EInventario.Existencia = Cantidad;
            Inventario.Actualizar_Inventario(Valor);
            Inventario.Actualizar_Costo();
        }
        /// <summary>
        /// Metodo que recibe la tabla de la interfaz y vacia los datos del inventario.
        /// </summary>
        /// <param name="Tabla"></param>
        public static void Lote_Inventario(ListView Tabla)
        {
            Inventario.Lote_Inventario(Tabla);
            EMensaje.Informacion("Inventario Cargado Correctamente !","Informacion");
        }
    }
}
