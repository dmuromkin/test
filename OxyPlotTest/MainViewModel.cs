using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlotTest
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.MyModel = new PlotModel { Title = "Example 1" };
            FunctionSeries ser = new FunctionSeries();
            BarSeries bar = new BarSeries();
            this.MyModel.Series.Add(ser);
            this.MyModel.Series.Add(bar);
            

        }

        public PlotModel MyModel { get; private set; }
    }
}
