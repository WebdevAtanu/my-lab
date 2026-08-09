using Microsoft.AspNetCore.Mvc;
using WorkerService.Models;
using WorkerService.Repository;

namespace WorkerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockExchangeRateController : ControllerBase
    {
        private readonly StockExchangeRateRepository _repository;
        private readonly ILogger<StockExchangeRateController> _logger;

        public StockExchangeRateController(StockExchangeRateRepository repository, ILogger<StockExchangeRateController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get all stock exchange rates
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockExchangeRate>>> GetAllRates()
        {
            try
            {
                var rates = await _repository.GetAllRatesAsync();
                return Ok(rates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all stock exchange rates");
                return StatusCode(500, "An error occurred while retrieving rates");
            }
        }

        /// <summary>
        /// Get stock exchange rate by symbol
        /// </summary>
        [HttpGet("{symbol}")]
        public async Task<ActionResult<StockExchangeRate>> GetRateBySymbol(string symbol)
        {
            try
            {
                var rate = await _repository.GetRateBySymbolAsync(symbol);
                if (rate == null)
                {
                    return NotFound($"Stock exchange rate for symbol '{symbol}' not found");
                }
                return Ok(rate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving stock exchange rate for symbol: {Symbol}", symbol);
                return StatusCode(500, "An error occurred while retrieving the rate");
            }
        }

        /// <summary>
        /// Update stock exchange rate for a specific symbol
        /// </summary>
        [HttpPut("{symbol}")]
        public async Task<IActionResult> UpdateRate(string symbol, [FromBody] decimal newRate)
        {
            try
            {
                var existingRate = await _repository.GetRateBySymbolAsync(symbol);
                if (existingRate == null)
                {
                    return NotFound($"Stock exchange rate for symbol '{symbol}' not found");
                }

                await _repository.UpdateRateAsync(symbol, newRate);
                _logger.LogInformation("Updated {Symbol} rate to {Rate:F2} via API", symbol, newRate);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating stock exchange rate for symbol: {Symbol}", symbol);
                return StatusCode(500, "An error occurred while updating the rate");
            }
        }

        /// <summary>
        /// Create a new stock exchange rate
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<StockExchangeRate>> CreateRate([FromBody] StockExchangeRate rate)
        {
            try
            {
                var existingRate = await _repository.GetRateBySymbolAsync(rate.Symbol);
                if (existingRate != null)
                {
                    return Conflict($"Stock exchange rate for symbol '{rate.Symbol}' already exists");
                }

                rate.LastUpdated = DateTime.UtcNow;
                await _repository.InsertRateAsync(rate);
                _logger.LogInformation("Created new rate for {Symbol} with value {Rate:F2} via API", rate.Symbol, rate.Rate);
                return CreatedAtAction(nameof(GetRateBySymbol), new { symbol = rate.Symbol }, rate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating stock exchange rate for symbol: {Symbol}", rate.Symbol);
                return StatusCode(500, "An error occurred while creating the rate");
            }
        }

        /// <summary>
        /// Delete stock exchange rate by symbol
        /// </summary>
        [HttpDelete("{symbol}")]
        public async Task<IActionResult> DeleteRate(string symbol)
        {
            try
            {
                var existingRate = await _repository.GetRateBySymbolAsync(symbol);
                if (existingRate == null)
                {
                    return NotFound($"Stock exchange rate for symbol '{symbol}' not found");
                }

                await _repository.DeleteRateAsync(symbol);
                _logger.LogInformation("Deleted rate for {Symbol} via API", symbol);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting stock exchange rate for symbol: {Symbol}", symbol);
                return StatusCode(500, "An error occurred while deleting the rate");
            }
        }
    }
}