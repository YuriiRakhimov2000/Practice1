using System;
using Xunit;
using Practice1;

using System.Threading.Tasks;

namespace Practice1xUnit
{
    
    public class MyFormulaTests:IDisposable
    {
        private MyFormula _myFormula;

        
       

            
        public  MyFormulaTests()
        {
            _myFormula = new MyFormula();
            Console.WriteLine("Test Started");
        }
       
          public void Dispose()
        {
            Console.WriteLine("Test Ended");
        }


        [Theory]
        [InlineData(-4)]
        public void MyFormulaFunction_WhenArgumentIsMinus4_ThrowsDivideByZeroException(double x)
        {
            Assert.Throws<DivideByZeroException>(() => _myFormula.MyFormulaFunction(x));
        }

     
        [Theory]
        [InlineData(5, 1)]
        public void MyFormulaFunction_WhenArgumentIsNotMinus4_ReturnExpectedValue(double x, double expectedResult)
        {
            var result = _myFormula.MyFormulaFunction(x);

            Assert.Equal(expectedResult,result);
        }

        

        [Fact(Timeout = 50)]
        public async void MyFormulaFunction_WhenTimeExceeds_TestFails() => await Task.Delay(500);
        

    }
}
