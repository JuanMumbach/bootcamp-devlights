import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TaskItem } from '../models/task-item.model';
import { TaskComponent } from '../task/task.component';

@Component({
  selector: 'app-to-do-list-app',
  standalone: true,
  imports: [CommonModule,TaskComponent],
  templateUrl: './to-do-list-app.component.html',
  styleUrl: './to-do-list-app.component.css'
})
export class ToDoListAppComponent implements OnInit{
  
  list: TaskItem[] = []; 
  constructor(){}

  ngOnInit(): void {
  }

  get ListIsEmpty(): boolean {
    return this.list.length === 0;
  }
  AddElementToList(): void{
    let newTask : TaskItem = new TaskItem("Nueva Tarea" + this.list.length);
    this.list.push(newTask);
  }

  DeleteTask(i : number): void{
    this.list.splice(i,1);
  }
}
