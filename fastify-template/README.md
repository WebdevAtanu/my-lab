# Fastify CRUD API

A modular CRUD API built with Fastify and Mongoose, demonstrating best practices for API development.

## Project Structure

```
fastify-crud-api/
├── src/
│   ├── config/
│   │   └── database.js          # Database connection setup
│   ├── controllers/
│   │   └── userController.js    # Request handlers and business logic
│   ├── models/
│   │   └── User.js              # Mongoose schema and model
│   ├── routes/
│   │   └── userRoutes.js        # Route definitions
│   ├── services/
│   │   └── userService.js       # Service layer (database operations)
│   └── server.js                # Main server file
├── .env.example                 # Environment variables example
├── package.json
└── README.md
```

## Modular Pattern Explanation

### Models (`models/`)
Define Mongoose schemas and models for your database collections.

### Services (`services/`)
Contain business logic and database operations. These are reusable functions that interact with the database.

### Controllers (`controllers/`)
Handle HTTP requests and responses. They use services to perform operations.

### Routes (`routes/`)
Define API endpoints and map them to controller functions.

### Config (`config/`)
Store configuration files like database connection setup.

## Installation

1. Clone the repository
2. Install dependencies:
   ```bash
   npm install
   ```

3. Create a `.env` file from `.env.example`:
   ```bash
   cp .env.example .env
   ```

4. Update `.env` with your MongoDB URI:
   ```
   MONGODB_URI=mongodb://localhost:27017/fastify-crud-api
   PORT=3000
   ```

## Running the Server

**Development mode** (with auto-reload):
```bash
npm run dev
```

**Production mode**:
```bash
npm start
```

The server will start on `http://localhost:3000`

## API Endpoints

### Users CRUD Operations

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/users` | Create a new user |
| GET | `/api/users` | Get all users |
| GET | `/api/users/:id` | Get user by ID |
| PUT | `/api/users/:id` | Update user by ID |
| DELETE | `/api/users/:id` | Delete user by ID |

### Health Check

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/health` | Check server health |

## Example Usage

### Create a User
```bash
curl -X POST http://localhost:3000/api/users \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Doe",
    "email": "john@example.com",
    "age": 30,
    "address": "123 Main St",
    "phone": "555-1234"
  }'
```

### Get All Users
```bash
curl http://localhost:3000/api/users
```

### Get User by ID
```bash
curl http://localhost:3000/api/users/{id}
```

### Update User
```bash
curl -X PUT http://localhost:3000/api/users/{id} \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Jane Doe",
    "age": 31
  }'
```

### Delete User
```bash
curl -X DELETE http://localhost:3000/api/users/{id}
```

## Key Features

- **Modular Architecture**: Clear separation of concerns
- **Mongoose Integration**: Schema validation and data modeling
- **Error Handling**: Comprehensive error handling with meaningful messages
- **Environment Configuration**: Using `.env` for configuration
- **Graceful Shutdown**: Proper cleanup on process termination
- **Logging**: Built-in Fastify logging
- **Validation**: Mongoose schema validation

## Prerequisites

- Node.js 18+
- MongoDB (local or cloud instance)

## Dependencies

- **fastify**: Fast and low overhead web framework
- **mongoose**: MongoDB object modeling
- **dotenv**: Environment variables management

## Development Dependencies

- **nodemon**: Auto-restart server on file changes

## Notes

- Make sure MongoDB is running before starting the server
- Email validation is enforced in the User model
- Invalid IDs will return a 400 error
- Duplicate emails will return a 400 error

## License

ISC
