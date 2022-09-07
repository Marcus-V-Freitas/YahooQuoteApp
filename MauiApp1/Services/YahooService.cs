using YahooQuoteApp.Data.Context;
using YahooQuoteApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Services
{
    public class YahooService : IYahooService
    {
        private readonly IDbContext _dbContext;

        public YahooService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveYahooQuoteAsync(YahooQuote quote)
        {
            await _dbContext.Execute(@"INSERT INTO YahooQuote (id, fullExchangeName, symbol, regularMarketOpen, regularMarketChangePercent, regularMarketDayHigh, tradeable, contractSymbol, currency,
                                                              regularMarketPreviousClose, regularMarketChange, cryptoTradeable, regularMarketPrice, market, regularMarketVolume, regularMarketDayLow,
                                                              shortName, region, triggerable, captureDate) VALUES
                                                             (@id, @fullExchangeName, @symbol, @regularMarketOpen, @regularMarketChangePercent, @regularMarketDayHigh, @tradeable, @contractSymbol, @currency,
                                                              @regularMarketPreviousClose, @regularMarketChange, @cryptoTradeable, @regularMarketPrice, @market, @regularMarketVolume, @regularMarketDayLow,
                                                              @shortName, @region, @triggerable, @captureDate)", quote);
            await _dbContext.Commit();
        }

        public async Task<IEnumerable<YahooQuote>> GetAllQuotesByName(string quoteName)
        {
            return await _dbContext.Query<YahooQuote>("SELECT * FROM YahooQuote WHERE shortName = @shortName", quoteName);
        }

    }
}
