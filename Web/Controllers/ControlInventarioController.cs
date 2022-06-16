using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PE_AAUDIT_ACL_WEB.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Controllers.Security;
using Web.Models.Portal;
using System.Runtime.InteropServices;

public class TSCLIB_DLL
{
    [DllImport("TSCLIB.dll", EntryPoint = "about")]
    public static extern int about();

    [DllImport("TSCLIB.dll", EntryPoint = "openport")]
    public static extern int openport(string printername);

    [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
    public static extern int barcode(string x, string y, string type,
                string height, string readable, string rotation,
                string narrow, string wide, string code);

    [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
    public static extern int clearbuffer();

    [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
    public static extern int closeport();

    [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
    public static extern int downloadpcx(string filename, string image_name);

    [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
    public static extern int formfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
    public static extern int nobackfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
    public static extern int printerfont(string x, string y, string fonttype,
                    string rotation, string xmul, string ymul,
                    string text);

    [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
    public static extern int printlabel(string set, string copy);

    [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
    public static extern int sendcommand(string printercommand);

    [DllImport("TSCLIB.dll", EntryPoint = "setup")]
    public static extern int setup(string width, string height,
              string speed, string density,
              string sensor, string vertical,
              string offset);

    [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,
                    int rotation, int fontstyle, int fontunderline,
                    string szFaceName, string content);

}


namespace Web.Controllers
{
    public class ControlInventarioController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ControlInventarioController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _hostingEnvironment = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Import()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            var api = _configuration["Api:root"];

            var delete = await new HttpClient().DeleteAsync(api + "CodigoBarras/deleteCodigoBarrasTMP");

            List<CodigoBarras> list = new List<CodigoBarras>();

            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table table-bordered'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                    
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        CodigoBarras codigoBarras = new CodigoBarras();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");

                        }
                        codigoBarras.Codigo = row.GetCell(0).ToString();
                        codigoBarras.Descripcion = row.GetCell(1).ToString();
                        codigoBarras.Almacen = row.GetCell(3).ToString();
                        codigoBarras.Unidad = row.GetCell(4).ToString();
                        codigoBarras.Stock = Convert.ToDecimal(row.GetCell(5).ToString());

                        list.Add(codigoBarras);

                        
                        var data = await new HttpRestClientServices<string>().PostAsync(api + "CodigoBarras/insertCodigoBarrasTMP", new { codigo = codigoBarras.Codigo, descripcion = codigoBarras.Descripcion, almacen = codigoBarras.Almacen });

                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return Ok(new { value = this.Content(sb.ToString()), List = list, status = true });
        }



        public ActionResult Download()
        {
            string Files = _hostingEnvironment.WebRootPath + "/UploadExcel/CoreProgramm_ExcelImport.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Files);
            System.IO.File.WriteAllBytes(Files, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "employee.xlsx");
        }

        public async Task<IActionResult> Export()
        {
            try
            {
                var api = _configuration["Api:root"];
                var list = await new HttpRestClientServices<string>().GetAsync(api + "CodigoBarras/selectCodigoBarrasTMP");

                JObject jBody = JObject.Parse(list);

                List<CodigoBarras> _lbody = new List<CodigoBarras>();

                for (int i = 0; i < jBody["codigoBarras"].Count(); i++)
                {
                    CodigoBarras _body = new CodigoBarras()
                    {
                        Codigo = (string)jBody["codigoBarras"][i]["codigo"],
                        Descripcion = (string)jBody["codigoBarras"][i]["descripcion"],
                        Almacen = (string)jBody["codigoBarras"][i]["almacen"]
                    };
                    _lbody.Add(_body);
                }

                Document doc = new Document(PageSize.A4);
                doc.SetMargins(36f, 36f, 36f, 36f);
                MemoryStream ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                //// Le colocamos el título y el autor
                //// **Nota: Esto no será visible en el documento
                //Paragraph titulo = new Paragraph("ORDEN DE COMPRA");
                //titulo.Alignment = Element.ALIGN_CENTER;

                //doc.AddTitle("Mi primer PDF");
                //doc.Add(titulo);
                doc.AddCreator("ADGEMINCO");

                // Abrimos el archivo
                doc.Open();

                Font titleFont = FontFactory.GetFont("Arial", 16);
                Font regularFont = FontFactory.GetFont("Arial", 12);


                PdfContentByte cb = writer.DirectContent;

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font _TableHeadFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                iTextSharp.text.Font _TitleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                doc.Add(Chunk.NEWLINE);

                PdfPTable tblHead = new PdfPTable(2);
                tblHead.WidthPercentage = 70;
                float[] widths = new float[] { 20f, 60f };
                tblHead.SetWidths(widths);
                tblHead.DefaultCell.Border = Rectangle.NO_BORDER;


                doc.Add(Chunk.NEWLINE);


                PdfPTable tblBody = new PdfPTable(2);
                tblBody.WidthPercentage = 100;


                for (int i = 0; i < _lbody.Count; i++)
                {

                    Barcode128 bc = new Barcode128();

                    bc.CodeType = Barcode128.CODE128;
                    bc.BarHeight = 60f;
                    bc.Size = 11;
                    bc.Code = _lbody[i].Codigo;
                    bc.AltText = _lbody[i].Codigo;
                    bc.TextAlignment = Element.ALIGN_CENTER;

                    iTextSharp.text.Image PatImage1 = bc.CreateImageWithBarcode(cb, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);
                    PatImage1.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    //PatImage1.ScaleToFit(100f,200f);
                    iTextSharp.text.pdf.PdfPCell img = new iTextSharp.text.pdf.PdfPCell(PatImage1);
                    img.HorizontalAlignment = Element.ALIGN_CENTER;
                    img.BackgroundColor = new BaseColor(255, 255, 255);
                    img.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    var c = new PdfPCell(img);
                    c.Padding = 14;
                    tblBody.AddCell(c);
                }


                doc.Add(tblBody);


                doc.Close();
                writer.Close();
                //ms.seek(0, seekorigin.begin);


                return File(ms.ToArray(), "application/pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
        
        public async Task<IActionResult> ImprimirEtiquetas()
        {
            try
            {
                var api = _configuration["Api:root"];
                var list = await new HttpRestClientServices<string>().GetAsync(api + "CodigoBarras/selectCodigoBarrasTMP");

                JObject jBody = JObject.Parse(list);

                List<CodigoBarras> _lbody = new List<CodigoBarras>();

                for (int i = 0; i < jBody["codigoBarras"].Count(); i++)
                {
                    CodigoBarras _body = new CodigoBarras()
                    {
                        Codigo = (string)jBody["codigoBarras"][i]["codigo"],
                        Descripcion = (string)jBody["codigoBarras"][i]["descripcion"],
                        Almacen = (string)jBody["codigoBarras"][i]["almacen"]
                    };
                    _lbody.Add(_body);
                }

                //for (int i = 0; i < _lbody.Count; i++)
                //{

                //}
                TSCLIB_DLL.openport("TSC TE200");                                                   //Open specified printer driver
                TSCLIB_DLL.setup("108", "25.4", "4", "8", "0", "0", "0");                           //Setup the media size and sensor type info
                TSCLIB_DLL.clearbuffer();                                                           //Clear image buffer
                TSCLIB_DLL.sendcommand("DIRECTION 1,0");
                TSCLIB_DLL.sendcommand("GAP 3 mm,0 mm");

                TSCLIB_DLL.printerfont("30", "20", "2", "0", "1", "1", "TUBO CUADRADO 75x2.00MMx6.00MTS I");       //Drawing printer font
                TSCLIB_DLL.printerfont("130", "180", "2", "0", "1", "1", "ALMACEN VES");                    //Drawing printer font
                TSCLIB_DLL.barcode("80", "50", "128", "100", "2", "0", "2", "2", "105-10010018");           //Drawing barcode

                TSCLIB_DLL.printerfont("450", "20", "2", "0", "1", "1", "TUBO CUADRADO 75x2.00MMx6.00MTS D"); //Drawing printer font
                TSCLIB_DLL.printerfont("550", "180", "2", "0", "1", "1", "ALMACEN VES");                    //Drawing printer font
                TSCLIB_DLL.barcode("500", "50", "128", "100", "2", "0", "2", "2", "105-10010042");          //Drawing barcode

                TSCLIB_DLL.printlabel("1", "1");
                TSCLIB_DLL.closeport();


                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
    }
}
