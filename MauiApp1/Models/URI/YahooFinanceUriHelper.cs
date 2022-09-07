using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Models.URI
{
    public sealed class YahooFinanceUriHelper : UriHelper
    {
        public YahooFinanceUriHelper(string company, string url = "https://query1.finance.yahoo.com/v7/finance/quote") : base(url)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "formatted", "true"                   },
                { "crumb",     "LTiO2XiFD3t"            },
                { "lang",      "pt-BR"                  },
                { "region",    "BR"                     },
                { "symbols",   company                  },
                { "fields",    "messageBoardId%2ClongName%2CshortName%2CmarketCap%2CunderlyingSymbol%2CunderlyingExchangeSymbol%2CheadSymbolAsString%2CregularMarketPrice%2CregularMarketChange%2CregularMarketChangePercent%2CregularMarketVolume%2Cuuid%2CregularMarketOpen%2CfiftyTwoWeekLow%2CfiftyTwoWeekHigh%2CtoCurrency%2CfromCurrency%2CtoExchange%2CfromExchanges" },
                { "corsDomain", "br.financas.yahoo.com" }
            };

            AddQueryString(parameters);
        }
    }
}
