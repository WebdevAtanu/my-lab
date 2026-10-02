const client = require("../config/elasticsearch");

const INDEX = "products"; // Name of the Elasticsearch index to use for products 

// Create a new product 
exports.createProduct = async (req, res) => {
  try {
    const product = req.body;

    if (!product.name || !product.category || product.price === undefined) {
      return res.status(400).json({
        message: "name, category and price are required"
      });
    }

    const result = await client.index({
      index: INDEX,
      document: product,
      refresh: true
    });

    res.status(201).json({
      message: "Product created",
      id: result._id,
      product
    });
  } catch (error) {
    res.status(500).json({
      message: "Failed to create product",
      error: error.message
    });
  }
};

// Get a product by ID
exports.getProduct = async (req, res) => {
  try {
    const result = await client.get({
      index: INDEX,
      id: req.params.id
    });

    res.json({
      id: result._id,
      ...result._source
    });
  } catch (error) {
    if (error.meta?.statusCode === 404) {
      return res.status(404).json({ message: "Product not found" });
    }

    res.status(500).json({
      message: "Failed to get product",
      error: error.message
    });
  }
};

// Delete a product by ID
exports.deleteProduct = async (req, res) => {
  try {
    await client.delete({
      index: INDEX,
      id: req.params.id,
      refresh: true
    });

    res.json({
      message: "Product deleted"
    });
  } catch (error) {
    if (error.meta?.statusCode === 404) {
      return res.status(404).json({ message: "Product not found" });
    }

    res.status(500).json({
      message: "Failed to delete product",
      error: error.message
    });
  }
};

// Search for products with optional filters and sorting
exports.searchProducts = async (req, res) => {
  try {
    const {
      q = "",
      category,
      minPrice,
      maxPrice,
      sort = "relevance",
      page = 1,
      limit = 10
    } = req.query;

    const currentPage = Math.max(Number(page), 1);
    const size = Math.min(Math.max(Number(limit), 1), 100);
    const from = (currentPage - 1) * size;

    const must = [];
    const filter = [];

    if (q.trim()) {
      must.push({
        multi_match: {
          query: q,
          fields: [
            "name^3",
            "brand^2",
            "category",
            "description"
          ],
          fuzziness: "AUTO"
        }
      });
    } else {
      must.push({ match_all: {} });
    }

    if (category) {
      filter.push({
        term: {
          "category.keyword": category
        }
      });
    }

    if (minPrice !== undefined || maxPrice !== undefined) {
      const range = {};

      if (minPrice !== undefined) {
        range.gte = Number(minPrice);
      }

      if (maxPrice !== undefined) {
        range.lte = Number(maxPrice);
      }

      filter.push({
        range: {
          price: range
        }
      });
    }

    const body = {
      index: INDEX,
      from,
      size,
      query: {
        bool: {
          must,
          filter
        }
      }
    };

    if (sort === "price_asc") {
      body.sort = [{ price: "asc" }];
    }

    if (sort === "price_desc") {
      body.sort = [{ price: "desc" }];
    }

    const result = await client.search(body);

    const products = result.hits.hits.map((hit) => ({
      id: hit._id,
      score: hit._score,
      ...hit._source
    }));

    res.json({
      page: currentPage,
      limit: size,
      total: result.hits.total.value,
      products
    });
  } catch (error) {
    res.status(500).json({
      message: "Search failed",
      error: error.message
    });
  }
};
