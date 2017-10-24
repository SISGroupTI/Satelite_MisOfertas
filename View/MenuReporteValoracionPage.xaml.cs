
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
using System.Reflection;

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

        public bool validarFechas()
        {
            if (dpFechaInicio.SelectedDate != null && dpFechaTermino.SelectedDate != null)
            {
                if (dpFechaInicio.SelectedDate < dpFechaTermino.SelectedDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
               
        }


        private void btnReporteValoracion_Click(object sender, RoutedEventArgs e)
        {
            if (!validarFechas())
            {
                MessageBox.Show("La fecha de inicio debe ser menor a la de termino\n Ingrese nuevamente", "Reporteria - Mis Ofertas");
                dpFechaInicio.Focus();
            }
            else
            {
                try
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    List<ReporteValoracion> listaRegistros = new List<ReporteValoracion>();

                    if (dpFechaInicio.SelectedDate == null && dpFechaTermino.SelectedDate == null)
                    {
                        listaRegistros = reporteValoracionNeg.listaRegistrosReporteValoracion(null, null);
                    }
                    else
                    {
                        listaRegistros = reporteValoracionNeg.listaRegistrosReporteValoracion(
                            dpFechaInicio.SelectedDate,
                            dpFechaTermino.SelectedDate);
                    }


                    String rutaDirectorioOferta = "D:/MisOfertas/Reportes/";
                    List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                    if (!Directory.Exists(rutaDirectorioOferta))
                        Directory.CreateDirectory(rutaDirectorioOferta);

                    DateTime fechaCreacionReporte = DateTime.Now;
                    String rutaReporte = rutaDirectorioOferta + "/ReporteValoracion" + fechaCreacionReporte.ToString("ddMMyyyyHHmm") + ".pdf";

                    PdfWriter writer = new PdfWriter(rutaReporte);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, PageSize.A4);
                    PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);


                    string _filePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                    _filePath = Directory.GetParent(_filePath).FullName;
                    _filePath = Directory.GetParent(_filePath).FullName;
                    _filePath += @"\img\MisOfertas-Letras.png";

                    //string ruta_imagen = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"img\MisOfertas-Letras.png");
                    //String ruta_imagen = "D:/Portafolio 2017/MisOfertasEscritorio/Seba/Satelite_MisOfertas/View/img/MisOfertas-Letras.png";
                    document.Add(new iText.Layout.Element.Image(ImageDataFactory.Create(_filePath)).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT).SetWidth(40).SetHeight(40));


                    document.Add(new iText.Layout.Element.Paragraph("Reporte valoracion de ofertas").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                    document.Add(new iText.Layout.Element.Paragraph(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(18));

                    float[] columnWidths = { 1, 5, 6, 5, 5, 5, 5, 5, 5, 5 };//{1,1,10,10,5,5,1,1,1,1,1,1};

                    iText.Layout.Element.Table tableRegistros = new iText.Layout.Element.Table(10).SetFontSize(12);
                    tableRegistros.SetWidthPercent(100);
                    tableRegistros.SetFixedLayout();

                    float fontCell = 11;
                    float fontCellData = 9;

                    Cell[] headerFooter = new Cell[] {
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Oferta").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Inicio").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Finalizacion").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Rubro").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Empresa").SetFontSize(fontCell),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Val. Negativas").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Val. Medias").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Val. Positivas").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Total").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER) };
                    //new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Productos").SetFontSize(fontCell),
                    //new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Imagenes").SetFontSize(fontCell)};


                    foreach (Cell hfCell in headerFooter)
                    {
                        tableRegistros.AddHeaderCell(hfCell);
                    }

                    for (int i = 0; i < listaRegistros.Count; i++)
                    {
                        ReporteValoracion reporte = listaRegistros[i];
                        Oferta oferta = reporte.Oferta;
                        Rubro rubro = reporte.Rubro;
                        Empresa empresa = reporte.Empresa;
                        tableRegistros.AddCell(oferta.IdOferta.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableRegistros.AddCell(oferta.TituloOferta).SetFontSize(fontCellData);
                        tableRegistros.AddCell(oferta.FechaInicio.ToShortDateString()).SetFontSize(fontCellData);
                        tableRegistros.AddCell(oferta.FechaFinalizacion.ToShortDateString()).SetFontSize(fontCellData);
                        tableRegistros.AddCell(rubro.DescripcionRubro).SetFontSize(fontCellData);
                        tableRegistros.AddCell(empresa.NombreEmpresa).SetFontSize(fontCellData);
                        tableRegistros.AddCell(reporte.CantValoracionNegativas.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableRegistros.AddCell(reporte.CantValoracionMedia.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableRegistros.AddCell(reporte.CantValoracionPositiva.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableRegistros.AddCell(reporte.CantValoracionTotal.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                    }

                    //tableRegistros.AddCell(reporte.CantProductos.ToString()).SetFontSize(fontCellData);
                    //tableRegistros.AddCell(reporte.CantImagenes.ToString()).SetFontSize(fontCellData);
                    document.Add(tableRegistros);
                    document.Close();

                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                    MessageBox.Show("Reporte generado correctamente \n en la ruta: " + rutaReporte, "Reporteria - Mis Ofertas");

                    //Uri test = new Uri(rutaReporte);
                    //WebBrowser.Navigate(rutaReporte);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Se ha presentado un inconveniente al generar el reporet\nIntente nuevamente", "Reporteria - Mis Ofertas");
                }
            }
        }
    }
}
