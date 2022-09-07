using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Models.YahooRequestsModels
{
    public sealed class QuotesSummary
    {
        public List<Quote> result { get; set; }
    }
}
