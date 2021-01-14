using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Practice1;

namespace Practice1NUnit
{
    [TestFixture]
    public class MyFormulaTests
    {
    private MyFormula _myFormula;

    private static IEnumerable<double[]> GetTestData()
    {
        using (var csv = new CsvReader(new StreamReader("test-data.csv"), true))
        {
            while (csv.ReadNextRecord())
            {
                double x = double.Parse(csv[0]);
                double expectedResult = double.Parse(csv[1]);
                yield return new[] {x, expectedResult};
            }
        }
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("Hello World");
        Console.WriteLine(DateTime.Now);

    }

    [OneTimeTearDown]
    public void OneTimeCleanup()
    {
        Console.WriteLine("Test Started");

    }

    [SetUp]
    public void Setup()
    {
        
        _myFormula = new MyFormula();
    }
    [TearDown]
    public void Cleanup()
    {
        Console.WriteLine("Test Ended");
       
    }

    [Test]
    [TestCase(-4)]
    public void MyFormulaFunction_WhenArgumentIsMinus4_ThrowsDivideByZeroException(double x)
    {
        Assert.That(() => _myFormula.MyFormulaFunction(x), Throws.Exception.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void MyFormulaFunction_WhenArgumentIsRandom_ReturnValue([Random(double.MinValue, Double.MaxValue, 5)]
        double x)
    {
        var result = _myFormula.MyFormulaFunction(x);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Not.NaN);

    }

    [Test]
    [TestCase(5, 1)]
    public void MyFormulaFunction_WhenArgumentIsNotMinus4_ReturnExpectedValue(double x, double expectedResult)
    {
        var result = _myFormula.MyFormulaFunction(x);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCaseSource("GetTestData")]
    public void MyFormulaFunction_WhenArgumentIsFromCsv_ReturnExpectedValue(double x, double expectedResult)
    {
        var result = _myFormula.MyFormulaFunction(x);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase(5, 1)]
    [Timeout(1000),Retry(10)]
    public void MyFormulaFunction_WhenExecutionTimeIsLessThan1000_ReturnExpectedValue(double x, double expectedResult)
    {
        var result = _myFormula.MyFormulaFunction(x);

        Thread.Sleep(1001);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    }
}