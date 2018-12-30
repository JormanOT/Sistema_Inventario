/*
Diseño en Capas, Capa Entidad
Capa donde estan los objetos 
utilizado a nivel de sistema.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using System.Windows.Forms;
namespace Bitesoft.System.ET
{
    public class EMensaje
    {
        /// <summary>
        /// Metodo que imprime un mensaje indicado un mensaje de informacion.
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Encabezado"></param>
        public static void Informacion(string Mensaje, string Encabezado)
        {
            MessageBox.Show(Mensaje,Encabezado,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        /// <summary>
        /// Metodo que imprime un mensaje indicado un mensaje de Error.
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Encabezado"></param>
        public static void Error(string Mensaje, string Encabezado)
        {
            MessageBox.Show(Mensaje, Encabezado, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Metodo que imprime un mensaje indicado un mensaje de Pregunta.
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Encabezado"></param>
        /// <returns></returns>
        public static DialogResult Pregunta(string Mensaje, string Encabezado)
        {
            return MessageBox.Show(Mensaje, Encabezado, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
