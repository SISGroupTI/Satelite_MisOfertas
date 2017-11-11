using EntityLibrary;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using NegLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace View
{
    /// <summary>
    /// Lógica de interacción para PrincipalPage.xaml
    /// </summary>
    public partial class PrincipalPage : Page, INotifyPropertyChanged
    {
        private double _lastLecture;
        private double _trend;
        private RegistrarProductoPage registrarProductoPage;
        private RegistrarOfertaPage registrarOfertaPage;
        private MenuTrabajdorPage menuTrabajdorPage;

        private OfertaNeg ofertaNeg;
        private ProductoNeg productoNeg;
        private TrabajadorNeg trabajadorNeg;
        private RubroNeg rubroNeg;
        private List<Oferta> listaOfertasMasVisitadas;

        public SeriesCollection LastHourSeries { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public PrincipalPage()
        {
            InitializeComponent();

            setSeriesCollection();

            dtFechaOfertaVisitada.SelectedDate = DateTime.Now;

            if (ofertaNeg == null)
                ofertaNeg = new OfertaNeg();
            if (rubroNeg == null)
                rubroNeg = new RubroNeg();
            if (listaOfertasMasVisitadas == null)
                listaOfertasMasVisitadas = new List<Oferta>();
            if (trabajadorNeg == null)
                trabajadorNeg = new TrabajadorNeg();
            if (productoNeg == null)
                productoNeg = new ProductoNeg();

            txtCantOfertas.Text = ofertaNeg.cantidadTotalOfertas().ToString();
            txtCantTrabajadores.Text = trabajadorNeg.cantidadTotalTrabajadores().ToString();
            txtCantProductos.Text = productoNeg.cantidadTotalProductos().ToString();

            listarOfertasMasVisitadas();
            listarRubrosMasVisitados();
            setCartesianChart();

        }
        private void setSeriesCollection()
        {
            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(5),
                        new ObservableValue(6),
                        new ObservableValue(7),
                        new ObservableValue(3),
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(5),
                        new ObservableValue(8),
                        new ObservableValue(3),
                        new ObservableValue(5),
                        new ObservableValue(6),
                        new ObservableValue(7),
                        new ObservableValue(3),
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(5),
                        new ObservableValue(8)
                    }
                }
            };
            _trend = 8;
            Task.Factory.StartNew(() =>
            {
                var r = new Random();

                Action action = delegate
                {
                    LastHourSeries[0].Values.Add(new ObservableValue(_trend));
                    LastHourSeries[0].Values.RemoveAt(0);
                    SetLecture();
                };

                while (true)
                {
                    Thread.Sleep(500);
                    _trend += (r.NextDouble() > 0.3 ? 1 : -1) * r.Next(0, 5);
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, action);
                }
            });
            DataContext = this;
        }
        private void SetLecture()
        {
            var target = ((ChartValues<ObservableValue>)LastHourSeries[0].Values).Last().Value;
            var step = (target - _lastLecture) / 4;
            Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < 4; i++)
                {
                    Thread.Sleep(100);
                    LastLecture += step;
                }
                LastLecture = target;
            });
        }
        public double LastLecture
        {
            get { return _lastLecture; }
            set
            {
                _lastLecture = value;
                OnPropertyChanged("LastLecture");
            }
        }


        //---------------------GRAFICO DE OFERTAS MAS VISITADAS---------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------


        private void setCartesianChart()
        {

            try
            {
                DateTime fechaPublicacion = dtFechaOfertaVisitada.SelectedDate.Value.Date;
                Oferta ofertaIn = new Oferta();
                ofertaIn.FechaInicio = fechaPublicacion;
                listaOfertasMasVisitadas = ofertaNeg.listarOfertasMasVisitadasMenuPrincipal(ofertaIn);



                if (listaOfertasMasVisitadas != null)
                {
                    SeriesCollection = new SeriesCollection {
                        new StackedColumnSeries
                        {
                            Values = new ChartValues<double> {},
                            StackMode = StackMode.Values, 
                            DataLabels = true
                        }
                    };
                    

                    string[] arrayTitulos = new string[5];
                    int aux = 0;
                    foreach (Oferta oferta in listaOfertasMasVisitadas)
                    {
                        arrayTitulos[aux] = "Cod: " + oferta.CodigoOferta.ToString();
                        SeriesCollection[0].Values.Add((double)oferta.Visitas);
                        aux += 1;
                    }

                    Labels = arrayTitulos;
                    Formatter = value => value + " Visitas";
                    DataContext = this;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el grafico,\nIntente nuevamente actualizando la fecha","Mis Ofertas");
            }
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (registrarProductoPage == null) { registrarProductoPage = new RegistrarProductoPage(); }
            NavigationService.Navigate(registrarProductoPage);
        }
        private void TextBlock_PreviewMouseDown_Trabajador(object sender, MouseButtonEventArgs e)
        {
            if (menuTrabajdorPage == null)
                menuTrabajdorPage = new MenuTrabajdorPage();
            NavigationService.Navigate(menuTrabajdorPage);
        }

        private void TextBlock_PreviewMouseDown_Ofertas(object sender, MouseButtonEventArgs e)
        {
            if (registrarOfertaPage == null)
                registrarOfertaPage = new RegistrarOfertaPage();
            NavigationService.Navigate(registrarOfertaPage);
        }


        //_--------------------------------------------------------------------------------

        public void listarOfertasMasVisitadas()
        {

            List<Oferta> listaOfertasMasVisitadas = ofertaNeg.listarOfertasMasVisitadas();
            listOfertas.ItemsSource = listaOfertasMasVisitadas;
            listOfertas.Items.Refresh();
        }

        public void listarRubrosMasVisitados()
        {
            List<Rubro> listaRubrosMasVisitados = rubroNeg.listarRubrosMasVisitados();
            listRubros.ItemsSource = listaRubrosMasVisitados;
            listRubros.Items.Refresh();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {

                DateTime fechaPublicacion = dtFechaOfertaVisitada.SelectedDate.Value.Date;
                Oferta ofertaIn = new Oferta();
                ofertaIn.FechaInicio = fechaPublicacion;
                listaOfertasMasVisitadas = ofertaNeg.listarOfertasMasVisitadasMenuPrincipal(ofertaIn);
                

                if (listaOfertasMasVisitadas != null)
                {
                    SeriesCollection = null;
                    chartOfertas.Series.Clear();
                    chartOfertas.AxisX.Clear();

                    SeriesCollection = new SeriesCollection {
                        new StackedColumnSeries
                        {
                            Values = new ChartValues<double> {},
                            StackMode = StackMode.Values,
                            DataLabels = true
                        }
                    };

                    string[] arrayTitulos = new string[5];
                    int aux = 0;
                    foreach (Oferta oferta in listaOfertasMasVisitadas)
                    {
                        arrayTitulos[aux] = "Cod: " + oferta.CodigoOferta.ToString();
                        SeriesCollection[0].Values.Add((double)oferta.Visitas);
                        aux += 1;
                    }

                    chartOfertas.Series = SeriesCollection;
                    chartOfertas.Update();
                    chartOfertas.UpdateLayout();
                }
                 

            }
        }
    }


}
