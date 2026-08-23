# User Authentication System

A complete user authentication system built with Node.js, TypeScript, Express, and JWT (JSON Web Tokens).

## Features

- **User Registration**: Secure user registration with password hashing
- **User Login**: Authentication with JWT token generation
- **Token Validation**: JWT middleware for protected routes
- **Input Validation**: Request validation using express-validator
- **TypeScript**: Full TypeScript support with type safety
- **Security**: Bcrypt password hashing, JWT authentication
- **CORS**: Cross-origin resource sharing enabled
- **Error Handling**: Comprehensive error handling middleware

## Tech Stack

- **Runtime**: Node.js
- **Language**: TypeScript
- **Framework**: Express.js
- **Authentication**: JWT (JSON Web Tokens)
- **Password Hashing**: bcryptjs
- **Validation**: express-validator
- **Security**: CORS enabled

## Project Structure

```
auth/
├── src/
│   ├── config/
│   │   └── index.ts              # Configuration management
│   ├── controllers/
│   │   └── authController.ts     # Authentication logic
│   ├── middleware/
│   │   ├── authMiddleware.ts     # JWT authentication middleware
│   │   └── validationMiddleware.ts # Request validation
│   ├── models/
│   │   └── User.ts               # User model and data operations
│   ├── routes/
│   │   └── authRoutes.ts         # API routes
│   ├── types/
│   │   └── user.types.ts         # TypeScript type definitions
│   └── index.ts                  # Main application entry point
├── .env.example                  # Environment variables template
├── .gitignore                    # Git ignore rules
├── package.json                  # Project dependencies
├── tsconfig.json                 # TypeScript configuration
└── README.md                     # This file
```

## Installation

1. **Navigate to the project directory**:
```bash
cd auth
```

2. **Install dependencies**:
```bash
npm install
```

3. **Set up environment variables**:
```bash
cp .env.example .env
```

4. **Edit `.env` file** with your configuration:
```env
PORT=3000
NODE_ENV=development
JWT_SECRET=your-super-secret-jwt-key-change-this-in-production
JWT_EXPIRES_IN=7d
```

## Running the Application

### Development Mode
```bash
npm run dev
```

### Build for Production
```bash
npm run build
```

### Run Production Build
```bash
npm start
```

The server will start on the port specified in your `.env` file (default: 3000).

## API Endpoints

### 1. Register User
**POST** `/api/auth/register`

Register a new user account.

**Request Body:**
```json
{
  "username": "john_doe",
  "email": "john@example.com",
  "password": "Password123"
}
```

**Response:**
```json
{
  "success": true,
  "message": "User registered successfully",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": "abc123",
    "username": "john_doe",
    "email": "john@example.com"
  }
}
```

**Validation Rules:**
- Username: 3-30 characters, alphanumeric + underscores
- Email: Valid email format
- Password: Minimum 6 characters, must contain uppercase, lowercase, and number

### 2. Login User
**POST** `/api/auth/login`

Authenticate a user and receive a JWT token.

**Request Body:**
```json
{
  "email": "john@example.com",
  "password": "Password123"
}
```

**Response:**
```json
{
  "success": true,
  "message": "Login successful",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": "abc123",
    "username": "john_doe",
    "email": "john@example.com"
  }
}
```

### 3. Get User Profile
**GET** `/api/auth/profile`

Get the authenticated user's profile.

**Headers:**
```
Authorization: Bearer <your-jwt-token>
```

**Response:**
```json
{
  "success": true,
  "message": "Profile retrieved successfully",
  "user": {
    "id": "abc123",
    "username": "john_doe",
    "email": "john@example.com"
  }
}
```

### 4. Verify Token
**GET** `/api/auth/verify`

Verify if a JWT token is valid.

**Headers:**
```
Authorization: Bearer <your-jwt-token>
```

**Response:**
```json
{
  "success": true,
  "message": "Token is valid",
  "userId": "abc123",
  "email": "john@example.com"
}
```

### 5. Health Check
**GET** `/health`

Check if the server is running.

**Response:**
```json
{
  "success": true,
  "message": "Server is running",
  "timestamp": "2024-01-01T00:00:00.000Z"
}
```

## Usage Examples

### Using cURL

**Register a user:**
```bash
curl -X POST http://localhost:3000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "john_doe",
    "email": "john@example.com",
    "password": "Password123"
  }'
```

**Login:**
```bash
curl -X POST http://localhost:3000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "Password123"
  }'
```

**Get profile (with token):**
```bash
curl -X GET http://localhost:3000/api/auth/profile \
  -H "Authorization: Bearer YOUR_JWT_TOKEN"
```

### Using JavaScript/Fetch

```javascript
// Register
const register = async () => {
  const response = await fetch('http://localhost:3000/api/auth/register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      username: 'john_doe',
      email: 'john@example.com',
      password: 'Password123',
    }),
  });
  const data = await response.json();
  console.log(data);
};

// Login
const login = async () => {
  const response = await fetch('http://localhost:3000/api/auth/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      email: 'john@example.com',
      password: 'Password123',
    }),
  });
  const data = await response.json();
  // Store the token for future requests
  localStorage.setItem('token', data.token);
  return data;
};

// Get profile
const getProfile = async () => {
  const token = localStorage.getItem('token');
  const response = await fetch('http://localhost:3000/api/auth/profile', {
    headers: {
      'Authorization': `Bearer ${token}`,
    },
  });
  const data = await response.json();
  console.log(data);
};
```

## Security Features

- **Password Hashing**: Uses bcryptjs with salt rounds for secure password storage
- **JWT Authentication**: Secure token-based authentication
- **Input Validation**: Validates all incoming requests
- **CORS Protection**: Configurable CORS policies
- **Error Handling**: Secure error responses (no sensitive data in production)
- **Environment Variables**: Sensitive data stored in environment variables

## Configuration

### Environment Variables

- `PORT`: Server port (default: 3000)
- `NODE_ENV`: Environment mode (development/production)
- `JWT_SECRET`: Secret key for JWT token signing
- `JWT_EXPIRES_IN`: Token expiration time (default: 7d)

### TypeScript Configuration

The project uses strict TypeScript configuration for type safety:
- Strict null checks
- No implicit any
- Strict function types
- Source map generation for debugging

## Development Notes

### Current Implementation

- **In-Memory Storage**: Users are stored in memory (not suitable for production)
- **No Database**: Uses a simple array-based storage
- **Development Focus**: Built for learning and development purposes

### Production Considerations

For production deployment, consider:

1. **Database Integration**: Replace in-memory storage with a real database (MongoDB, PostgreSQL, etc.)
2. **Enhanced Security**:
   - Rate limiting
   - Account lockout after failed attempts
   - Email verification
   - Password reset functionality
   - Two-factor authentication
3. **Session Management**: Refresh tokens, token revocation
4. **Logging**: Comprehensive logging and monitoring
5. **Testing**: Unit tests, integration tests
6. **Documentation**: API documentation (Swagger/OpenAPI)
7. **Deployment**: Docker containers, CI/CD pipeline

## Error Handling

The API provides consistent error responses:

```json
{
  "success": false,
  "message": "Error description",
  "errors": [] // Validation errors if applicable
}
```

Common HTTP status codes:
- `200`: Success
- `201`: Created
- `400`: Bad Request (validation errors)
- `401`: Unauthorized (invalid/missing token)
- `404`: Not Found
- `409`: Conflict (user already exists)
- `500`: Internal Server Error

## Troubleshooting

### Common Issues

1. **Token Expired**: Generate a new token by logging in again
2. **Invalid Credentials**: Check email and password
3. **User Already Exists**: Try a different email or username
4. **Validation Errors**: Ensure all fields meet the validation requirements

### Development Tips

- Use `npm run dev` for development with hot reload
- Check console logs for detailed error information
- Use the health check endpoint to verify server status
- Test endpoints using cURL, Postman, or similar tools

## License

ISC

## Contributing

This is a learning project. Feel free to fork and modify for your needs.
