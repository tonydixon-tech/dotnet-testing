using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyExchangeRatePkg;

namespace CalculatorPkg
{
    public class Calculator : ICalculator
    {
        private IUSD_CLP_ExchangeRateFeed _feed;
        public Calculator(IUSD_CLP_ExchangeRateFeed feed)
        {
            this._feed = feed;
        }
        #region ICalculator Members
        public int Add(int param1, int param2)
        {
            return param1 + param2;
        }
        public int Subtract(int param1, int param2)
        {
            return param1 - param2;
        }
        public int Multiply(int param1, int param2)
        {
            return param1 * param2;
        }
        public int Divide(int param1, int param2)
        {
            return param1 / param2;
        }
        public int ConvertUSDtoCLP(int unit)
        {
            return unit * this._feed.getActualUSDValue();
        }
        #endregion
    }
}