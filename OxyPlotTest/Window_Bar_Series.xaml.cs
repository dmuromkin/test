using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OxyPlotTest
{
    /// <summary>
    /// Логика взаимодействия для Window_Bar_Series.xaml
    /// </summary>
    public partial class Window_Bar_Series : Window
    {
        public Window_Bar_Series()
        {
            InitializeComponent();
        }
        static double func(double x)
        {
            return 7 * x - Math.Log(7 * x) + 8;
        }
        public void draw()
        {
            var model = new PlotModel { Title = "Cake Type Popularity" };

            //generate a random percentage distribution between the 5
            //cake-types (see axis below)
            var rand = new Random();
            double[] cakePopularity = new double[5];
            for (int i = 0; i < 5; ++i)
            {
                cakePopularity[i] = rand.NextDouble();
            }
            var sum = cakePopularity.Sum();

            var barSeries = new BarSeries
            {
                ItemsSource = new List<BarItem>(new[]
                    {
                new BarItem{ Value = (cakePopularity[0] / sum * 100) },
                new BarItem{ Value = (cakePopularity[1] / sum * 100) },
                new BarItem{ Value = (cakePopularity[2] / sum * 100) },
                new BarItem{ Value = (cakePopularity[3] / sum * 100) },
                new BarItem{ Value = (cakePopularity[4] / sum * 100) }
        }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.00}%"
            };
            model.Series.Add(barSeries);
            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "CakeAxis",
                ItemsSource = new[]
                    {
                "Apple cake",
                "Baumkuchen",
                "Bundt Cake",
                "Chocolate cake",
                "Carrot cake"
        }
            });
            graph1.InvalidatePlot();
            /* Stopwatch sw = new Stopwatch();
             (graph1.Model.Series[0] as FunctionSeries).Points.Clear();
             //(graph1.Model.Series[0] as FunctionSeries).Points.Add(new DataPoint(10, 0));
             bool mode = true;
             int k = 1;
             double h = 1.0;
             int a = 1;
             int b = 10000;
             for (int i = 0; i < 5; i++)
             {
                 sw.Start();
                 result.Text = Integral.Calculation(mode, a, b, h, func).ToString();
                 sw.Stop();
                 double time = sw.Elapsed.Milliseconds;
                 (graph1.Model.Series[0] as FunctionSeries).Points.Add(new DataPoint(1 * k, time));
                 k++;
                 h /= 5;

             }


             //(graph1.Model.Series[0] as FunctionSeries).Points.Add(new DataPoint(20, 20));
             graph1.InvalidatePlot();*/
        }
    }
}
