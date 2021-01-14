using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice1;
using System;

using System.Threading;

namespace Practice1MSTests
{
    [TestClass]
    public class MyFormulaTests
    {
        
        private MyFormula _myFormula;



        [ClassInitialize]
        public static void OneTimeSetup(TestContext t)
        {
            Console.WriteLine("Hello World");
            Console.WriteLine(DateTime.Now);

        }

        [ClassCleanup]
        public static void OneTimeCleanup()
        {
            Console.WriteLine("Test Started");
            Console.WriteLine(DateTime.Now);

        }

        [TestInitialize]
        public void Setup()
        {
            _myFormula = new MyFormula();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.WriteLine("Test Ended");

        }


        [TestMethod]
        [DataRow(-4)]
        [DataTestMethod]
        public void MyFormulaFunction_WhenArgumentIsMinus4_ThrowsDivideByZeroException(double x)
        {
            Assert.ThrowsException<DivideByZeroException>(() => _myFormula.MyFormulaFunction(x));
        }


        [TestMethod]
        [DataRow(5, 1)]
        [DataTestMethod]
        public void MyFormulaFunction_WhenArgumentIsNotMinus4_ReturnExpectedValue(double x, double expectedResult)
        {
            var result = _myFormula.MyFormulaFunction(x);

               Assert.AreEqual(result, expectedResult);
        }

        

        [TestMethod]
        [DataRow(5, 1)]
        [Timeout(1000)]
        public void MyFormulaFunction_WhenExecutionTimeIsLessThan1000_ReturnExpectedValue(double x, double expectedResult)
        {
            var result = _myFormula.MyFormulaFunction(x);

            Thread.Sleep(1001);

               Assert.AreEqual(result, expectedResult);
        }
    }
}