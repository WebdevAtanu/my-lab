# Elasticsearch Node.js Product Search API

A Node.js + Express + Elasticsearch project.


## Setup

1. Create an Elasticsearch deployment.
2. Add `.env`.
3. Add your Elasticsearch URL and API key.
4. Install dependencies:

```bash
npm install
```

6. Start the server:

```bash
npm run dev
```

Server:

```text
http://localhost:5000
```

## Endpoints

### Health

```http
GET /health
```

### Create product

```http
POST /products
Content-Type: application/json
```

Example:

```json
{
  "name": "iPhone 16",
  "category": "Mobile",
  "brand": "Apple",
  "price": 79999,
  "description": "Apple smartphone with a powerful processor"
}
```

### Get product

```http
GET /products/:id
```

### Delete product

```http
DELETE /products/:id
```

### Search

```http
GET /products/search?q=iphone
```

Optional filters:

```text
?q=phone&category=Mobile&minPrice=10000&maxPrice=100000&sort=price_asc&page=1&limit=10
```

## Example search

```http
GET /products/search?q=iphon
```

The fuzzy search can find `iPhone`.

## Project structure

```text
src/
├── config/
│   └── elasticsearch.js
├── controllers/
│   └── productController.js
├── routes/
│   └── productRoutes.js
└── server.js
```
