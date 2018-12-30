/*
Diseño en Capas, Capa Entidad
Capa donde estan los objetos 
utilizado a nivel de sistema.

Esta clase es utilizada para
realizar ciertas funciones
de la interfaz del usuario.
    
Programador : Jorman Ortega
Visita mi pagina y Comparte. 

22/11/2018*/
using System;
using System.Windows.Forms;
using System.IO;
namespace Bitesoft.System.ET
{
    public class Herramientas
    {
        /// <summary>
        /// Metodo que abre un formulario en un panel.
        /// </summary>
        /// <param name="Padre"></param>
        /// <param name="Formulario_Hijo"></param>
        public static void AbrirForm(Panel Padre, object Formulario_Hijo)
        {
            if (Padre.Controls.Count > 0)
            {
                Padre.Controls.RemoveAt(0);
            }

            {
                Form Fh = Formulario_Hijo as Form;
                Fh.TopLevel = false;
                Fh.Anchor = AnchorStyles.Top;
                Fh.Anchor = AnchorStyles.Bottom;
                Fh.Anchor = AnchorStyles.Left;
                Fh.Anchor = AnchorStyles.Right;
                Fh.Dock = DockStyle.Fill;
                Padre.Controls.Add(Fh);
                Padre.Tag = Fh;
                Fh.Show();
            }
        }
        /// <summary>
        /// Metodo que exporta a excel, segun los datos que se le pasen como parametro.
        /// </summary>
        /// <param name="Mov"></param>
        /// <param name="Almacen"></param>
        /// <param name="Tabla"></param>
        public static void Exportar_Excel(string Mov,string Almacen, ListView Tabla)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Archivo Excel 2007 (*.xls)|*.xls";
            fichero.FileName = "Respaldo " +  Mov + " [ " + Almacen + " ]";
            if (fichero.ShowDialog() == DialogResult.OK)
                try
                {
                    string[] st = new string[Tabla.Columns.Count];
                    StreamWriter sw = new StreamWriter(fichero.FileName, false);
                    sw.AutoFlush = true;
                    string dat = "\n";

                    for (int col = 0; col < Tabla.Columns.Count; col++)
                    {
                        dat = dat + "\t" + Convert.ToString(Tabla.Columns[col].Text);
                    }
                    sw.WriteLine(dat);

                    int rowIndex = 1;
                    int row = 0;
                    string st1 = "";
                    for (row = 0; row < Tabla.Items.Count; row++)
                    {
                        if (rowIndex <= Tabla.Items.Count)
                            rowIndex++;
                        st1 = "\n";
                        for (int col = 0; col < Tabla.Columns.Count; col++)
                        {
                            st1 = st1 + "\t" + Convert.ToString(Tabla.Items[row].SubItems[col].Text);
                        }
                        sw.WriteLine(st1);
                    }
                    sw.Close();
                    MessageBox.Show("Proceso Completado", "Exportar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EMensaje.Error("Error : " + ex, "Ruta del error : ET/Herramientas/Exportar_Excel");
                }
        }
    }
}
