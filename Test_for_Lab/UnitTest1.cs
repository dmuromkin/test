using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OxyPlotTest;
namespace Test_for_Lab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double right_result=349978426.945418;
            double h = 0.01;
            int a = 1;
            int b = 10000;
            double now = Integral.Calculation(false,a, b, h, x=> 7 * x - Math.Log(7 * x) + 8);
            Assert.AreEqual(right_result, now,0.1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            double right_result = 349978426.945418;
            double h = 0.01;
            int a = 1;
            int b = 10000;
            double now = Integral.Calculation(true, a, b, h, x => 7 * x - Math.Log(7 * x) + 8);
            Assert.AreEqual(right_result, now, 0.1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3()
        {
            
            double h = 0.01;
            int a = 1;
            int b = 10000;
            double now = Integral.Calculation(true, b, a, h, x => 7 * x - Math.Log(7 * x) + 8);
            Assert.Fail();
        }
        [TestMethod]
        public void TestMethod4()
        {
            double right_result = 349978426.900983;
            double h = 1.0;
            int a = 1;
            int b = 10000;
            double now = Integral.Calculation(true, a, b, h, x => 7 * x - Math.Log(7 * x) + 8);
            Assert.AreNotEqual(right_result - 1, now);
        }

    }
}
