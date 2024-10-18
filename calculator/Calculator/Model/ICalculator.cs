using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorPkg
{
    public interface ICalculator
    {
        int Add(int param1, int param2);
        int Subtract(int param1, int param2);
        int Multiply(int param1, int param2);
        int Divide(int param1, int param2);
        int ConvertUSDtoCLP(int unit);        
    }
}