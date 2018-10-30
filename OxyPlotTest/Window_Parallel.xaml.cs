using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using OxyPlot.Series;
using OxyPlot;

namespace OxyPlotTest
{
    /// <summary>
    /// Логика взаимодействия для Window_Parallel.xaml
    /// </summary>
    public partial class Window_Parallel : Window
    {
        public Window_Parallel()
        {
            InitializeComponent();
        }
        static double func(double x)
        {
            return 7 * x - Math.Log(7 * x) + 8;
        }
        public void draw()
        {
            Stopwatch sw = new Stopwatch();
            (graph1.Model.Series[0] as FunctionSeries).Points.Clear();
            //(graph1.Model.Series[0] as FunctionSeries).Points.Add(new DataPoint(10, 0));
            bool mode = true;
            int k = 1;
            double h = 1.0;
            int a = 1;
            int b = 10000;
            for (int i = 0; i< 5; i++)
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
        graph1.InvalidatePlot();
            }
    }
}
