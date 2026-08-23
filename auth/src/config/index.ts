import dotenv from 'dotenv';

dotenv.config();

export const config = {
  port: process.env.PORT || 3000,
  jwtSecret: process.env.JWT_SECRET || 'your-secret-key-change-in-production',
  jwtExpiresIn: process.env.JWT_EXPIRES_IN || '7d',
  nodeEnv: process.env.NODE_ENV || 'development',
};

export const validateConfig = (): void => {
  if (config.jwtSecret === 'your-secret-key-change-in-production' && config.nodeEnv === 'production') {
    throw new Error('JWT_SECRET must be set in production environment');
  }
};
