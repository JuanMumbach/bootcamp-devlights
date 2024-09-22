import { Component, OnInit } from '@angular/core';
import { TaskItem } from '../models/task-item.model';
import { Task } from '../models/task.interface';
import { TaskComponent } from '../task/task.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-to-do-list-app',
  standalone: true,
  imports: [TaskComponent,FormsModule,CommonModule],
  templateUrl: './to-do-list-app.component.html',
  styleUrls: ['./to-do-list-app.component.css']
})
export class ToDoListAppComponent implements OnInit {

  list: Task[] = [];
  newTaskTitle: string = ''; // Nueva propiedad para almacenar el título de la tarea

  constructor() {}

  ngOnInit(): void {}

  get ListIsEmpty(): boolean {
    return this.list.length === 0;
  }

  AddElementToList(): void {
    if (this.newTaskTitle.trim()) { // Verifica que no esté vacío
      const newTask = new TaskItem(this.newTaskTitle);
      this.list.push(newTask);
      this.newTaskTitle = ''; // Limpia el input después de agregar la tarea
    }
  }

  DeleteTask(index: number): void {
    this.list.splice(index, 1);
  }
}