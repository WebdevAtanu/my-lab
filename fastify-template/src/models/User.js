import mongoose, { Schema } from 'mongoose';

const userSchema = new Schema(
    {
        name: {
            type: String,
            required: [true, 'Please provide user name'],
            trim: true,
            maxlength: [50, 'Name cannot be more than 50 characters'],
        },
        email: {
            type: String,
            required: [true, 'Please provide user email'],
            unique: true,
            lowercase: true,
            match: [/.+@.+\..+/, 'Please provide a valid email'],
        },
        age: {
            type: Number,
            min: [0, 'Age cannot be negative'],
            max: [150, 'Age cannot be more than 150'],
        },
        address: {
            type: String,
            trim: true,
        },
        phone: {
            type: String,
            trim: true,
        },
    },
    {
        timestamps: true,
    }
);

export const User = mongoose.model('User', userSchema);
