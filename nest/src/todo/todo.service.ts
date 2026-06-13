import { Injectable } from '@nestjs/common';
import { Todo } from './todo.interface';

@Injectable()
export class TodoService {
  private todos: Todo[] = [
    {
      id: 1,
      title: 'Learn NestJS',
      completed: false,
    },
  ];

  getAllTodos(): Todo[] {
    return this.todos;
  }

  getTodoById(id: number): Todo | undefined {
    return this.todos.find((todo) => todo.id === id);
  }

  createTodo(title: string): Todo {
    const newTodo: Todo = {
      id: this.todos.length + 1,
      title,
      completed: false,
    };

    this.todos.push(newTodo);

    return newTodo;
  }

  updateTodo(id: number, title: string): Todo | null {
    const todo = this.todos.find((todo) => todo.id === id);

    if (!todo) {
      return null;
    }

    todo.title = title;

    return todo;
  }

  deleteTodo(id: number): string {
    this.todos = this.todos.filter((todo) => todo.id !== id);

    return 'Todo deleted successfully';
  }
}
