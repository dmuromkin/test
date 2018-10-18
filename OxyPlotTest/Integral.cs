using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlotTest
{
    class Integral
    {
        public static double Calculation()
        {
            double h = 0.01;
            int a = 1;
            int b = 10000;
            int N = (int)((b - a) / h);
           // double x = a + h;
            object monitor = new object();
            double integral = 0.0;/*
            for (int i = 0; i < N; i++)
            {
                integral += h * func(x - h / 2);
                x += h;
            }*/
            Parallel.For(0, N, () => 0.0, (i, state, local) =>
            {
                double x = a + (i+1)*h;
                local += h * func(x - h / 2);
                return local;

            }, local => { lock (monitor) integral += local; });
            
            return integral*h;
        }
        /*
          static public double Trapeze_parallel(double a, double b, double h)
        {
            double S;
            // calculate number of steps
            int N = (int)((b - a) / h);
            // object for lock mutex and synchronize threads
            object monitor = new object();
            S = (F11(a) + F11(b)) / 2;

            // Every thread have own local data, 
            // and thread calculate own part of integral
            // then it sum in main thread with S+= local
            Parallel.For(0, N, () => 0.0, (i, state, local) =>
            {
               
                local += F11(a + h*i);
                return local;
            }, local => { lock (monitor) S += local; });

            S *= h;
            return S;
        }
             */
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /*
        Parallel.For(0, N, () => 0.0, (i, state, local) =>
           {
               local += h * func(x - h / 2);
               x += h;
               return local;

           }, local => { lock (monitor) integral += local; });*/
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        static double func(double x)
        {
            return 7 * x - Math.Log(7 * x) + 8;
        }
    }
}
