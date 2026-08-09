namespace WorkerService.Models
{
    public class StockExchangeRate
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}