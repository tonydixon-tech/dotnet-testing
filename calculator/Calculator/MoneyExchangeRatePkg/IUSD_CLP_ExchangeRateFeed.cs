using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeRatePkg
{
    public interface IUSD_CLP_ExchangeRateFeed
    {
        int getActualUSDValue();
    }
}