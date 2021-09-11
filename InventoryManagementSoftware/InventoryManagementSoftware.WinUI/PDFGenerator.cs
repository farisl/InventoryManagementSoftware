using eProdaja.Filters;
using InventoryManagementSoftware.Model.Requests;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSoftware.WinUI
{
    public class PDFGenerator
    {
        private readonly APIService _exportService = new APIService("Export");
        private readonly APIService _exportDetailService = new APIService("ExportDetail");
        private readonly APIService _importService = new APIService("Import");
        private readonly APIService _importDetailService = new APIService("ImportDetail");

        private const float MarginLeft = 40f;
        private const float MarginRight = 40f;
        private const float MarginTop = 150f;
        private const float MarginBottom = 60f;
        private const float FontHeaderSize = 22f;
        private const float ParagraphItemsSize = 13.3f;
        private const float ParagraphDetailsItemsSize = 11f;
        private const float BasicFontSize = 12f;

        public async void ExportToPdf()
        {
            try
            {
                var exports = await _exportService.Get<List<Model.Export>>();
                Document pdfDoc = new Document(PageSize.LETTER, MarginLeft, MarginRight, MarginTop, MarginBottom);
                string ApplicationLocation = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"../../../..\\Reports"));
                string FileName = Path.Combine(ApplicationLocation, "Exports.pdf");
                PdfWriter.GetInstance(pdfDoc, new FileStream(FileName, FileMode.OpenOrCreate));
                pdfDoc.Open();

                var imagepath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../..\\Reports\\ims.png"));
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                    png.ScalePercent(15f);
                    png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                    pdfDoc.Add(png);
                }

                var spacer = new Paragraph("")
                {
                    SpacingBefore = 5f,
                    SpacingAfter = 5f,
                };
                pdfDoc.Add(spacer);

                var fontStyle = FontFactory.GetFont("Arial", ParagraphItemsSize, Font.NORMAL, BaseColor.BLACK);
                var basicFontStyle = FontFactory.GetFont("Arial", BasicFontSize, Font.NORMAL, BaseColor.BLACK);

                var headerStyle = FontFactory.GetFont("Arial", FontHeaderSize, Font.BOLD, BaseColor.BLACK);
                var headerText = new Paragraph("EXPORTS", headerStyle);
                headerText.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(headerText);
                pdfDoc.Add(spacer);
                Paragraph horizontalLineBreak = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                foreach (var item in exports.OrderBy(x => x.Date))
                {
                    var StringDate = new Paragraph("Date:", fontStyle);
                    var ExportDate = new Paragraph(item.DateString);
                    var StringInventory = new Paragraph("Inventory:", fontStyle);
                    var ExportInventory = new Paragraph(item.InventoryName);
                    var StringCustomer = new Paragraph("Customer:", fontStyle);
                    var ExportCustomer = new Paragraph(item.CustomerName);

                    pdfDoc.Add(StringDate);
                    pdfDoc.Add(ExportDate);
                    pdfDoc.Add(StringInventory);
                    pdfDoc.Add(ExportInventory);
                    pdfDoc.Add(StringCustomer);
                    pdfDoc.Add(ExportCustomer);

                    pdfDoc.Add(spacer);

                    var exportDetails = await _exportDetailService.Get<List<Model.ExportDetail>>(new ImportExportDetailSearchObject
                    {
                        ImportExportId = item.Id
                    });
                    var ExportDetailsHeaderText = new Paragraph($"EXPORT DETAILS", headerStyle);
                    pdfDoc.Add(ExportDetailsHeaderText);
                    pdfDoc.Add(spacer);
                    pdfDoc.Add(spacer);

                    foreach (var x in exportDetails)
                    {
                        var exportDetailFontStyle = new Font(Font.FontFamily.UNDEFINED, ParagraphDetailsItemsSize, Font.BOLD, BaseColor.RED);
                        var StringProduct = new Paragraph("Product name: ", exportDetailFontStyle);
                        var ExportDetailProduct = new Paragraph(x.ProductName);
                        var StringQuantity = new Paragraph("Quantity: ", exportDetailFontStyle);
                        var ExportDetailQuantity = new Paragraph(x.Quantity.ToString());
                        var StringDiscount = new Paragraph("Discount: ", exportDetailFontStyle);
                        var ExportDetailDiscount = new Paragraph($"{x.Discount * 100}%");
                        var StringPrice = new Paragraph("Total price: ", exportDetailFontStyle);
                        var ExportDetailPrice = new Paragraph($"${x.Price.ToString()}");

                        pdfDoc.Add(StringProduct);
                        pdfDoc.Add(ExportDetailProduct);
                        pdfDoc.Add(StringQuantity);
                        pdfDoc.Add(ExportDetailQuantity);
                        pdfDoc.Add(StringDiscount);
                        pdfDoc.Add(ExportDetailDiscount);
                        pdfDoc.Add(StringPrice);
                        pdfDoc.Add(ExportDetailPrice);

                        pdfDoc.Add(spacer);
                    }

                    pdfDoc.Add(spacer);
                    pdfDoc.Add(spacer);
                    pdfDoc.Add(horizontalLineBreak);

                }
                pdfDoc.Close();
            }
            catch(Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public async void ImportToPdf()
        {
            try
            {
                var imports = await _importService.Get<List<Model.Import>>();
                Document pdfDoc = new Document(PageSize.LETTER, MarginLeft, MarginRight, MarginTop, MarginBottom);
                string ApplicationLocation = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"../../../..\\Reports"));
                string FileName = Path.Combine(ApplicationLocation, "Imports.pdf");
                PdfWriter.GetInstance(pdfDoc, new FileStream(FileName, FileMode.OpenOrCreate));
                pdfDoc.Open();

                var imagepath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../..\\Reports\\ims.png"));
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                    png.ScalePercent(15f);
                    png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                    pdfDoc.Add(png);
                }

                var spacer = new Paragraph("")
                {
                    SpacingBefore = 5f,
                    SpacingAfter = 5f,
                };
                pdfDoc.Add(spacer);

                var fontStyle = FontFactory.GetFont("Arial", ParagraphItemsSize, Font.NORMAL, BaseColor.BLACK);
                var basicFontStyle = FontFactory.GetFont("Arial", BasicFontSize, Font.NORMAL, BaseColor.BLACK);

                var headerStyle = FontFactory.GetFont("Arial", FontHeaderSize, Font.BOLD, BaseColor.BLACK);
                var headerText = new Paragraph("IMPORTS", headerStyle);
                headerText.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(headerText);
                pdfDoc.Add(spacer);
                Paragraph horizontalLineBreak = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                foreach (var item in imports.OrderBy(x => x.Date))
                {
                    var StringDate = new Paragraph("Date:", fontStyle);
                    var ImportDate = new Paragraph(item.DateString);
                    var StringInventory = new Paragraph("Inventory:", fontStyle);
                    var ImportInventory = new Paragraph(item.InventoryName);
                    var StringSupplier = new Paragraph("Customer:", fontStyle);
                    var ImportSupplier = new Paragraph(item.SupplierName);

                    pdfDoc.Add(StringDate);
                    pdfDoc.Add(ImportDate);
                    pdfDoc.Add(StringInventory);
                    pdfDoc.Add(ImportInventory);
                    pdfDoc.Add(StringSupplier);
                    pdfDoc.Add(ImportSupplier);

                    pdfDoc.Add(spacer);

                    var importDetails = await _importDetailService.Get<List<Model.ImportDetail>>(new ImportExportDetailSearchObject
                    {
                        ImportExportId = item.Id
                    });
                    var ImportDetailsHeaderText = new Paragraph($"IMPORT DETAILS", headerStyle);
                    pdfDoc.Add(ImportDetailsHeaderText);
                    pdfDoc.Add(spacer);
                    pdfDoc.Add(spacer);

                    foreach (var x in importDetails)
                    {
                        var importDetailFontStyle = new Font(Font.FontFamily.UNDEFINED, ParagraphDetailsItemsSize, Font.BOLD, BaseColor.RED);
                        var StringProduct = new Paragraph("Product name: ", importDetailFontStyle);
                        var ImportDetailProduct = new Paragraph(x.ProductName);
                        var StringQuantity = new Paragraph("Quantity: ", importDetailFontStyle);
                        var ImportDetailQuantity = new Paragraph(x.Quantity.ToString());
                        var StringDiscount = new Paragraph("Discount: ", importDetailFontStyle);
                        var ImportDetailDiscount = new Paragraph($"{x.Discount * 100}%");
                        var StringPrice = new Paragraph("Total price: ", importDetailFontStyle);
                        var ImportDetailPrice = new Paragraph($"${x.Price.ToString()}");

                        pdfDoc.Add(StringProduct);
                        pdfDoc.Add(ImportDetailProduct);
                        pdfDoc.Add(StringQuantity);
                        pdfDoc.Add(ImportDetailQuantity);
                        pdfDoc.Add(StringDiscount);
                        pdfDoc.Add(ImportDetailDiscount);
                        pdfDoc.Add(StringPrice);
                        pdfDoc.Add(ImportDetailPrice);

                        pdfDoc.Add(spacer);
                    }

                    pdfDoc.Add(spacer);
                    pdfDoc.Add(spacer);
                    pdfDoc.Add(horizontalLineBreak);

                }
                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }
    }
}
