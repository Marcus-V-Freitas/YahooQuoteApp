using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Models
{
    public class YahooQuote
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string fullExchangeName { get; set; }
        public string symbol { get; set; }
        public double regularMarketOpen { get; set; }
        public double regularMarketChangePercent { get; set; }
        public double regularMarketDayHigh { get; set; }
        public bool tradeable { get; set; }
        public bool contractSymbol { get; set; }
        public string currency { get; set; }
        public double regularMarketPreviousClose { get; set; }
        public double regularMarketChange { get; set; }
        public bool cryptoTradeable { get; set; }
        public double regularMarketPrice { get; set; }
        public string market { get; set; }
        public double regularMarketVolume { get; set; }
        public double regularMarketDayLow { get; set; }
        public string shortName { get; set; }
        public string region { get; set; }
        public bool triggerable { get; set; }
        public DateTime captureDate { get; set; } = DateTime.UtcNow;
    }
}
