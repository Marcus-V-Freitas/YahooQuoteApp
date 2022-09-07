using YahooQuoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Services
{
    public interface IYahooService
    {
        Task SaveYahooQuoteAsync(YahooQuote quote);

        Task<IEnumerable<YahooQuote>> GetAllQuotesByName(string quoteName);
    }
}
