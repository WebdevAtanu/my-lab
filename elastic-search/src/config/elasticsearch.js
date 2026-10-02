const { Client } = require("@elastic/elasticsearch"); //

// Create a new Elasticsearch client instance with the provided configuration
const client = new Client({
  node: process.env.ELASTICSEARCH_URL,
  auth: {
    apiKey: process.env.ELASTICSEARCH_API_KEY
  }
});

module.exports = client;
