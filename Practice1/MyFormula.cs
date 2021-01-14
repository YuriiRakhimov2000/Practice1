using System;
using System.Collections.Generic;
using System.Text;

namespace Practice1
{
    public class MyFormula
    {
    

        //Formula No 9 - f(x) = 9/(x+4) 
        public double MyFormulaFunction(double x)
        {
            if (x == -4)
                throw new DivideByZeroException();
            
            return (9 / (x+4));
        }

    }
}
