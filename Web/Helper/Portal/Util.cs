using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;

namespace Web.Helper.Portal
{
    public class Util
    {
        //public static File getPDF()
        //{
            //Document doc = new Document(PageSize.A4);
            //MemoryStream ms = new MemoryStream();
            //PdfWriter writer = PdfWriter.GetInstance(doc,ms);

            //// Le colocamos el título y el autor
            //// **Nota: Esto no será visible en el documento
            //doc.AddTitle("Mi primer PDF");
            //doc.AddCreator("Roberto Torres");

            //// Abrimos el archivo
            //doc.Open();

            //PdfContentByte cb = writer.DirectContent;

            //iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //Barcode128 bc = new Barcode128();
            //bc.CodeType = Barcode128.CODE128;
            //bc.Code = "123456";
            //bc.AltText = "123456";
            //bc.TextAlignment = Barcode128.SHIFT;

            //iTextSharp.text.Image PatImage1 = bc.CreateImageWithBarcode(cb, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);
            //PatImage1.ScaleAbsolute(480f, 175.25f);
            //PdfPCell palletBarcodeCell = new PdfPCell(PatImage1);
            //palletBarcodeCell.Border = iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER;
            //palletBarcodeCell.Colspan = 2;
            //palletBarcodeCell.FixedHeight = 61f;
            //palletBarcodeCell.HorizontalAlignment = 1;
            //palletBarcodeCell.VerticalAlignment = 1;

            //// Escribimos el encabezamiento en el documento
            //doc.Add(new Paragraph("Mi primer documento PDF"));
            //doc.Add(Chunk.NEWLINE);

            //// Creamos una tabla que contendrá el nombre, apellido y país
            //// de nuestros visitante.
            //PdfPTable tblPrueba = new PdfPTable(3);
            //tblPrueba.WidthPercentage = 100;

            //// Configuramos el título de las columnas de la tabla
            //PdfPCell clCodigo = new PdfPCell(new Phrase("Codigo", _standardFont));
            //clCodigo.BorderWidth = 0;
            //clCodigo.BorderWidthBottom = 0.75f;

            //PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            //clNombre.BorderWidth = 0;
            //clNombre.BorderWidthBottom = 0.75f;

            //PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            //clApellido.BorderWidth = 0;
            //clApellido.BorderWidthBottom = 0.75f;

            //PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            //clPais.BorderWidth = 0;
            //clPais.BorderWidthBottom = 0.75f;

            //// Añadimos las celdas a la tabla
            //tblPrueba.AddCell(clCodigo);
            //tblPrueba.AddCell(clNombre);
            //tblPrueba.AddCell(clApellido);
            //tblPrueba.AddCell(clPais);

            //clCodigo = palletBarcodeCell;
            //clCodigo.BorderWidth = 0;
            //// Llenamos la tabla con información
            //clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            //clNombre.BorderWidth = 0;

            //clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            //clApellido.BorderWidth = 0;

            //clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            //clPais.BorderWidth = 0;

            //// Añadimos las celdas a la tabla
            //tblPrueba.AddCell(clNombre);
            //tblPrueba.AddCell(clApellido);
            //tblPrueba.AddCell(clPais);

            //doc.Add(tblPrueba);

            //writer.Close();
            //doc.Close();
            //ms.Seek(0, SeekOrigin.Begin);


            //return File(ms,"application/pdf");
        //}
    }
}
