import { Request, Response } from 'express';
import bcrypt from 'bcryptjs';
import jwt from 'jsonwebtoken';
import { UserModel } from '../models/User';
import { UserDTO, LoginDTO, AuthResponse, JwtPayload } from '../types/user.types';
import { config } from '../config';

export class AuthController {
  static async register(req: Request, res: Response): Promise<void> {
    try {
      const { username, email, password }: UserDTO = req.body;

      // Validate input
      if (!username || !email || !password) {
        res.status(400).json({
          success: false,
          message: 'All fields are required',
        } as AuthResponse);
        return;
      }

      // Check if user already exists
      const existingUser = await UserModel.findByEmail(email);
      if (existingUser) {
        res.status(409).json({
          success: false,
          message: 'User with this email already exists',
        } as AuthResponse);
        return;
      }

      const existingUsername = await UserModel.findByUsername(username);
      if (existingUsername) {
        res.status(409).json({
          success: false,
          message: 'Username already taken',
        } as AuthResponse);
        return;
      }

      // Hash password
      const salt = await bcrypt.genSalt(10);
      const hashedPassword = await bcrypt.hash(password, salt);

      // Create user
      const user = await UserModel.create({
        username,
        email,
        password: hashedPassword,
      });

      // Generate JWT token
      const token = jwt.sign(
        { userId: user.id, email: user.email } as JwtPayload,
        config.jwtSecret,
        { expiresIn: config.jwtExpiresIn }
      );

      res.status(201).json({
        success: true,
        message: 'User registered successfully',
        token,
        user: {
          id: user.id,
          username: user.username,
          email: user.email,
        },
      } as AuthResponse);
    } catch (error) {
      console.error('Registration error:', error);
      res.status(500).json({
        success: false,
        message: 'Internal server error',
      } as AuthResponse);
    }
  }

  static async login(req: Request, res: Response): Promise<void> {
    try {
      const { email, password }: LoginDTO = req.body;

      // Validate input
      if (!email || !password) {
        res.status(400).json({
          success: false,
          message: 'Email and password are required',
        } as AuthResponse);
        return;
      }

      // Find user
      const user = await UserModel.findByEmail(email);
      if (!user) {
        res.status(401).json({
          success: false,
          message: 'Invalid credentials',
        } as AuthResponse);
        return;
      }

      // Verify password
      const isPasswordValid = await bcrypt.compare(password, user.password);
      if (!isPasswordValid) {
        res.status(401).json({
          success: false,
          message: 'Invalid credentials',
        } as AuthResponse);
        return;
      }

      // Generate JWT token
      const token = jwt.sign(
        { userId: user.id, email: user.email } as JwtPayload,
        config.jwtSecret,
        { expiresIn: config.jwtExpiresIn }
      );

      res.status(200).json({
        success: true,
        message: 'Login successful',
        token,
        user: {
          id: user.id,
          username: user.username,
          email: user.email,
        },
      } as AuthResponse);
    } catch (error) {
      console.error('Login error:', error);
      res.status(500).json({
        success: false,
        message: 'Internal server error',
      } as AuthResponse);
    }
  }

  static async getProfile(req: Request, res: Response): Promise<void> {
    try {
      const userId = (req as any).userId;

      const user = await UserModel.findById(userId);
      if (!user) {
        res.status(404).json({
          success: false,
          message: 'User not found',
        } as AuthResponse);
        return;
      }

      res.status(200).json({
        success: true,
        message: 'Profile retrieved successfully',
        user: {
          id: user.id,
          username: user.username,
          email: user.email,
        },
      } as AuthResponse);
    } catch (error) {
      console.error('Get profile error:', error);
      res.status(500).json({
        success: false,
        message: 'Internal server error',
      } as AuthResponse);
    }
  }
}
