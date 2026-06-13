import * as userController from '../controllers/userController.js';

export async function registerUserRoutes(fastify) {

    //  Create a new user
    //  POST /api/users
    fastify.post('/users', async (request, reply) => {
        await userController.createUser(request, reply);
    });

    //  Get all users
    //  GET /api/users
    fastify.get('/users', async (request, reply) => {
        await userController.getAllUsers(request, reply);
    });

    //  Get user by ID
    //  GET /api/users/:id     
    fastify.get('/users/:id', async (request, reply) => {
        await userController.getUserById(request, reply);
    });

    //  Update user by ID
    //  PUT /api/users/:id
    fastify.put('/users/:id', async (request, reply) => {
        await userController.updateUser(request, reply);
    });

    //  Delete user by ID
    //  DELETE /api/users/:id
    fastify.delete('/users/:id', async (request, reply) => {
        await userController.deleteUser(request, reply);
    });
}
