-- Create database
CREATE DATABASE IF NOT EXISTS stock_exchange;

USE stock_exchange;

-- Create table for stock exchange rates
CREATE TABLE IF NOT EXISTS StockExchangeRates (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Symbol VARCHAR(10) NOT NULL UNIQUE,
    Rate DECIMAL(18, 4) NOT NULL,
    LastUpdated DATETIME NOT NULL,
    INDEX idx_symbol (Symbol)
);

-- Insert initial data (optional)
INSERT INTO StockExchangeRates (Symbol, Rate, LastUpdated) VALUES
('AAPL', 150.25, NOW()),
('GOOGL', 2800.50, NOW()),
('MSFT', 300.75, NOW()),
('AMZN', 3400.00, NOW()),
('TSLA', 750.25, NOW())
ON DUPLICATE KEY UPDATE Rate=VALUES(Rate), LastUpdated=VALUES(LastUpdated);