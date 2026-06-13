import * as userService from '../services/userService.js';

// Create a new user
export async function createUser(request, reply) {
    try {
        const { name, email, age, address, phone } = request.body;

        const user = await userService.createUser({
            name,
            email,
            age,
            address,
            phone,
        });

        reply.status(201).send({
            success: true,
            message: 'User created successfully',
            data: user,
        });
    } catch (error) {
        handleError(error, reply);
    }
}

// Get all users
export async function getAllUsers(request, reply) {
    try {
        const users = await userService.getAllUsers();

        reply.send({
            success: true,
            data: users,
        });
    } catch (error) {
        handleError(error, reply);
    }
}

// Get user by ID
export async function getUserById(request, reply) {
    try {
        const { id } = request.params;
        const user = await userService.getUserById(id);

        reply.send({
            success: true,
            data: user,
        });
    } catch (error) {
        handleError(error, reply);
    }
}

// Update user by ID
export async function updateUser(request, reply) {
    try {
        const { id } = request.params;
        const updateData = request.body;

        const user = await userService.updateUser(id, updateData);

        reply.send({
            success: true,
            message: 'User updated successfully',
            data: user,
        });
    } catch (error) {
        handleError(error, reply);
    }
}

// Delete user by ID
export async function deleteUser(request, reply) {
    try {
        const { id } = request.params;
        const user = await userService.deleteUser(id);

        reply.send({
            success: true,
            message: 'User deleted successfully',
            data: user,
        });
    } catch (error) {
        handleError(error, reply);
    }
}

// Centralized error handling function
function handleError(error, reply) {
    if (error.message === 'User not found') {
        return reply.status(404).send({
            success: false,
            message: error.message,
        });
    }

    if (error.name === 'ValidationError') {
        const messages = Object.values(error.errors).map((err) => err.message);
        return reply.status(400).send({
            success: false,
            message: 'Validation error',
            errors: messages,
        });
    }

    if (error.code === 11000) {
        return reply.status(400).send({
            success: false,
            message: 'Email already exists',
        });
    }

    if (error.name === 'CastError') {
        return reply.status(400).send({
            success: false,
            message: 'Invalid ID format',
        });
    }

    console.error(error);
    reply.status(500).send({
        success: false,
        message: 'Internal server error',
    });
}
