import { Task } from './task.interface';

export class TaskItem implements Task {
  title: string;
  completed: boolean;

  constructor(title: string) {
    this.title = title;
    this.completed = false;
  }

  toggleCompleted(): void {
    this.completed = !this.completed;
  }
}