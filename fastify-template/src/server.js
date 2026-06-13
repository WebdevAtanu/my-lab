import 'dotenv/config';
import Fastify from 'fastify';
import { connectDB, disconnectDB } from './config/database.js';
import { registerUserRoutes } from './routes/userRoutes.js';

// Create Fastify instance with logging enabled
const fastify = Fastify({
    logger: true,
});

// Hook to run before each request - can be used for authentication, logging, etc.
fastify.addHook('onRequest', async (request, reply) => {
    // Optional: Add custom logic for all requests
});

// Register routes and controllers 
async function registerRoutes() {
    fastify.register(async (fastify) => {
        await registerUserRoutes(fastify);
    }, { prefix: '/api' });

    // Health check endpoint
    fastify.get('/health', async (request, reply) => {
        return { status: 'OK' };
    });
}

// Start the server and connect to the database
async function start() {
    try {
        // Connect to MongoDB
        await connectDB();

        // Register routes
        await registerRoutes();

        const port = process.env.PORT || 3000;
        const address = await fastify.listen({ port, host: '0.0.0.0' });

        console.log(`Server running at ${address}`);
    } catch (error) {
        console.error(error);
        await disconnectDB();
        process.exit(1);
    }
}

// Graceful shutdown on SIGINT and SIGTERM signals
process.on('SIGINT', async () => {
    console.log('Shutting down gracefully...');
    await fastify.close();
    await disconnectDB();
    process.exit(0);
});

process.on('SIGTERM', async () => {
    console.log('Shutting down gracefully...');
    await fastify.close();
    await disconnectDB();
    process.exit(0);
});

start();
