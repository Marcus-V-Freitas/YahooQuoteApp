using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Data.Context
{
    public interface IDbContext : IDisposable
    {
        string ConnectionString { get; }
        public int? CommandTimeout { get; set; }
        Task<IEnumerable<T>> QueryProcedure<T>(string sql, object parameters = null);
        Task<IEnumerable<T>> Query<T>(string sql, object parameters = null);
        Task<int> ExecuteProcedure(string sql, object parameters = null);
        Task<int> Execute(string sql, object parameters = null);
        Task Commit();
        Task Rollback();
    }
}
