using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers.Security;
using BarcodeLib;
using PE_AAUDIT_ACL_WEB.Helper;
using Microsoft.Extensions.Configuration;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using Web.Models.Portal;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Web.Controllers
{
    public class CodigoBarrasController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public CodigoBarrasController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        public IActionResult ImpresionEtiquetas()
        {
            return View();
        }
        public IActionResult EscaneoProductos()
        {
            return View();
        }
        public IActionResult Interface()
        {
            return View();
        }

        public async Task<IActionResult> getBarraCodigoOC(string id)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "CodigoBarras/getBarraCodigoOC", new { idReq = id, empresa = UsuarioLogueado.CodEmpresa });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> getBarraCodigoOCD(string id)
        {
            try
            {
                var api = _configuration["Api:root"];
                var data = await new HttpRestClientServices<string>().PostAsync(api + "CodigoBarras/getBarraCodigoOCD", new { idReq = id, empresa = UsuarioLogueado.CodEmpresa });
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> getPDF([FromBody] FForm form)
        {
            try
            {
                var api = _configuration["Api:root"];
                var header = await new HttpRestClientServices<string>().PostAsync(api + "CodigoBarras/getBarraCodigoOC", new { idReq = form.id, empresa = UsuarioLogueado.CodEmpresa });
                var body = await new HttpRestClientServices<string>().PostAsync(api + "CodigoBarras/getBarraCodigoOCD", new { idReq = form.id, empresa = UsuarioLogueado.CodEmpresa });

                JObject jHeader = JObject.Parse(header);
                OrdenCompra _header = new OrdenCompra()
                {
                    OCompra  = (string)jHeader["codigoBarrasOC"][0]["OCompra"],
                    FecOCompra = (DateTime)jHeader["codigoBarrasOC"][0]["FecOCompra"],
                    REQUERIM = (string)jHeader["codigoBarrasOC"][0]["REQUERIM"],
                    FecEntrega = (DateTime)jHeader["codigoBarrasOC"][0]["FecEntrega"],
                    RUCProv = (string)jHeader["codigoBarrasOC"][0]["RUCProv"],
                    RazonSocial = (string)jHeader["codigoBarrasOC"][0]["RazonSocial"],
                    DetalleOC = (string)jHeader["codigoBarrasOC"][0]["DetalleOC"],
                    Comprador = (string)jHeader["codigoBarrasOC"][0]["Comprador"],
                    Solicitante = (string)jHeader["codigoBarrasOC"][0]["Solicitante"]
                };
                
                JObject jBody = JObject.Parse(body);

                List<OrdenCompraDetalle> _lbody = new List<OrdenCompraDetalle>();

                for (int i = 0; i < jBody["codigoBarrasOCD"].Count(); i++)
                {
                    OrdenCompraDetalle _body = new OrdenCompraDetalle()
                    {
                        ITEM = (string)jBody["codigoBarrasOCD"][i]["ITEM"],
                        CODIGO = (string)jBody["codigoBarrasOCD"][i]["CODIGO"],
                        DETALLEPROD = (string)jBody["codigoBarrasOCD"][i]["DETALLEPROD"],
                        UNIDAD = (string)jBody["codigoBarrasOCD"][i]["UNIDAD"],
                        CANT = (decimal)jBody["codigoBarrasOCD"][i]["CANT"],
                        COMENTARIO = (string)jBody["codigoBarrasOCD"][i]["COMENTARIO"],
                        FecOCompra = (DateTime)jBody["codigoBarrasOCD"][i]["FecOCompra"],
                        CCosto = (string)jBody["codigoBarrasOCD"][i]["CCosto"]
                    };
                    _lbody.Add(_body);
                }
                

                Document doc = new Document(PageSize.A4);
                doc.SetMargins(36f, 36f, 36f, 36f);
                MemoryStream ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                Paragraph titulo = new Paragraph("ORDEN DE COMPRA");
                titulo.Alignment = Element.ALIGN_CENTER;

                //doc.AddTitle("Mi primer PDF");
                //doc.Add(titulo);
                doc.AddCreator("ADGEMINCO");

                // Abrimos el archivo
                doc.Open();

                string imageURL = Path.Combine(_env.WebRootPath, "img/logos", UsuarioLogueado.CodEmpresa.ToString() + ".png");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                //Resize image depend upon your need
                jpg.ScaleToFit(140f, 120f);
                //Give space before image
                jpg.SpacingBefore = 10f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_LEFT;

                doc.Add(jpg);

                Font titleFont = FontFactory.GetFont("Arial", 16);
                Font regularFont = FontFactory.GetFont("Arial", 12);
                Paragraph title;
                Paragraph subtitle;
                title = new Paragraph("Orden de Compra", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                subtitle = new Paragraph(_header.OCompra + " | " + _header.FecOCompra.ToString("dd/MM/yyyy"), regularFont);
                subtitle.Alignment = Element.ALIGN_CENTER;
                doc.Add(subtitle);

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

                PdfPCell RequerimientoTitle = new PdfPCell(new Phrase("Requerimiento(s): ", _TitleFont));
                PdfPCell RequerimientoValue = new PdfPCell(new Phrase(_header.REQUERIM, _standardFont));
                RequerimientoTitle.BorderWidth = 0;
                RequerimientoValue.BorderWidth = 0;
                tblHead.AddCell(RequerimientoTitle);
                tblHead.AddCell(RequerimientoValue);

                PdfPCell RUCProveedorTitle = new PdfPCell(new Phrase("RUC Proveedor: ", _TitleFont));
                PdfPCell RUCProveedorValue = new PdfPCell(new Phrase(_header.RUCProv, _standardFont));
                RUCProveedorTitle.BorderWidth = 0;
                RUCProveedorValue.BorderWidth = 0;
                tblHead.AddCell(RUCProveedorTitle);
                tblHead.AddCell(RUCProveedorValue);

                PdfPCell RazonSocialTitle = new PdfPCell(new Phrase("Razón Social: ", _TitleFont));
                PdfPCell RazonSocialValue = new PdfPCell(new Phrase(_header.RazonSocial, _standardFont));
                RazonSocialTitle.BorderWidth = 0;
                RazonSocialValue.BorderWidth = 0;
                tblHead.AddCell(RazonSocialTitle);
                tblHead.AddCell(RazonSocialValue);

                PdfPCell FechaEntregaTitle = new PdfPCell(new Phrase("Fecha de Entrega: ", _TitleFont));
                PdfPCell FechaEntregaValue = new PdfPCell(new Phrase(_header.FecEntrega.ToString("dd/MM/yyyy"), _standardFont));
                FechaEntregaTitle.BorderWidth = 0;
                FechaEntregaValue.BorderWidth = 0;
                tblHead.AddCell(FechaEntregaTitle);
                tblHead.AddCell(FechaEntregaValue);

                PdfPCell DetalleOCTitle = new PdfPCell(new Phrase("Detalle de OC: ", _TitleFont));
                PdfPCell DetalleOCValue = new PdfPCell(new Phrase(_header.DetalleOC, _standardFont));
                DetalleOCTitle.BorderWidth = 0;
                DetalleOCValue.BorderWidth = 0;
                tblHead.AddCell(DetalleOCTitle);
                tblHead.AddCell(DetalleOCValue);

                PdfPCell EspacioTitle = new PdfPCell(new Phrase(" ", _TitleFont));
                PdfPCell EspacioValue = new PdfPCell(new Phrase(" ", _standardFont));
                EspacioTitle.BorderWidth = 0;
                EspacioValue.BorderWidth = 0;
                tblHead.AddCell(EspacioTitle);
                tblHead.AddCell(EspacioValue);

                PdfPCell CompradorTitle = new PdfPCell(new Phrase("Comprador: ", _TitleFont));
                PdfPCell CompradorValue = new PdfPCell(new Phrase(_header.Comprador, _standardFont));
                CompradorTitle.BorderWidth = 0;
                CompradorValue.BorderWidth = 0;
                tblHead.AddCell(CompradorTitle);
                tblHead.AddCell(CompradorValue);

                PdfPCell SolicitanteTitle = new PdfPCell(new Phrase("Solicitante: ", _TitleFont));
                PdfPCell SolicitanteValue = new PdfPCell(new Phrase(_header.Solicitante, _standardFont));
                SolicitanteTitle.BorderWidth = 0;
                SolicitanteValue.BorderWidth = 0;
                tblHead.AddCell(SolicitanteTitle);
                tblHead.AddCell(SolicitanteValue);

                doc.Add(tblHead);


                doc.Add(Chunk.NEWLINE);


                PdfPTable tblBody = new PdfPTable(5);
                tblBody.WidthPercentage = 100;

                // Configuramos el título de las columnas de la tabla
                PdfPCell clCodigoBarras = new PdfPCell(new Phrase("CODIGO BARRAS", _TableHeadFont));
                clCodigoBarras.VerticalAlignment = Element.ALIGN_CENTER;
                clCodigoBarras.HorizontalAlignment = Element.ALIGN_CENTER;
                clCodigoBarras.BackgroundColor = BaseColor.DARK_GRAY;
                clCodigoBarras.BorderWidth = 0;
                clCodigoBarras.BorderWidthBottom = 0.75f;

                PdfPCell clCodigo = new PdfPCell(new Phrase("CODIGO", _TableHeadFont));
                clCodigo.VerticalAlignment = Element.ALIGN_CENTER;
                clCodigo.HorizontalAlignment = Element.ALIGN_CENTER;
                clCodigo.BackgroundColor = BaseColor.DARK_GRAY;
                clCodigo.BorderWidth = 0;
                clCodigo.BorderWidthBottom = 0.75f;

                PdfPCell clDetProd = new PdfPCell(new Phrase("DETALLE PRODUCTO", _TableHeadFont));
                clDetProd.VerticalAlignment = Element.ALIGN_CENTER;
                clDetProd.HorizontalAlignment = Element.ALIGN_CENTER;
                clDetProd.BackgroundColor = BaseColor.DARK_GRAY;
                clDetProd.BorderWidth = 0;
                clDetProd.BorderWidthBottom = 0.75f;

                PdfPCell clUnidad = new PdfPCell(new Phrase("UNIDAD", _TableHeadFont));
                clUnidad.VerticalAlignment = Element.ALIGN_CENTER;
                clUnidad.HorizontalAlignment = Element.ALIGN_CENTER;
                clUnidad.BackgroundColor = BaseColor.DARK_GRAY;
                clUnidad.BorderWidth = 0;
                clUnidad.BorderWidthBottom = 0.75f;

                PdfPCell clCantidad = new PdfPCell(new Phrase("CANTIDAD", _TableHeadFont));
                clCantidad.VerticalAlignment = Element.ALIGN_CENTER;
                clCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                clCantidad.BackgroundColor = BaseColor.DARK_GRAY;
                clCantidad.BorderWidth = 0;
                clCantidad.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tblBody.AddCell(clCodigoBarras);
                tblBody.AddCell(clCodigo);
                tblBody.AddCell(clDetProd);
                tblBody.AddCell(clUnidad);
                tblBody.AddCell(clCantidad);


                for (int i = 0; i < _lbody.Count; i++)
                {

                    Barcode128 bc = new Barcode128();
                    bc.CodeType = Barcode128.CODE128;
                    bc.Code = _lbody[i].CODIGO;
                    bc.TextAlignment = Barcode128.SHIFT;

                    iTextSharp.text.Image PatImage1 = bc.CreateImageWithBarcode(cb, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);
                    PatImage1.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    PatImage1.ScaleToFit(60f, 77.6f);
                    iTextSharp.text.pdf.PdfPCell img = new iTextSharp.text.pdf.PdfPCell(PatImage1);
                    img.HorizontalAlignment = Element.ALIGN_CENTER;
                    img.BackgroundColor = new BaseColor(255, 255, 255);
                    img.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    // Llenamos la tabla con información

                    clCodigo = new PdfPCell(new Phrase(_lbody[i].CODIGO, _standardFont));
                    clCodigo.VerticalAlignment = Element.ALIGN_CENTER;
                    clCodigo.HorizontalAlignment = Element.ALIGN_CENTER;
                    clCodigo.BorderWidth = 0;
                    clCodigo.BorderWidthBottom = 0.75f;

                    clDetProd = new PdfPCell(new Phrase(_lbody[i].DETALLEPROD, _standardFont));
                    clDetProd.VerticalAlignment = Element.ALIGN_CENTER;
                    clDetProd.HorizontalAlignment = Element.ALIGN_CENTER;
                    clDetProd.BorderWidth = 0;
                    clDetProd.BorderWidthBottom = 0.75f;

                    clUnidad = new PdfPCell(new Phrase(_lbody[i].UNIDAD, _standardFont));
                    clUnidad.VerticalAlignment = Element.ALIGN_CENTER;
                    clUnidad.HorizontalAlignment = Element.ALIGN_CENTER;
                    clUnidad.BorderWidth = 0;
                    clUnidad.BorderWidthBottom = 0.75f;

                    clCantidad = new PdfPCell(new Phrase(_lbody[i].CANT.ToString("0.00"), _standardFont));
                    clCantidad.VerticalAlignment = Element.ALIGN_CENTER;
                    clCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                    clCantidad.BorderWidth = 0;
                    clCantidad.BorderWidthBottom = 0.75f;

                    // Añadimos las celdas a la tabla
                    tblBody.AddCell(img);
                    tblBody.AddCell(clCodigo);
                    tblBody.AddCell(clDetProd);
                    tblBody.AddCell(clUnidad);
                    tblBody.AddCell(clCantidad);
                }


                doc.Add(tblBody);
                
                
                doc.Close();
                writer.Close();
                //ms.Seek(0, SeekOrigin.Begin);


                return File(ms.ToArray(), "application/pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

    }
}
