import { User } from '../models/User.js';

// Create a new user 
export async function createUser(userData) {
    try {
        const user = new User(userData);
        await user.save();
        return user;
    } catch (error) {
        throw error;
    }
}

// Get all users
export async function getAllUsers() {
    try {
        const users = await User.find();
        return users;
    } catch (error) {
        throw error;
    }
}

// Get user by ID
export async function getUserById(id) {
    try {
        const user = await User.findById(id);
        if (!user) {
            throw new Error('User not found');
        }
        return user;
    } catch (error) {
        throw error;
    }
}

// Update user by ID
export async function updateUser(id, updateData) {
    try {
        const user = await User.findByIdAndUpdate(id, updateData, {
            new: true,
            runValidators: true,
        });
        if (!user) {
            throw new Error('User not found');
        }
        return user;
    } catch (error) {
        throw error;
    }
}

// Delete user by ID
export async function deleteUser(id) {
    try {
        const user = await User.findByIdAndDelete(id);
        if (!user) {
            throw new Error('User not found');
        }
        return user;
    } catch (error) {
        throw error;
    }
}
