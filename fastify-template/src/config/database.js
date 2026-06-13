import mongoose from 'mongoose';

export async function connectDB() {
    try {
        const mongoURI = process.env.MONGODB_URI || 'mongodb://localhost:27017/fastify-crud-api';

        await mongoose.connect(mongoURI);
        console.log('MongoDB connected successfully');

        return mongoose.connection;
    } catch (error) {
        console.error('MongoDB connection error:', error.message);
        process.exit(1);
    }
}

export async function disconnectDB() {
    try {
        await mongoose.disconnect();
        console.log('MongoDB disconnected');
    } catch (error) {
        console.error('MongoDB disconnection error:', error.message);
        process.exit(1);
    }
}
