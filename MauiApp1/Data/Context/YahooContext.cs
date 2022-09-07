using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Data.Context
{
    public sealed class YahooContext : IDbContext, IDisposable
    {
        private readonly string _connectionString;
        private readonly SQLiteConnection _connection;
        private readonly SQLiteTransaction _transaction;

        public string ConnectionString { get => _connectionString; }
        public int? CommandTimeout { get; set; }

        public YahooContext(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};";

            Setup(dbPath);

            _connection = new SQLiteConnection(_connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public async Task<IEnumerable<T>> QueryProcedure<T>(string sql, object parameters = null)
        {
            return await QueryBase<T>(sql, CommandType.StoredProcedure, parameters);
        }


        public async Task<IEnumerable<T>> Query<T>(string sql, object parameters = null)
        {
            return await QueryBase<T>(sql, CommandType.Text, parameters);

        }

        public async Task<int> ExecuteProcedure(string sql, object parameters = null)
        {
            return await ExecuteBase(sql, CommandType.StoredProcedure, parameters);
        }

        public async Task<int> Execute(string sql, object parameters = null)
        {
            return await ExecuteBase(sql, CommandType.Text, parameters);

        }

        private async Task<IEnumerable<T>> QueryBase<T>(string sql, CommandType commandType, object parameters = null)
        {
            return await _connection.QueryAsync<T>(sql, parameters, _transaction, CommandTimeout, commandType);
        }


        private async Task<int> ExecuteBase(string sql, CommandType commandType, object parameters)
        {
            return await _connection.ExecuteAsync(sql, parameters, _transaction, CommandTimeout, commandType);
        }

        public async Task Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction have already been already been commited or canceled. Check your transaction handling.");
            }
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction have already been already been commited or canceled. Check your transaction handling.");
            }

            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        private void Setup(string dbPath)
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                conn.Execute(@"CREATE TABLE IF NOT EXISTS [YahooQuote] (
                                      [id] INT,
                                      [fullExchangeName] VARCHAR,
                                      [symbol] VARCHAR,
                                      [regularMarketOpen] FLOAT,
                                      [regularMarketChangePercent] FLOAT,
                                      [regularMarketDayHigh] FLOAT,
                                      [tradeable] BOOL,
                                      [contractSymbol] BOOL,
                                      [currency] VARCHAR,
                                      [regularMarketPreviousClose] FLOAT,
                                      [regularMarketChange] FLOAT,
                                      [cryptoTradeable] BOOL,
                                      [regularMarketPrice] FLOAT,
                                      [market] VARCHAR,
                                      [regularMarketVolume] FLOAT,
                                      [regularMarketDayLow] FLOAT,
                                      [shortName] VARCHAR,
                                      [region] VARCHAR,
                                      [triggerable] BOOL,
                                      [captureDate] VARCHAR);");
            }
        }
    }
}
