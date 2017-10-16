
using System;
using System.Collections.Generic;
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


using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using NegLibrary;
using EntityLibrary;
using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.IO.Image;

namespace View
{
    /// <summary>
    /// Lógica de interacción para MenuReporteValoracionPage.xaml
    /// </summary>
    public partial class MenuReporteValoracionPage : Page
    {

        ReporteValoracionNeg reporteValoracionNeg;
        public MenuReporteValoracionPage()
        {
            if (reporteValoracionNeg == null)
                reporteValoracionNeg = new ReporteValoracionNeg();
            InitializeComponent();
        }

        private void btnReporteValoracion_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DateTime fechaInicio = (DateTime)dpFechaInicio.SelectedDate;
                DateTime fechaFin = (DateTime)dpFechaTermino.SelectedDate;

                List<ReporteValoracion> listaRegistros = reporteValoracionNeg.listaRegistrosReporteValoracion(fechaInicio, fechaFin);
                //Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                String rutaDirectorioOferta = "D:/MisOfertas/Reportes/";
                List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                if (!Directory.Exists(rutaDirectorioOferta))
                    Directory.CreateDirectory(rutaDirectorioOferta);
                String rutaReporte = rutaDirectorioOferta + "/ReporteValoracion" + DateTime.Now.ToShortDateString()+".pdf";

                PdfWriter writer = new PdfWriter(rutaReporte);  
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf,PageSize.A4);
                PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);


                //iText.IO.Image.ImageDataFactory.Create("D:/Portafolio 2017/MisOfertasEscritorio/Seba/Satelite_MisOfertas/View/img/MisOfertas-Letras.png", false);

                document.Add(new iText.Layout.Element.Paragraph("Reporte valoracion de ofertas").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                document.Add(new iText.Layout.Element.Paragraph(DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToShortTimeString()).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(18));

                float[] columnWidths = { 20f, 60f, 60f, 30f, 50f, 80f, 50f, 50f, 50f, 50f };//{1,1,10,10,5,5,1,1,1,1,1,1};
              
                iText.Layout.Element.Table tableRegistros = new iText.Layout.Element.Table(columnWidths).SetFontSize(12);
                //tableRegistros.SetWidthPercent(100);
                
                float fontCell = 11;
                float fontCellData = 9;

                Cell[] headerFooter = new Cell[] {
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Oferta").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Inicio").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Finalizacion").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Rubro").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Empresa").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Val. Negativas").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Val. Medias").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Val. Positivas").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Total").SetFontSize(fontCell) };
                //new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Productos").SetFontSize(fontCell),
                //new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Imagenes").SetFontSize(fontCell)};


                foreach (Cell hfCell in headerFooter){
                        tableRegistros.AddHeaderCell(hfCell);
                }

                for (int i=0;i<listaRegistros.Count;i++)
                {
                    ReporteValoracion reporte = listaRegistros[i];
                    Oferta oferta = reporte.Oferta;
                    Rubro rubro = reporte.Rubro;
                    Empresa empresa = reporte.Empresa;
                    tableRegistros.AddCell(oferta.IdOferta.ToString()).SetFontSize(fontCellData).SetWidth(5);
                    tableRegistros.AddCell(oferta.TituloOferta).SetFontSize(fontCellData).SetWidth(5);
                    tableRegistros.AddCell(oferta.FechaInicio.ToShortDateString()).SetFontSize(fontCellData).SetWidth(700);
                    tableRegistros.AddCell(oferta.FechaFinalizacion.ToShortDateString()).SetFontSize(fontCellData).SetWidth(7);
                    tableRegistros.AddCell(rubro.DescripcionRubro).SetFontSize(fontCellData);
                    tableRegistros.AddCell(empresa.NombreEmpresa).SetFontSize(fontCellData);
                    tableRegistros.AddCell(reporte.CantValoracionNegativas.ToString()).SetFontSize(fontCellData);
                    tableRegistros.AddCell(reporte.CantValoracionMedia.ToString()).SetFontSize(fontCellData);
                    tableRegistros.AddCell(reporte.CantValoracionPositiva.ToString()).SetFontSize(fontCellData);
                    tableRegistros.AddCell(reporte.CantValoracionTotal.ToString()).SetFontSize(fontCellData);
                    
                }

                //tableRegistros.AddCell(reporte.CantProductos.ToString()).SetFontSize(fontCellData);
                //tableRegistros.AddCell(reporte.CantImagenes.ToString()).SetFontSize(fontCellData);
                document.Add(tableRegistros);
                document.Close();

            }
            catch (Exception err)
            {

            }

        }
    }
}
