using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Models.YahooRequestsModels
{
    public sealed class Quote
    {
        public string fullExchangeName { get; set; }
        public string symbol { get; set; }
        public NumericData regularMarketOpen { get; set; }
        public NumericData regularMarketChangePercent { get; set; }
        public NumericData regularMarketDayHigh { get; set; }
        public bool tradeable { get; set; }
        public bool contractSymbol { get; set; }
        public string currency { get; set; }
        public NumericData regularMarketPreviousClose { get; set; }
        public NumericData regularMarketChange { get; set; }
        public bool cryptoTradeable { get; set; }
        public NumericData regularMarketPrice { get; set; }
        public string market { get; set; }
        public NumericData regularMarketVolume { get; set; }
        public NumericData regularMarketDayLow { get; set; }
        public string shortName { get; set; }
        public string region { get; set; }
        public bool triggerable { get; set; }
    }
}
