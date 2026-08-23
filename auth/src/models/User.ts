import { User, UserDTO } from '../types/user.types';

export class UserModel {
  private static users: User[] = [];

  static async create(userData: UserDTO): Promise<User> {
    const newUser: User = {
      id: this.generateId(),
      username: userData.username,
      email: userData.email,
      password: userData.password,
      createdAt: new Date(),
      updatedAt: new Date(),
    };

    this.users.push(newUser);
    return newUser;
  }

  static async findByEmail(email: string): Promise<User | undefined> {
    return this.users.find(user => user.email === email);
  }

  static async findById(id: string): Promise<User | undefined> {
    return this.users.find(user => user.id === id);
  }

  static async findByUsername(username: string): Promise<User | undefined> {
    return this.users.find(user => user.username === username);
  }

  static async getAll(): Promise<User[]> {
    return this.users;
  }

  static async delete(id: string): Promise<boolean> {
    const index = this.users.findIndex(user => user.id === id);
    if (index !== -1) {
      this.users.splice(index, 1);
      return true;
    }
    return false;
  }

  private static generateId(): string {
    return Date.now().toString(36) + Math.random().toString(36).substr(2);
  }

  // Helper method for testing - clear all users
  static async clear(): Promise<void> {
    this.users = [];
  }
}
