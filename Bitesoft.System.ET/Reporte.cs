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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace Bitesoft.System.ET
{
    public class Reporte
    {
        /// <summary>
        /// Atributos de la clase.
        /// </summary>
        static EConexion _Conexion = new EConexion("ACCESS");
        static Document doc = new Document(PageSize.LETTER.Rotate());
        static Font Fuente_Titulo = new Font(Font.FontFamily.COURIER, 16, Font.BOLD, BaseColor.BLACK);
        static Font Fuente_Datos = new Font(Font.FontFamily.COURIER, 12, Font.BOLD, BaseColor.BLACK);
        static Document Documento_Todos = new Document(PageSize.LETTER.Rotate());
        static Document Documento_Entrada = new Document(PageSize.LETTER.Rotate());
        static Document Documento_Salida = new Document(PageSize.LETTER.Rotate());
        static string parametro = "";
        static string _Total_Inicial = "";
        static string _Total_Entradas = "";
        static string _Total_Salidas = "";
        static string _Total_Final = "";
        /// <summary>
        /// Metodos que exporta a pdf un reporte de inventario.
        /// </summary>
        public static void Exportar_Inventario()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "PDF (*.pdf)|*.pdf";
            fichero.FileName = "Reporte de Inventario" + "[" + DateTime.Now.ToString("dd-MM-yyyy") + "]";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fichero.FileName, FileMode.Create));
                    doc.AddTitle("Bytesoft, C.A.");
                    doc.AddCreator("Jorman Ortega");
                    doc.Open();
                    PdfPTable table = new PdfPTable(3);
                    table.HorizontalAlignment = 0;
                    table.TotalWidth = 300f;
                    table.WidthPercentage = 100;
                    Font Fuente_Inicial = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.BOLD, BaseColor.BLACK);
                    PdfPCell CeldaI = new PdfPCell(new Phrase("Reporte de Inventario al : " + DateTime.Now.ToString("dd/MMMM/yyyy"), Fuente_Inicial));
                    CeldaI.HorizontalAlignment = 1;
                    CeldaI.BorderWidth = 1;
                    CeldaI.Colspan = 3;
                    table.AddCell(CeldaI);
                    doc.Add(table);
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph(" "));
                    Font Fuente = new Font(Font.FontFamily.COURIER, 8, Font.NORMAL, BaseColor.BLACK);
                    PdfPTable tableI = new PdfPTable(4);
                    PdfPCell CeldaII = new PdfPCell(new Phrase("Nombre :", Fuente));
                    PdfPCell CeldaIII = new PdfPCell(new Phrase("Usuario :", Fuente));
                    PdfPCell CeldaIV = new PdfPCell(new Phrase("", Fuente));
                    PdfPCell CeldaV = new PdfPCell(new Phrase("Fecha Creacion", Fuente));
                    tableI.HorizontalAlignment = 0;
                    tableI.WidthPercentage = 100;
                    CeldaII.HorizontalAlignment = 1;
                    CeldaIII.HorizontalAlignment = 1;
                    CeldaV.HorizontalAlignment = 1;
                    CeldaII.BorderWidth = 1;
                    CeldaIII.BorderWidth = 1;
                    CeldaIV.BorderWidth = 0;
                    CeldaV.BorderWidth = 1;
                    tableI.AddCell(CeldaII);
                    tableI.AddCell(CeldaIII);
                    tableI.AddCell(CeldaIV);
                    tableI.AddCell(CeldaV);
                    doc.Add(tableI);
                    PdfPTable _tableI = new PdfPTable(4);
                    PdfPCell _CeldaII = new PdfPCell(new Phrase(EUsuarios.Nombre + " " + EUsuarios.Apellido, Fuente));
                    PdfPCell _CeldaIII = new PdfPCell(new Phrase(EUsuarios.Usuario, Fuente));
                    PdfPCell _CeldaIV = new PdfPCell(new Phrase("", Fuente));
                    PdfPCell _CeldaV = new PdfPCell(new Phrase(DateTime.Today.ToString("dd-MM-yyyy"), Fuente));
                    _tableI.HorizontalAlignment = 0;
                    _tableI.WidthPercentage = 100;
                    _CeldaII.HorizontalAlignment = 1;
                    _CeldaIII.HorizontalAlignment = 1;
                    _CeldaV.HorizontalAlignment = 1;
                    _CeldaII.BorderWidth = 1;
                    _CeldaIII.BorderWidth = 1;
                    _CeldaIV.BorderWidth = 0;
                    _CeldaV.BorderWidth = 1;
                    _tableI.AddCell(_CeldaII);
                    _tableI.AddCell(_CeldaIII);
                    _tableI.AddCell(_CeldaIV);
                    _tableI.AddCell(_CeldaV);
                    doc.Add(_tableI);
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph(" "));
                    PdfPTable Inventario = new PdfPTable(12);
                    Inventario.HorizontalAlignment = 0;
                    Inventario.WidthPercentage = 100;
                    PdfPCell CI = new PdfPCell(new Phrase("Codigo", Fuente));
                    PdfPCell CIII = new PdfPCell(new Phrase("Inv. Inicial", Fuente));
                    PdfPCell CIV = new PdfPCell(new Phrase("Entradas", Fuente));
                    PdfPCell CV = new PdfPCell(new Phrase("Salidas", Fuente));
                    PdfPCell CVII = new PdfPCell(new Phrase("Inv. Final", Fuente));
                    CI.BorderWidth = 1;
                    CI.HorizontalAlignment = 1;
                    CI.Colspan = 2;
                    CIII.BorderWidth = 1;
                    CIII.HorizontalAlignment = 1;
                    CIII.Colspan = 2;
                    CIV.BorderWidth = 1;
                    CIV.HorizontalAlignment = 1;
                    CIV.Colspan = 2;
                    CV.BorderWidth = 1;
                    CV.HorizontalAlignment = 1;
                    CV.Colspan = 2;
                    CVII.BorderWidth = 1;
                    CVII.HorizontalAlignment = 1;
                    CVII.Colspan = 2;
                    Inventario.AddCell(CI);
                    Inventario.AddCell(CIII);
                    Inventario.AddCell(CIV);
                    Inventario.AddCell(CV);
                    Inventario.AddCell(CVII);
                    doc.Add(Inventario);
                    PdfPTable _Inventario = new PdfPTable(11);
                    _Inventario.HorizontalAlignment = 0;
                    _Inventario.WidthPercentage = 100;
                    PdfPCell _CI = new PdfPCell(new Phrase("Material", Fuente));
                    PdfPCell _CI_ = new PdfPCell(new Phrase("Costo", Fuente));
                    PdfPCell _I1 = new PdfPCell(new Phrase("Unidad Inicial", Fuente));
                    PdfPCell _I2 = new PdfPCell(new Phrase("Costo Inicial", Fuente));
                    PdfPCell _II1 = new PdfPCell(new Phrase("Unidad Entradas", Fuente));
                    PdfPCell _II2 = new PdfPCell(new Phrase("Costo Entradas", Fuente));
                    PdfPCell _II3 = new PdfPCell(new Phrase("Precio Venta", Fuente));
                    PdfPCell _III1 = new PdfPCell(new Phrase("Unidad Salidas", Fuente));
                    PdfPCell _III2 = new PdfPCell(new Phrase("Costo Salidas", Fuente));
                    PdfPCell _CIII = new PdfPCell(new Phrase("Unidades Final", Fuente));
                    PdfPCell _CIV = new PdfPCell(new Phrase("Costo Final", Fuente));
                    _CI.BorderWidth = 1;
                    _CI.Colspan = 1;
                    _CI_.BorderWidth = 1;
                    _CI_.Colspan = 1;
                    _I1.BorderWidth = 1;
                    _I2.BorderWidth = 1;
                    _II1.BorderWidth = 1;
                    _II2.BorderWidth = 1;
                    _II3.BorderWidth = 1;
                    _III1.BorderWidth = 1;
                    _III2.BorderWidth = 1;
                    _CIII.BorderWidth = 1;
                    _CIV.BorderWidth = 1;

                    _CI.HorizontalAlignment = 1;
                    _CI_.HorizontalAlignment = 1;
                    _I1.HorizontalAlignment = 1;
                    _I2.HorizontalAlignment = 1;
                    _II1.HorizontalAlignment = 1;
                    _II2.HorizontalAlignment = 1;
                    _II3.HorizontalAlignment = 1;
                    _III1.HorizontalAlignment = 1;
                    _III2.HorizontalAlignment = 1;
                    _CIII.HorizontalAlignment = 1;
                    _CIV.HorizontalAlignment = 1;

                    _Inventario.AddCell(_CI);
                    _Inventario.AddCell(_CI_);
                    _Inventario.AddCell(_I1);
                    _Inventario.AddCell(_I2);
                    _Inventario.AddCell(_II1);
                    _Inventario.AddCell(_II2);
                    _Inventario.AddCell(_II3);
                    _Inventario.AddCell(_III1);
                    _Inventario.AddCell(_III2);
                    _Inventario.AddCell(_CIII);
                    _Inventario.AddCell(_CIV);
                    doc.Add(_Inventario);
                    Añadir_Datos_Inventario();

                    PdfPTable _Inventario_ = new PdfPTable(11);
                    _Inventario_.HorizontalAlignment = 0;
                    _Inventario_.WidthPercentage = 100;
                    PdfPCell Total = new PdfPCell(new Phrase("Totales :", Fuente));
                    Total.Colspan = 2;
                    Total.HorizontalAlignment = 2;
                    Total.BorderWidth = 1;
                    PdfPCell Total_Inicial = new PdfPCell(new Phrase(_Total_Inicial, Fuente));
                    Total_Inicial.Colspan = 2;
                    Total_Inicial.HorizontalAlignment = 1;
                    Total_Inicial.BorderWidth = 1;
                    PdfPCell Total_Entradas = new PdfPCell(new Phrase(_Total_Entradas, Fuente));
                    Total_Entradas.Colspan = 2;
                    Total_Entradas.HorizontalAlignment = 1;
                    Total_Entradas.BorderWidth = 1;
                    PdfPCell Total_Salidas = new PdfPCell(new Phrase(_Total_Salidas, Fuente));
                    Total_Salidas.Colspan = 3;
                    Total_Salidas.HorizontalAlignment = 1;
                    Total_Salidas.BorderWidth = 1;
                    PdfPCell Total_Final = new PdfPCell(new Phrase(_Total_Final, Fuente));
                    Total_Final.Colspan = 2;
                    Total_Final.HorizontalAlignment = 1;
                    Total_Final.BorderWidth = 1;
                    _Inventario_.AddCell(Total);
                    _Inventario_.AddCell(Total_Inicial);
                    _Inventario_.AddCell(Total_Entradas);
                    _Inventario_.AddCell(Total_Salidas);
                    _Inventario_.AddCell(Total_Final);
                    doc.Add(_Inventario_);
                    doc.Close();
                    writer.Close();
                }
                catch
                {
                    EMensaje.Informacion("No puede generar el archivo 2 veces. ingrese nuevamente al modulo de reportes", "Informacion");

                }
            }
        }
        /// <summary>
        /// Metodo privado que añade una tabla los datos del inventario,para luego imprimirlo en un pdf.
        /// </summary>
        private static void Añadir_Datos_Inventario()
        {
            int I = 0;
            double Total_Inicial = 0;
            double Total_Entradas = 0;
            double Total_Salidas = 0;
            double Total_Final = 0;
            Font Fuente = new Font(Font.FontFamily.COURIER, 8, Font.NORMAL, BaseColor.BLACK);
            PdfPTable TablaInventario = new PdfPTable(11);
            TablaInventario.WidthPercentage = 100;
            TablaInventario.HorizontalAlignment = 0;
            OleDbConnection Conexion = new OleDbConnection(_Conexion.Conexion);
            Conexion.Open();
            OleDbCommand LeerDatos = new OleDbCommand("SELECT *  FROM Total_Inventario", Conexion);
            OleDbDataReader LectorDatos;
            LectorDatos = LeerDatos.ExecuteReader();
            while (LectorDatos.Read())
            {
                PdfPCell Celda1 = new PdfPCell(new Phrase(LectorDatos["Codigo"].ToString(), Fuente));
                PdfPCell Celda2 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Costo"])), Fuente));
                PdfPCell Celda3 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Unidad_Inicial"])), Fuente));
                PdfPCell Celda4 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Costo_Inicial"])), Fuente));
                PdfPCell Celda5 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Und_Entradas"])), Fuente));
                PdfPCell Celda6 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Costo_Entradas"])), Fuente));
                PdfPCell Celda9 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Precio_Venta"])), Fuente));
                PdfPCell Celda7 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Und_Salidas"])), Fuente));
                PdfPCell Celda8 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Costo_Salidas"])), Fuente));
                PdfPCell Celda11 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Und_Final"])), Fuente));
                PdfPCell Celda12 = new PdfPCell(new Phrase(string.Format("{0:n}", Convert.ToDouble(LectorDatos["Costo_Final"])), Fuente));
                Celda1.BorderWidth = 1;
                Celda1.HorizontalAlignment = 1;
                Celda2.BorderWidth = 1;
                Celda2.HorizontalAlignment = 1;
                Celda3.BorderWidth = 1;
                Celda3.HorizontalAlignment = 1;
                Celda4.BorderWidth = 1;
                Celda4.HorizontalAlignment = 1;
                Celda5.BorderWidth = 1;
                Celda5.HorizontalAlignment = 1;
                Celda6.BorderWidth = 1;
                Celda6.HorizontalAlignment = 1;
                Celda9.BorderWidth = 1;
                Celda9.HorizontalAlignment = 1;
                Celda7.BorderWidth = 1;
                Celda7.HorizontalAlignment = 1;
                Celda8.BorderWidth = 1;
                Celda8.HorizontalAlignment = 1;
                Celda11.BorderWidth = 1;
                Celda11.HorizontalAlignment = 1;
                Celda12.BorderWidth = 1;
                Celda12.HorizontalAlignment = 1;
                TablaInventario.AddCell(Celda1);
                TablaInventario.AddCell(Celda2);
                TablaInventario.AddCell(Celda3);
                TablaInventario.AddCell(Celda4);
                TablaInventario.AddCell(Celda5);
                TablaInventario.AddCell(Celda6);
                TablaInventario.AddCell(Celda9);
                TablaInventario.AddCell(Celda7);
                TablaInventario.AddCell(Celda8);
                TablaInventario.AddCell(Celda11);
                TablaInventario.AddCell(Celda12);
                Total_Inicial += Convert.ToDouble(LectorDatos["Costo_Inicial"]);
                _Total_Inicial = Total_Inicial.ToString("c");
                Total_Entradas += Convert.ToDouble(LectorDatos["Costo_Entradas"]);
                _Total_Entradas = Total_Entradas.ToString("c");
                Total_Salidas += Convert.ToDouble(LectorDatos["Costo_Salidas"]);
                _Total_Salidas = Total_Salidas.ToString("c");
                Total_Final += Convert.ToDouble(LectorDatos["Costo_Final"]);
                _Total_Final = Total_Final.ToString("c");
                I += 1;
            }
            Conexion.Close();
            doc.Add(TablaInventario);
        }
        /// <summary>
        /// Metodo que exporta los movimientos segun el parametro que reciba.
        /// </summary>
        /// <param name="Movimiento"></param>
        public static void Exportar_Movimiento(string Movimiento)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "PDF (*.pdf)|*.pdf";
            switch (Movimiento)
            {
                case "Entradas/Salidas":
                    fichero.FileName = "Movimientos al." + "[" + DateTime.Now.ToString("dd-MM-yyyy") + "]";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfWriter writer = PdfWriter.GetInstance(Documento_Todos, new FileStream(fichero.FileName, FileMode.Create));
                            Documento_Todos.Open();
                            Agregar_Encabezados_Todos();
                            Añadir_Tabla_Todos();
                            Documento_Todos.Close();
                            writer.Close();
                        }
                        catch
                        {
                            EMensaje.Informacion("No puede generar el archivo 2 veces.Reinicie el Sistema", "Informacion");
                        }
                    }
                    break;
                case "Entrada":
                    fichero.FileName = "Entradas al." + "[" + DateTime.Now.ToString("dd-MM-yyyy") + "]";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfWriter writer = PdfWriter.GetInstance(Documento_Entrada, new FileStream(fichero.FileName, FileMode.Create));
                            Documento_Entrada.Open();
                            Agregar_Encabezados_Entradas();
                            parametro = Movimiento;
                            Añadir_Tabla_Entrada();
                            Documento_Entrada.CloseDocument();
                            Documento_Entrada.Close();
                            writer.Close();
                        }
                        catch
                        {
                            EMensaje.Informacion("No puede generar el archivo 2 veces.Reinicie el Sistema", "Informacion");

                        }
                    }
                    break;
                case "Salida":
                    fichero.FileName = "Salidas al." + "[" + DateTime.Now.ToString("dd-MM-yyyy") + "]";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfWriter writer = PdfWriter.GetInstance(Documento_Salida, new FileStream(fichero.FileName, FileMode.Create));
                            Documento_Salida.Open();
                            Agregar_Encabezados_Salidas();
                            parametro = Movimiento;
                            Añadir_Tabla_Salida();
                            Documento_Salida.CloseDocument();
                            Documento_Salida.Close();
                            writer.Close();
                        }
                        catch
                        {
                            EMensaje.Informacion("No puede generar el archivo 2 veces.Reinicie el Sistema", "Informacion");

                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Metodo privado que añade una tabla los movimientos de entradas.
        /// </summary>
        private static void Añadir_Tabla_Entrada()
        {
            int J = 0;
            PdfPTable Tabla_Encabezados = new PdfPTable(7);
            Tabla_Encabezados.HorizontalAlignment = 1;
            Tabla_Encabezados.WidthPercentage = 100;
            PdfPCell Celda_Encabezado_1 = new PdfPCell(new Phrase("Movimiento", Fuente_Datos));
            PdfPCell Celda_Encabezado_2 = new PdfPCell(new Phrase("Documento", Fuente_Datos));
            PdfPCell Celda_Encabezado_3 = new PdfPCell(new Phrase("Codigo", Fuente_Datos));
            PdfPCell Celda_Encabezado_4 = new PdfPCell(new Phrase("Descripcion", Fuente_Datos));
            PdfPCell Celda_Encabezado_5 = new PdfPCell(new Phrase("Cantidad", Fuente_Datos));
            PdfPCell Celda_Encabezado_6 = new PdfPCell(new Phrase("Fecha", Fuente_Datos));
            PdfPCell Celda_Encabezado_7 = new PdfPCell(new Phrase("Usuario", Fuente_Datos));
            Celda_Encabezado_1.HorizontalAlignment = 1;
            Celda_Encabezado_1.BorderWidth = 1;
            Celda_Encabezado_2.HorizontalAlignment = 1;
            Celda_Encabezado_2.BorderWidth = 1;
            Celda_Encabezado_3.HorizontalAlignment = 1;
            Celda_Encabezado_3.BorderWidth = 1;
            Celda_Encabezado_4.HorizontalAlignment = 1;
            Celda_Encabezado_4.BorderWidth = 1;
            Celda_Encabezado_5.HorizontalAlignment = 1;
            Celda_Encabezado_5.BorderWidth = 1;
            Celda_Encabezado_6.HorizontalAlignment = 1;
            Celda_Encabezado_6.BorderWidth = 1;
            Celda_Encabezado_7.HorizontalAlignment = 1;
            Celda_Encabezado_7.BorderWidth = 1;
            Tabla_Encabezados.AddCell(Celda_Encabezado_1);
            Tabla_Encabezados.AddCell(Celda_Encabezado_2);
            Tabla_Encabezados.AddCell(Celda_Encabezado_3);
            Tabla_Encabezados.AddCell(Celda_Encabezado_4);
            Tabla_Encabezados.AddCell(Celda_Encabezado_5);
            Tabla_Encabezados.AddCell(Celda_Encabezado_6);
            Tabla_Encabezados.AddCell(Celda_Encabezado_7);
            Documento_Entrada.Add(Tabla_Encabezados);
            PdfPTable Tabla_Datos = new PdfPTable(7);
            Tabla_Datos.HorizontalAlignment = 1;
            Tabla_Datos.WidthPercentage = 100;
            OleDbConnection Conexion = new OleDbConnection(_Conexion.Conexion);
            Conexion.Open();
            OleDbCommand Seleccion = new OleDbCommand("SELECT * FROM Movimientos WHERE Movimiento Like '%" + parametro + "%'", Conexion);
            OleDbDataReader Lector;
            Lector = Seleccion.ExecuteReader();
            while (Lector.Read())
            {
                PdfPCell Dato_1 = new PdfPCell(new Paragraph(Lector["Movimiento"].ToString(), Fuente_Datos));
                PdfPCell Dato_2 = new PdfPCell(new Paragraph(Lector["Documento"].ToString(), Fuente_Datos));
                PdfPCell Dato_3 = new PdfPCell(new Paragraph(Lector["Codigo"].ToString(), Fuente_Datos));
                PdfPCell Dato_4 = new PdfPCell(new Paragraph(Lector["Descripcion"].ToString(), Fuente_Datos));
                PdfPCell Dato_5 = new PdfPCell(new Paragraph(string.Format("{0:n}", Convert.ToDouble(Lector["Cantidad"])), Fuente_Datos));
                PdfPCell Dato_6 = new PdfPCell(new Paragraph(string.Format("{0:d}", (Lector["Fecha"])), Fuente_Datos));
                PdfPCell Dato_7 = new PdfPCell(new Paragraph(Lector["Usuario"].ToString(), Fuente_Datos));
                Dato_1.HorizontalAlignment = 1;
                Dato_1.BorderWidth = 1;
                Dato_2.HorizontalAlignment = 1;
                Dato_2.BorderWidth = 1;
                Dato_3.HorizontalAlignment = 1;
                Dato_3.BorderWidth = 1;
                Dato_4.HorizontalAlignment = 1;
                Dato_4.BorderWidth = 1;
                Dato_5.HorizontalAlignment = 1;
                Dato_5.BorderWidth = 1;
                Dato_6.HorizontalAlignment = 1;
                Dato_6.BorderWidth = 1;
                Dato_7.HorizontalAlignment = 1;
                Dato_7.BorderWidth = 1;
                Tabla_Datos.AddCell(Dato_1);
                Tabla_Datos.AddCell(Dato_2);
                Tabla_Datos.AddCell(Dato_3);
                Tabla_Datos.AddCell(Dato_4);
                Tabla_Datos.AddCell(Dato_5);
                Tabla_Datos.AddCell(Dato_6);
                Tabla_Datos.AddCell(Dato_7);
                J += 1;
            }
            Conexion.Close();
            Documento_Entrada.Add(Tabla_Datos);
        }
        /// <summary>
        /// Metodo privado que añade una tabla los movimientos de salidas.
        /// </summary>
        private static void Añadir_Tabla_Salida()
        {
            int J = 0;
            PdfPTable Tabla_Encabezados = new PdfPTable(7);
            Tabla_Encabezados.HorizontalAlignment = 1;
            Tabla_Encabezados.WidthPercentage = 100;
            PdfPCell Celda_Encabezado_1 = new PdfPCell(new Phrase("Movimiento", Fuente_Datos));
            PdfPCell Celda_Encabezado_2 = new PdfPCell(new Phrase("Documento", Fuente_Datos));
            PdfPCell Celda_Encabezado_3 = new PdfPCell(new Phrase("Codigo", Fuente_Datos));
            PdfPCell Celda_Encabezado_4 = new PdfPCell(new Phrase("Descripcion", Fuente_Datos));
            PdfPCell Celda_Encabezado_5 = new PdfPCell(new Phrase("Cantidad", Fuente_Datos));
            PdfPCell Celda_Encabezado_6 = new PdfPCell(new Phrase("Fecha", Fuente_Datos));
            PdfPCell Celda_Encabezado_7 = new PdfPCell(new Phrase("Usuario", Fuente_Datos));
            Celda_Encabezado_1.HorizontalAlignment = 1;
            Celda_Encabezado_1.BorderWidth = 1;
            Celda_Encabezado_2.HorizontalAlignment = 1;
            Celda_Encabezado_2.BorderWidth = 1;
            Celda_Encabezado_3.HorizontalAlignment = 1;
            Celda_Encabezado_3.BorderWidth = 1;
            Celda_Encabezado_4.HorizontalAlignment = 1;
            Celda_Encabezado_4.BorderWidth = 1;
            Celda_Encabezado_5.HorizontalAlignment = 1;
            Celda_Encabezado_5.BorderWidth = 1;
            Celda_Encabezado_6.HorizontalAlignment = 1;
            Celda_Encabezado_6.BorderWidth = 1;
            Celda_Encabezado_7.HorizontalAlignment = 1;
            Celda_Encabezado_7.BorderWidth = 1;
            Tabla_Encabezados.AddCell(Celda_Encabezado_1);
            Tabla_Encabezados.AddCell(Celda_Encabezado_2);
            Tabla_Encabezados.AddCell(Celda_Encabezado_3);
            Tabla_Encabezados.AddCell(Celda_Encabezado_4);
            Tabla_Encabezados.AddCell(Celda_Encabezado_5);
            Tabla_Encabezados.AddCell(Celda_Encabezado_6);
            Tabla_Encabezados.AddCell(Celda_Encabezado_7);
            Documento_Salida.Add(Tabla_Encabezados);
            PdfPTable Tabla_Datos = new PdfPTable(7);
            Tabla_Datos.HorizontalAlignment = 1;
            Tabla_Datos.WidthPercentage = 100;
            OleDbConnection Conexion = new OleDbConnection(_Conexion.Conexion);
            Conexion.Open();
            OleDbCommand Seleccion = new OleDbCommand("SELECT * FROM Movimientos WHERE Movimiento Like '%" + parametro + "%'", Conexion);
            OleDbDataReader Lector;
            Lector = Seleccion.ExecuteReader();
            while (Lector.Read())
            {
                PdfPCell Dato_1 = new PdfPCell(new Paragraph(Lector["Movimiento"].ToString(), Fuente_Datos));
                PdfPCell Dato_2 = new PdfPCell(new Paragraph(Lector["Documento"].ToString(), Fuente_Datos));
                PdfPCell Dato_3 = new PdfPCell(new Paragraph(Lector["Codigo"].ToString(), Fuente_Datos));
                PdfPCell Dato_4 = new PdfPCell(new Paragraph(Lector["Descripcion"].ToString(), Fuente_Datos));
                PdfPCell Dato_5 = new PdfPCell(new Paragraph(string.Format("{0:n}", Convert.ToDouble(Lector["Cantidad"])), Fuente_Datos));
                PdfPCell Dato_6 = new PdfPCell(new Paragraph(string.Format("{0:d}", (Lector["Fecha"])), Fuente_Datos));
                PdfPCell Dato_7 = new PdfPCell(new Paragraph(Lector["Usuario"].ToString(), Fuente_Datos));
                Dato_1.HorizontalAlignment = 1;
                Dato_1.BorderWidth = 1;
                Dato_2.HorizontalAlignment = 1;
                Dato_2.BorderWidth = 1;
                Dato_3.HorizontalAlignment = 1;
                Dato_3.BorderWidth = 1;
                Dato_4.HorizontalAlignment = 1;
                Dato_4.BorderWidth = 1;
                Dato_5.HorizontalAlignment = 1;
                Dato_5.BorderWidth = 1;
                Dato_6.HorizontalAlignment = 1;
                Dato_6.BorderWidth = 1;
                Dato_7.HorizontalAlignment = 1;
                Dato_7.BorderWidth = 1;
                Tabla_Datos.AddCell(Dato_1);
                Tabla_Datos.AddCell(Dato_2);
                Tabla_Datos.AddCell(Dato_3);
                Tabla_Datos.AddCell(Dato_4);
                Tabla_Datos.AddCell(Dato_5);
                Tabla_Datos.AddCell(Dato_6);
                Tabla_Datos.AddCell(Dato_7);
                J += 1;
            }
            Conexion.Close();
            Documento_Salida.Add(Tabla_Datos);
        }
        /// <summary>
        /// Metodo privado que añade una tabla todos los movimientos de entradas y salidas.
        /// </summary>
        private static void Añadir_Tabla_Todos()
        {
            int J = 0;
            PdfPTable Tabla_Encabezados = new PdfPTable(7);
            Tabla_Encabezados.HorizontalAlignment = 1;
            Tabla_Encabezados.WidthPercentage = 100;
            PdfPCell Celda_Encabezado_1 = new PdfPCell(new Phrase("Movimiento", Fuente_Datos));
            PdfPCell Celda_Encabezado_2 = new PdfPCell(new Phrase("Documento", Fuente_Datos));
            PdfPCell Celda_Encabezado_3 = new PdfPCell(new Phrase("Codigo", Fuente_Datos));
            PdfPCell Celda_Encabezado_4 = new PdfPCell(new Phrase("Descripcion", Fuente_Datos));
            PdfPCell Celda_Encabezado_5 = new PdfPCell(new Phrase("Cantidad", Fuente_Datos));
            PdfPCell Celda_Encabezado_6 = new PdfPCell(new Phrase("Costo", Fuente_Datos));
            PdfPCell Celda_Encabezado_7 = new PdfPCell(new Phrase("Fecha", Fuente_Datos));
            Celda_Encabezado_1.HorizontalAlignment = 1;
            Celda_Encabezado_1.BorderWidth = 1;
            Celda_Encabezado_2.HorizontalAlignment = 1;
            Celda_Encabezado_2.BorderWidth = 1;
            Celda_Encabezado_3.HorizontalAlignment = 1;
            Celda_Encabezado_3.BorderWidth = 1;
            Celda_Encabezado_4.HorizontalAlignment = 1;
            Celda_Encabezado_4.BorderWidth = 1;
            Celda_Encabezado_5.HorizontalAlignment = 1;
            Celda_Encabezado_5.BorderWidth = 1;
            Celda_Encabezado_6.HorizontalAlignment = 1;
            Celda_Encabezado_6.BorderWidth = 1;
            Celda_Encabezado_7.HorizontalAlignment = 1;
            Celda_Encabezado_7.BorderWidth = 1;
            Tabla_Encabezados.AddCell(Celda_Encabezado_1);
            Tabla_Encabezados.AddCell(Celda_Encabezado_2);
            Tabla_Encabezados.AddCell(Celda_Encabezado_3);
            Tabla_Encabezados.AddCell(Celda_Encabezado_4);
            Tabla_Encabezados.AddCell(Celda_Encabezado_5);
            Tabla_Encabezados.AddCell(Celda_Encabezado_6);
            Tabla_Encabezados.AddCell(Celda_Encabezado_7);
            Documento_Todos.Add(Tabla_Encabezados);
            PdfPTable Tabla_Datos = new PdfPTable(7);
            Tabla_Datos.HorizontalAlignment = 1;
            Tabla_Datos.WidthPercentage = 100;
            OleDbConnection Conexion = new OleDbConnection(_Conexion.Conexion);
            Conexion.Open();
            OleDbCommand Seleccion = new OleDbCommand("SELECT * FROM Movimientos", Conexion);
            OleDbDataReader Lector;
            Lector = Seleccion.ExecuteReader();
            while (Lector.Read())
            {
                PdfPCell Dato_1 = new PdfPCell(new Paragraph(Lector["Movimiento"].ToString(), Fuente_Datos));
                PdfPCell Dato_2 = new PdfPCell(new Paragraph(Lector["Documento"].ToString(), Fuente_Datos));
                PdfPCell Dato_3 = new PdfPCell(new Paragraph(Lector["Codigo"].ToString(), Fuente_Datos));
                PdfPCell Dato_4 = new PdfPCell(new Paragraph(Lector["Descripcion"].ToString(), Fuente_Datos));
                PdfPCell Dato_5 = new PdfPCell(new Paragraph(string.Format("{0:n}", Convert.ToDouble(Lector["Cantidad"])), Fuente_Datos));
                PdfPCell Dato_6 = new PdfPCell(new Paragraph(string.Format("{0:d}", (Lector["Fecha"])), Fuente_Datos));
                PdfPCell Dato_7 = new PdfPCell(new Paragraph(Lector["Usuario"].ToString(), Fuente_Datos));
                Dato_1.HorizontalAlignment = 1;
                Dato_1.BorderWidth = 1;
                Dato_2.HorizontalAlignment = 1;
                Dato_2.BorderWidth = 1;
                Dato_3.HorizontalAlignment = 1;
                Dato_3.BorderWidth = 1;
                Dato_4.HorizontalAlignment = 1;
                Dato_4.BorderWidth = 1;
                Dato_5.HorizontalAlignment = 1;
                Dato_5.BorderWidth = 1;
                Dato_6.HorizontalAlignment = 1;
                Dato_6.BorderWidth = 1;
                Dato_7.HorizontalAlignment = 1;
                Dato_7.BorderWidth = 1;
                Tabla_Datos.AddCell(Dato_1);
                Tabla_Datos.AddCell(Dato_2);
                Tabla_Datos.AddCell(Dato_3);
                Tabla_Datos.AddCell(Dato_4);
                Tabla_Datos.AddCell(Dato_5);
                Tabla_Datos.AddCell(Dato_6);
                Tabla_Datos.AddCell(Dato_7);
                J += 1;
            }
            Conexion.Close();
            Documento_Todos.Add(Tabla_Datos);
        }
        /// <summary>
        /// Agrega el encabezado del documento, cuando se imprime todos los movimientos.
        /// </summary>
        private static void Agregar_Encabezados_Todos()
        {
                PdfPTable Tabla_Encabezados = new PdfPTable(6);
                Tabla_Encabezados.HorizontalAlignment = 1;
                Tabla_Encabezados.WidthPercentage = 100;
                PdfPCell Celda_Encabezados = new PdfPCell(new Phrase("Reporte de Movimientos", Fuente_Titulo));
                Celda_Encabezados.HorizontalAlignment = 1;
                Celda_Encabezados.Colspan = 6;
                Celda_Encabezados.BorderWidth = 1;
                Tabla_Encabezados.AddCell(Celda_Encabezados);
                Documento_Todos.Add(Tabla_Encabezados);
                Documento_Todos.Add(new Paragraph(" "));
                Documento_Todos.Add(new Paragraph(" "));
                Documento_Todos.Add(new Paragraph(" "));
                PdfPTable Tabla_Encabezados_1 = new PdfPTable(4);
                Tabla_Encabezados_1.HorizontalAlignment = 1;
                Tabla_Encabezados_1.WidthPercentage = 100;
                PdfPCell Celda_Encabezados_1 = new PdfPCell(new Phrase("Nombre :", Fuente_Datos));
                PdfPCell Celda_Encabezados_2 = new PdfPCell(new Phrase("Usuario :", Fuente_Datos));
                PdfPCell Celda_Encabezados_3 = new PdfPCell(new Phrase(" ", Fuente_Datos));
                PdfPCell Celda_Encabezados_4 = new PdfPCell(new Phrase("Fecha de Creacion", Fuente_Datos));
                Celda_Encabezados_1.HorizontalAlignment = 1;
                Celda_Encabezados_2.HorizontalAlignment = 1;
                Celda_Encabezados_3.HorizontalAlignment = 1;
                Celda_Encabezados_4.HorizontalAlignment = 1;
                Celda_Encabezados_1.BorderWidth = 1;
                Celda_Encabezados_2.BorderWidth = 1;
                Celda_Encabezados_3.BorderWidth = 0;
                Celda_Encabezados_4.BorderWidth = 1;
                Tabla_Encabezados_1.AddCell(Celda_Encabezados_1);
                Tabla_Encabezados_1.AddCell(Celda_Encabezados_2);
                Tabla_Encabezados_1.AddCell(Celda_Encabezados_3);
                Tabla_Encabezados_1.AddCell(Celda_Encabezados_4);
                Documento_Todos.Add(Tabla_Encabezados_1);
                PdfPTable _Tabla_Encabezados_1 = new PdfPTable(4);
                _Tabla_Encabezados_1.HorizontalAlignment = 1;
                _Tabla_Encabezados_1.WidthPercentage = 100;
                PdfPCell _Celda_Encabezados_1 = new PdfPCell(new Phrase(EUsuarios.Nombre + " " + EUsuarios.Apellido, Fuente_Datos));
                PdfPCell _Celda_Encabezados_2 = new PdfPCell(new Phrase(EUsuarios.Usuario, Fuente_Datos));
                PdfPCell _Celda_Encabezados_3 = new PdfPCell(new Phrase(" ", Fuente_Datos));
                PdfPCell _Celda_Encabezados_4 = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), Fuente_Datos));
                _Celda_Encabezados_1.HorizontalAlignment = 1;
                _Celda_Encabezados_2.HorizontalAlignment = 1;
                _Celda_Encabezados_3.HorizontalAlignment = 1;
                _Celda_Encabezados_4.HorizontalAlignment = 1;
                _Celda_Encabezados_1.BorderWidth = 1;
                _Celda_Encabezados_2.BorderWidth = 1;
                _Celda_Encabezados_3.BorderWidth = 0;
                _Celda_Encabezados_4.BorderWidth = 1;
                _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_1);
                _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_2);
                _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_3);
                _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_4);
                Documento_Todos.Add(_Tabla_Encabezados_1);
                Documento_Todos.Add(new Paragraph(" "));
                Documento_Todos.Add(new Paragraph(" "));
                Documento_Todos.Add(new Paragraph(" "));
        }
        /// <summary>
        /// Agrega el encabezado del documento, cuando se imprime los movimientos de entradas.
        /// </summary>
        private static void Agregar_Encabezados_Entradas()
        {
            PdfPTable Tabla_Encabezados = new PdfPTable(6);
            Tabla_Encabezados.HorizontalAlignment = 1;
            Tabla_Encabezados.WidthPercentage = 100;
            PdfPCell Celda_Encabezados = new PdfPCell(new Phrase("Movimientos de Entradas", Fuente_Titulo));
            Celda_Encabezados.HorizontalAlignment = 1;
            Celda_Encabezados.Colspan = 6;
            Celda_Encabezados.BorderWidth = 1;
            Tabla_Encabezados.AddCell(Celda_Encabezados);
            Documento_Entrada.Add(Tabla_Encabezados);
            Documento_Entrada.Add(new Paragraph(" "));
            Documento_Entrada.Add(new Paragraph(" "));
            Documento_Entrada.Add(new Paragraph(" "));
            PdfPTable Tabla_Encabezados_1 = new PdfPTable(4);
            Tabla_Encabezados_1.HorizontalAlignment = 1;
            Tabla_Encabezados_1.WidthPercentage = 100;
            PdfPCell Celda_Encabezados_1 = new PdfPCell(new Phrase("Nombre :", Fuente_Datos));
            PdfPCell Celda_Encabezados_2 = new PdfPCell(new Phrase("Usuario :", Fuente_Datos));
            PdfPCell Celda_Encabezados_3 = new PdfPCell(new Phrase(" ", Fuente_Datos));
            PdfPCell Celda_Encabezados_4 = new PdfPCell(new Phrase("Fecha de Creacion", Fuente_Datos));
            Celda_Encabezados_1.HorizontalAlignment = 1;
            Celda_Encabezados_2.HorizontalAlignment = 1;
            Celda_Encabezados_3.HorizontalAlignment = 1;
            Celda_Encabezados_4.HorizontalAlignment = 1;
            Celda_Encabezados_1.BorderWidth = 1;
            Celda_Encabezados_2.BorderWidth = 1;
            Celda_Encabezados_3.BorderWidth = 0;
            Celda_Encabezados_4.BorderWidth = 1;
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_1);
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_2);
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_3);
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_4);
            Documento_Entrada.Add(Tabla_Encabezados_1);
            PdfPTable _Tabla_Encabezados_1 = new PdfPTable(4);
            _Tabla_Encabezados_1.HorizontalAlignment = 1;
            _Tabla_Encabezados_1.WidthPercentage = 100;
            PdfPCell _Celda_Encabezados_1 = new PdfPCell(new Phrase(EUsuarios.Nombre + " " + EUsuarios.Apellido, Fuente_Datos));
            PdfPCell _Celda_Encabezados_2 = new PdfPCell(new Phrase(EUsuarios.Usuario, Fuente_Datos));
            PdfPCell _Celda_Encabezados_3 = new PdfPCell(new Phrase(" ", Fuente_Datos));
            PdfPCell _Celda_Encabezados_4 = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), Fuente_Datos));
            _Celda_Encabezados_1.HorizontalAlignment = 1;
            _Celda_Encabezados_2.HorizontalAlignment = 1;
            _Celda_Encabezados_3.HorizontalAlignment = 1;
            _Celda_Encabezados_4.HorizontalAlignment = 1;
            _Celda_Encabezados_1.BorderWidth = 1;
            _Celda_Encabezados_2.BorderWidth = 1;
            _Celda_Encabezados_3.BorderWidth = 0;
            _Celda_Encabezados_4.BorderWidth = 1;
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_1);
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_2);
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_3);
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_4);
            Documento_Entrada.Add(_Tabla_Encabezados_1);
            Documento_Entrada.Add(new Paragraph(" "));
            Documento_Entrada.Add(new Paragraph(" "));
            Documento_Entrada.Add(new Paragraph(" "));

        }
        /// <summary>
        /// Agrega el encabezado del documento, cuando se imprime los movimientos de salidas.
        /// </summary>
        private static void Agregar_Encabezados_Salidas()
        {
            PdfPTable Tabla_Encabezados = new PdfPTable(6);
            Tabla_Encabezados.HorizontalAlignment = 1;
            Tabla_Encabezados.WidthPercentage = 100;
            PdfPCell Celda_Encabezados = new PdfPCell(new Phrase("Movimientos de Salidas", Fuente_Titulo));
            Celda_Encabezados.HorizontalAlignment = 1;
            Celda_Encabezados.Colspan = 6;
            Celda_Encabezados.BorderWidth = 1;
            Tabla_Encabezados.AddCell(Celda_Encabezados);
            Documento_Salida.Add(Tabla_Encabezados);
            Documento_Salida.Add(new Paragraph(" "));
            Documento_Salida.Add(new Paragraph(" "));
            Documento_Salida.Add(new Paragraph(" "));
            PdfPTable Tabla_Encabezados_1 = new PdfPTable(4);
            Tabla_Encabezados_1.HorizontalAlignment = 1;
            Tabla_Encabezados_1.WidthPercentage = 100;
            PdfPCell Celda_Encabezados_1 = new PdfPCell(new Phrase("Nombre :", Fuente_Datos));
            PdfPCell Celda_Encabezados_2 = new PdfPCell(new Phrase("Usuario :", Fuente_Datos));
            PdfPCell Celda_Encabezados_3 = new PdfPCell(new Phrase(" ", Fuente_Datos));
            PdfPCell Celda_Encabezados_4 = new PdfPCell(new Phrase("Fecha de Creacion", Fuente_Datos));
            Celda_Encabezados_1.HorizontalAlignment = 1;
            Celda_Encabezados_2.HorizontalAlignment = 1;
            Celda_Encabezados_3.HorizontalAlignment = 1;
            Celda_Encabezados_4.HorizontalAlignment = 1;
            Celda_Encabezados_1.BorderWidth = 1;
            Celda_Encabezados_2.BorderWidth = 1;
            Celda_Encabezados_3.BorderWidth = 0;
            Celda_Encabezados_4.BorderWidth = 1;
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_1);
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_2);
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_3);
            Tabla_Encabezados_1.AddCell(Celda_Encabezados_4);
            Documento_Salida.Add(Tabla_Encabezados_1);
            PdfPTable _Tabla_Encabezados_1 = new PdfPTable(4);
            _Tabla_Encabezados_1.HorizontalAlignment = 1;
            _Tabla_Encabezados_1.WidthPercentage = 100;
            PdfPCell _Celda_Encabezados_1 = new PdfPCell(new Phrase(EUsuarios.Nombre + " " + EUsuarios.Apellido, Fuente_Datos));
            PdfPCell _Celda_Encabezados_2 = new PdfPCell(new Phrase(EUsuarios.Usuario, Fuente_Datos));
            PdfPCell _Celda_Encabezados_3 = new PdfPCell(new Phrase(" ", Fuente_Datos));
            PdfPCell _Celda_Encabezados_4 = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), Fuente_Datos));
            _Celda_Encabezados_1.HorizontalAlignment = 1;
            _Celda_Encabezados_2.HorizontalAlignment = 1;
            _Celda_Encabezados_3.HorizontalAlignment = 1;
            _Celda_Encabezados_4.HorizontalAlignment = 1;
            _Celda_Encabezados_1.BorderWidth = 1;
            _Celda_Encabezados_2.BorderWidth = 1;
            _Celda_Encabezados_3.BorderWidth = 0;
            _Celda_Encabezados_4.BorderWidth = 1;
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_1);
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_2);
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_3);
            _Tabla_Encabezados_1.AddCell(_Celda_Encabezados_4);
            Documento_Salida.Add(_Tabla_Encabezados_1);
            Documento_Salida.Add(new Paragraph(" "));
            Documento_Salida.Add(new Paragraph(" "));
            Documento_Salida.Add(new Paragraph(" "));

        }
    }
}
