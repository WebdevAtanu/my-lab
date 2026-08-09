using Dapper;
using MySqlConnector;
using WorkerService.Models;

namespace WorkerService.Repository
{
    public class StockExchangeRateRepository
    {
        private readonly string _connectionString;

        public StockExchangeRateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<StockExchangeRate>> GetAllRatesAsync()
        {
            using var connection = new MySqlConnection(_connectionString);
            const string sql = "SELECT Id, Symbol, Rate, LastUpdated FROM StockExchangeRates";
            return await connection.QueryAsync<StockExchangeRate>(sql);
        }

        public async Task<StockExchangeRate?> GetRateBySymbolAsync(string symbol)
        {
            using var connection = new MySqlConnection(_connectionString);
            const string sql = "SELECT Id, Symbol, Rate, LastUpdated FROM StockExchangeRates WHERE Symbol = @Symbol";
            return await connection.QueryFirstOrDefaultAsync<StockExchangeRate>(sql, new { Symbol = symbol });
        }

        public async Task UpdateRateAsync(string symbol, decimal newRate)
        {
            using var connection = new MySqlConnection(_connectionString);
            const string sql = "UPDATE StockExchangeRates SET Rate = @Rate, LastUpdated = @LastUpdated WHERE Symbol = @Symbol";
            await connection.ExecuteAsync(sql, new { Symbol = symbol, Rate = newRate, LastUpdated = DateTime.UtcNow });
        }

        public async Task InsertRateAsync(StockExchangeRate rate)
        {
            using var connection = new MySqlConnection(_connectionString);
            const string sql = "INSERT INTO StockExchangeRates (Symbol, Rate, LastUpdated) VALUES (@Symbol, @Rate, @LastUpdated)";
            await connection.ExecuteAsync(sql, new { rate.Symbol, rate.Rate, rate.LastUpdated });
        }

        public async Task DeleteRateAsync(string symbol)
        {
            using var connection = new MySqlConnection(_connectionString);
            const string sql = "DELETE FROM StockExchangeRates WHERE Symbol = @Symbol";
            await connection.ExecuteAsync(sql, new { Symbol = symbol });
        }
    }
}