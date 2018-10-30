using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace OxyPlotTest
{
   public class Integral
    {
        public static double Calculation(bool parallel,int a,int b, double h, Func<double,double> func)
        {
            if (a > b)
                throw new ArgumentException("a>b");
           // double h = 0.01;
           // int a = 1;
            //int b = 10000;
            int N = (int)((b - a) / h);
            double integral = 0.0;
            
            switch (parallel)
            {
                case false:
                    {
                        double x = a + h;
                        for (int i = 0; i < N; i++)
                        {
                            integral += h * func(x - h / 2);
                            x += h;
                        }
                    }
                    break;
                case true:
                    {
                        object monitor = new object();
                        Parallel.For(0, N, () => 0.0, (i, state, local) =>
                        {
                            double x = a + (i + 1) * h;
                            local += h * func(x - h / 2);
                            return local;

                        }, local => { lock (monitor) integral += local; });
                        
                    }
                    break;
            }
            return integral;
        }
             
    }
}
