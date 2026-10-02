require("dotenv").config();

const express = require("express");
const client = require("./config/elasticsearch");
const productRoutes = require("./routes/productRoutes");

const app = express();

app.use(express.json());

app.get("/", (req, res) => {
  res.json({
    message: "Elasticsearch Node.js Product API",
    endpoints: {
      health: "GET /health",
      createProduct: "POST /products",
      searchProducts: "GET /products/search?q=iphone",
      getProduct: "GET /products/:id",
      deleteProduct: "DELETE /products/:id"
    }
  });
});

app.get("/health", async (req, res) => {
  try {
    await client.info();

    res.json({
      status: "connected",
      message: "Elasticsearch is reachable"
    });
  } catch (error) {
    res.status(500).json({
      status: "disconnected",
      error: error.message
    });
  }
});

app.use("/products", productRoutes);

const PORT = process.env.PORT || 5000;

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
