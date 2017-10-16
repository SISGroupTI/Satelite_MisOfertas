using EntityLibrary;
using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Lógica de interacción para MenuReporteTiendaPage.xaml
    /// </summary>
    public partial class MenuReporteTiendaPage : Page
    {
        ReporteTiendasNeg reporteTiendasNeg;

        public MenuReporteTiendaPage()
        {
            if (reporteTiendasNeg == null)
                reporteTiendasNeg = new ReporteTiendasNeg();
            InitializeComponent();
        }

        private void btnReporteTienda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ReporteTiendas> listaConsumidoresRegistradosDia = reporteTiendasNeg.listaConsumidoresRegistradosDia();
                List<ReporteTiendas> listaConsumidoresRegistradosMes = reporteTiendasNeg.listaConsumidoresRegistradosMes();


                String rutaDirectorioOferta = "D:/MisOfertas/Reportes/";
                List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                if (!Directory.Exists(rutaDirectorioOferta))
                    Directory.CreateDirectory(rutaDirectorioOferta);
                String rutaReporte = rutaDirectorioOferta + "/ReporteTiendas" + DateTime.Now.ToShortDateString() + ".pdf";

                PdfWriter writer = new PdfWriter(rutaReporte);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.A4);
                PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

                document.Add(new iText.Layout.Element.Paragraph("Reporte resumenes por tiendas y empresas").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                document.Add(new iText.Layout.Element.Paragraph(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(18));
                float fontCell = 11;
                float fontCellData = 9;

                //----------------TABLA CONSUMIDORES REGISTRADOR POR DIA-------------------------------
                float[] columnWidthsDIa = { 20f, 60f, 120f, 30f, 30f };

                iText.Layout.Element.Table tableConsumidoresDia = new iText.Layout.Element.Table(columnWidthsDIa).SetFontSize(12);
                tableConsumidoresDia.SetWidthPercent(100);

                Cell[] headerFooter = new Cell[] {
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Año").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Mes").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Dia").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Consumidores").SetFontSize(fontCell)};

                foreach (Cell hfCell in headerFooter){
                    tableConsumidoresDia.AddHeaderCell(hfCell);
                }


                for (int i = 0; i < listaConsumidoresRegistradosDia.Count; i++){
                    ReporteTiendas reporte = listaConsumidoresRegistradosDia[i];
                    tableConsumidoresDia.AddCell(i.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresDia.AddCell(reporte.AnioRegistro.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresDia.AddCell(reporte.MesRegistro.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresDia.AddCell(reporte.DiaRegistro.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresDia.AddCell(reporte.ConsumidoresRegistradosDia.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                }

                document.Add(tableConsumidoresDia.SetPaddingBottom(15f));


                //----------------TABLA CONSUMIDORES REGISTRADOR POR MES-------------------------------


                float[] columnWidthsMes = { 20f, 60f, 120f, 30f};

                iText.Layout.Element.Table tableConsumidoresMes = new iText.Layout.Element.Table(columnWidthsMes).SetFontSize(12);
                tableConsumidoresMes.SetWidthPercent(100);
               

                Cell[] cellsConsumidoresMes = new Cell[] {
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Año").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Mes").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Consumidores").SetFontSize(fontCell)};

                foreach (Cell hfCell in cellsConsumidoresMes)
                {
                    tableConsumidoresMes.AddHeaderCell(hfCell);
                }

                for (int i = 0; i < listaConsumidoresRegistradosMes.Count; i++)
                {
                    ReporteTiendas reporte = listaConsumidoresRegistradosMes[i];
                    tableConsumidoresMes.AddCell(i.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresMes.AddCell(reporte.AnioRegistro.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresMes.AddCell(reporte.MesRegistro.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    tableConsumidoresMes.AddCell(reporte.ConsumidoresRegistradosMes.ToString()).SetFontSize(fontCellData).SetWidth(5).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                }

                document.Add(tableConsumidoresMes.SetPaddingTop(15f));


                document.Close();

            }
            catch (Exception err)
            {

            }
        }
    }
}
