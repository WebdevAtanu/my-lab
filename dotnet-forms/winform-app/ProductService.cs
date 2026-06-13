using System;
using System.Collections.Generic;
using System.Data;

namespace winform_app
{
    public class ProductService
    {
        // Create
        public static bool AddProduct(Product product)
        {
            try
            {
                string query = $"INSERT INTO Products (ProductName, Description, Price, Quantity) " +
                              $"VALUES ('{EscapeString(product.ProductName)}', '{EscapeString(product.Description)}', " +
                              $"{product.Price}, {product.Quantity})";
                DatabaseHelper.ExecuteNonQuery(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Read All
        public static DataTable GetAllProducts()
        {
            try
            {
                string query = "SELECT * FROM Products ORDER BY ProductID DESC";
                return DatabaseHelper.ExecuteQuery(query);
            }
            catch
            {
                return null;
            }
        }

        // Read by ID
        public static Product GetProductById(int productId)
        {
            try
            {
                string query = $"SELECT * FROM Products WHERE ProductID = {productId}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new Product
                    {
                        ProductID = (int)row["ProductID"],
                        ProductName = row["ProductName"].ToString(),
                        Description = row["Description"].ToString(),
                        Price = (decimal)row["Price"],
                        Quantity = (int)row["Quantity"]
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        // Update
        public static bool UpdateProduct(Product product)
        {
            try
            {
                string query = $"UPDATE Products SET ProductName = '{EscapeString(product.ProductName)}', " +
                              $"Description = '{EscapeString(product.Description)}', " +
                              $"Price = {product.Price}, Quantity = {product.Quantity} " +
                              $"WHERE ProductID = {product.ProductID}";
                DatabaseHelper.ExecuteNonQuery(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete
        public static bool DeleteProduct(int productId)
        {
            try
            {
                string query = $"DELETE FROM Products WHERE ProductID = {productId}";
                DatabaseHelper.ExecuteNonQuery(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Helper method to prevent SQL injection
        private static string EscapeString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            return input.Replace("'", "''");
        }
    }
}