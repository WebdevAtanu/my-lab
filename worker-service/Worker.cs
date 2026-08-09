using WorkerService.Repository;

namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly StockExchangeRateRepository _repository;
    private readonly Random _random = new();

    public Worker(ILogger<Worker> logger, StockExchangeRateRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var symbols = new[] { "AAPL", "GOOGL", "MSFT", "AMZN", "TSLA" };
                
                foreach (var symbol in symbols)
                {
                    var currentRate = await _repository.GetRateBySymbolAsync(symbol);
                    decimal newRate;
                    
                    if (currentRate != null)
                    {
                        var randomChange = _random.Next(-100, 101) / 10000m; 
                        newRate = currentRate.Rate * (1m + randomChange);
                        await _repository.UpdateRateAsync(symbol, newRate);
                        _logger.LogInformation("Updated {Symbol} rate: {Rate:F2} at {time}", symbol, newRate, DateTimeOffset.Now);
                    }
                    else
                    {
                        newRate = 100m + _random.Next(50, 500);
                        await _repository.InsertRateAsync(new Models.StockExchangeRate
                        {
                            Symbol = symbol,
                            Rate = newRate,
                            LastUpdated = DateTime.UtcNow
                        });
                        _logger.LogInformation("Inserted {Symbol} rate: {Rate:F2} at {time}", symbol, newRate, DateTimeOffset.Now);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating stock exchange rates");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
