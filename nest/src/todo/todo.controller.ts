import {
  Controller,
  Get,
  Post,
  Put,
  Delete,
  Param,
  Body,
} from '@nestjs/common';
import { TodoService } from './todo.service';

@Controller('todos')
export class TodoController {
  constructor(private readonly todoService: TodoService) {}

  @Get()
  getAllTodos() {
    return this.todoService.getAllTodos();
  }

  @Get(':id')
  getTodoById(@Param('id') id: string) {
    return this.todoService.getTodoById(Number(id));
  }

  @Post()
  createTodo(@Body('title') title: string) {
    return this.todoService.createTodo(title);
  }

  @Put(':id')
  updateTodo(@Param('id') id: string, @Body('title') title: string) {
    return this.todoService.updateTodo(Number(id), title);
  }

  @Delete(':id')
  deleteTodo(@Param('id') id: string) {
    return this.todoService.deleteTodo(Number(id));
  }
}
