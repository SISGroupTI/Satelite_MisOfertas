using EntityLibrary;
using iText.IO.Font;
using iText.IO.Image;
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
        HistorialCorreoNeg historialCorreoNeg;

        public MenuReporteTiendaPage()
        {
            if (reporteTiendasNeg == null)
                reporteTiendasNeg = new ReporteTiendasNeg();
            if (historialCorreoNeg == null)
                historialCorreoNeg = new HistorialCorreoNeg();
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


        private void btnReporteTienda_Click(object sender, RoutedEventArgs e)
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

                    //---------------------SETEO DE REGISTROS PARA LA GENERACION DE LOS REPORTES----------------------------
                    List<ReporteTiendas> listaConsumidoresRegistradosDia;
                    List<ReporteTiendas> listaConsumidoresRegistradosMes;
                    List<HistorialCorreo> listaCorreosEnviados;
                    List<ValoracionOferta> listaValoracionesPorEmpresa;
                    List<Rubro> listaCuponesGeneradosPorRubro;

                    if (dpFechaInicio.SelectedDate == null && dpFechaTermino.SelectedDate == null)
                    {
                        listaConsumidoresRegistradosDia = reporteTiendasNeg.listaConsumidoresRegistradosDia(null, null);
                        listaConsumidoresRegistradosMes = reporteTiendasNeg.listaConsumidoresRegistradosMes(null, null);
                        listaCorreosEnviados = historialCorreoNeg.listarCantCorreosEnviados(null, null);
                        listaValoracionesPorEmpresa = reporteTiendasNeg.listaValoracionesPorEmpresa();
                        listaCuponesGeneradosPorRubro = reporteTiendasNeg.listaCuponesGeneradosPorRubro();
                    }
                    else
                    {
                        listaConsumidoresRegistradosDia = reporteTiendasNeg.listaConsumidoresRegistradosDia(dpFechaInicio.SelectedDate, dpFechaTermino.SelectedDate);
                        listaConsumidoresRegistradosMes = reporteTiendasNeg.listaConsumidoresRegistradosMes(dpFechaInicio.SelectedDate, dpFechaTermino.SelectedDate);
                        listaCorreosEnviados = historialCorreoNeg.listarCantCorreosEnviados(dpFechaInicio.SelectedDate, dpFechaTermino.SelectedDate);
                        listaValoracionesPorEmpresa = reporteTiendasNeg.listaValoracionesPorEmpresa();
                        listaCuponesGeneradosPorRubro = reporteTiendasNeg.listaCuponesGeneradosPorRubro();
                    }
                    //--------------------------------------------------------------------------------------------------------


                    String rutaDirectorioOferta = "D:/MisOfertas/Reportes/";
                    List<ImagenOferta> listaImagenesOferta = new List<ImagenOferta>();
                    if (!Directory.Exists(rutaDirectorioOferta))
                        Directory.CreateDirectory(rutaDirectorioOferta);

                    DateTime fechaCreacionReporte = DateTime.Now;
                    String rutaReporte = rutaDirectorioOferta + "/ReporteTiendas" + fechaCreacionReporte.ToString("ddMMyyyyHHmm") + ".pdf";

                    PdfWriter writer = new PdfWriter(rutaReporte);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, PageSize.A4);
                    PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

                    string _filePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                    _filePath = Directory.GetParent(_filePath).FullName;
                    _filePath = Directory.GetParent(_filePath).FullName;
                    _filePath += @"\img\MisOfertas-Letras.png";
                    document.Add(new iText.Layout.Element.Image(ImageDataFactory.Create(_filePath)).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT).SetWidth(40).SetHeight(40));



                    document.Add(new iText.Layout.Element.Paragraph("Reporte resumenes por tiendas y empresas").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                    document.Add(new iText.Layout.Element.Paragraph(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(18));
                    float fontCell = 11;
                    float fontCellData = 9;

                    //----------------TABLA CONSUMIDORES REGISTRADOR POR DIA-------------------------------
                    document.Add(new iText.Layout.Element.Paragraph("Consumidores registrados por dia").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                    float[] columnWidthsDIa = { 20f, 60f, 120f, 30f, 30f };

                    iText.Layout.Element.Table tableConsumidoresDia = new iText.Layout.Element.Table(5).SetFontSize(12);
                    tableConsumidoresDia.SetWidthPercent(100);
                    tableConsumidoresDia.SetFixedLayout();


                    Cell[] headerFooter = new Cell[] {
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Año").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Mes").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Dia").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Consumidores").SetFontSize(fontCell)};

                    foreach (Cell hfCell in headerFooter)
                    {
                        tableConsumidoresDia.AddHeaderCell(hfCell);
                    }


                    for (int i = 0; i < listaConsumidoresRegistradosDia.Count; i++)
                    {
                        ReporteTiendas reporte = listaConsumidoresRegistradosDia[i];
                        tableConsumidoresDia.AddCell(i.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresDia.AddCell(reporte.AnioRegistro.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresDia.AddCell(reporte.MesRegistro.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresDia.AddCell(reporte.DiaRegistro.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresDia.AddCell(reporte.ConsumidoresRegistradosDia.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    }

                    document.Add(tableConsumidoresDia);


                    //----------------TABLA CONSUMIDORES REGISTRADOR POR MES-------------------------------           
                    document.Add(new iText.Layout.Element.Paragraph("Consumidores registrados por mes").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                    float[] columnWidthsMes = { 20f, 60f, 120f, 30f };

                    iText.Layout.Element.Table tableConsumidoresMes = new iText.Layout.Element.Table(4).SetFontSize(12);
                    tableConsumidoresMes.SetWidthPercent(100);
                    tableConsumidoresMes.SetFixedLayout();


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
                        tableConsumidoresMes.AddCell(i.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresMes.AddCell(reporte.AnioRegistro.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresMes.AddCell(reporte.MesRegistro.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableConsumidoresMes.AddCell(reporte.ConsumidoresRegistradosMes.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    }

                    document.Add(tableConsumidoresMes);

                    //----------------TABLA CANTIDAD CORREOS ENVIADOS POR TIENDA-EMPRESA -------------------------------           
                    document.Add(new iText.Layout.Element.Paragraph("Sumatoria de correos enviados").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));
                    float[] columnWidthsCorreo = { 20f, 60f, 120f, 30f, 20f, 30f, 30f };

                    iText.Layout.Element.Table tableCorreoEnviados = new iText.Layout.Element.Table(7).SetFontSize(12);
                    tableCorreoEnviados.SetWidthPercent(100);
                    tableCorreoEnviados.SetFixedLayout();


                    Cell[] cellCorreoEnviados = new Cell[] {
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Empresa").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Local").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Oferta").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Codigo").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Fecha de Envio").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Correos enviados").SetFontSize(fontCell)
                    };


                    foreach (Cell hfCell in cellCorreoEnviados)
                    {
                        tableCorreoEnviados.AddHeaderCell(hfCell);
                    }

                    for (int i = 0; i < listaCorreosEnviados.Count; i++)
                    {
                        HistorialCorreo historialCorreo = listaCorreosEnviados[i];
                        Oferta oferta = historialCorreo.Oferta;
                        Local local = oferta.Local;
                        Empresa empresa = local.Empresa;

                        tableCorreoEnviados.AddCell(i.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCorreoEnviados.AddCell(empresa.NombreEmpresa).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCorreoEnviados.AddCell(local.NumeroLocal.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCorreoEnviados.AddCell(oferta.TituloOferta).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCorreoEnviados.AddCell(oferta.CodigoOferta.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCorreoEnviados.AddCell(historialCorreo.FechaEnvio.ToShortDateString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCorreoEnviados.AddCell(historialCorreo.CantCorreosEnviados.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    }

                    document.Add(tableCorreoEnviados);

                    //----------------TABLA VALORACIONES POR EMPRESA Y LOCAL-------------------------------
                    document.Add(new iText.Layout.Element.Paragraph("Cantidad de Valoraciones por Empresas").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));


                    iText.Layout.Element.Table tableValoracionEmpresa = new iText.Layout.Element.Table(8).SetFontSize(12);
                    tableValoracionEmpresa.SetWidthPercent(100);
                    tableValoracionEmpresa.SetFixedLayout();


                    Cell[] cellEmpresa = new Cell[] {
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Rut").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Empresa").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Numero de Local").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Valoraciones Negativas").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Valoraciones Medias").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Valoraciones Positivas").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Valoraciones Totales").SetFontSize(fontCell)
                    };

                    foreach (Cell hfCell in cellEmpresa)
                    {
                        tableValoracionEmpresa.AddHeaderCell(hfCell);
                    }


                    for (int i = 0; i < listaValoracionesPorEmpresa.Count; i++)
                    {
                        ValoracionOferta valoracionOferta = listaValoracionesPorEmpresa[i];
                        Empresa empresa = valoracionOferta.Empresa;
                        Local local = valoracionOferta.Local;

                        tableValoracionEmpresa.AddCell(i.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(empresa.RutEmpresa.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(empresa.NombreEmpresa).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(local.NumeroLocal.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(valoracionOferta.CantValoracionesNegativas.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(valoracionOferta.CantValoracionMedias.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(valoracionOferta.CantValoracionesPositivas.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableValoracionEmpresa.AddCell(valoracionOferta.CantTotalValoraciones.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    }

                    document.Add(tableValoracionEmpresa);


                    //----------------TABLA CUPONES GENERADOS POR RUBRO-------------------------------           
                    document.Add(new iText.Layout.Element.Paragraph("Cupones generados por Rubro").SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20));


                    iText.Layout.Element.Table tableCupones = new iText.Layout.Element.Table(3).SetFontSize(12);
                    tableCupones.SetWidthPercent(100);
                    tableCupones.SetFixedLayout();


                    Cell[] cellsCupones = new Cell[] {
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("#").SetFontSize(fontCell).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Rubro").SetFontSize(fontCell),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add("Cupones Generados").SetFontSize(fontCell)};

                    foreach (Cell hfCell in cellsCupones)
                    {
                        tableCupones.AddHeaderCell(hfCell);
                    }

                    for (int i = 0; i < listaCuponesGeneradosPorRubro.Count; i++)
                    {
                        Rubro rubro = listaCuponesGeneradosPorRubro[i];
                        tableCupones.AddCell(i.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCupones.AddCell(rubro.DescripcionRubro).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        tableCupones.AddCell(rubro.CantidadCuponesGenerados.ToString()).SetFontSize(fontCellData).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    }

                    document.Add(tableCupones);
                    document.Close();
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                    MessageBox.Show("Reporte generado correctamente \n en la ruta: " + rutaReporte, "Reporteria - Mis Ofertas");

                }
                catch (Exception err)
                {
                    MessageBox.Show("Se ha presentado un inconveniente al generar el reporet\nIntente nuevamente", "Reporteria - Mis Ofertas");
                }
            }
        }
    }
}
