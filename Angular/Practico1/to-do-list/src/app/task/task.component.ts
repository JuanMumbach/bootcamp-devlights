import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Task } from '../models/task.interface';  // Asegúrate de que la interfaz Task esté en la ruta correcta

@Component({
  selector: 'app-task',
  standalone: true, // Esto indica que es un componente standalone
  imports: [CommonModule], // Importa módulos necesarios
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  @Input() task!: Task; // Recibe la tarea desde el componente padre
  @Output() removeTask = new EventEmitter<void>(); // Emite un evento al padre para eliminar la tarea

  onToggleCompleted(): void {
    this.task.completed = !this.task.completed;
  }

  onRemoveTask(): void {
    this.removeTask.emit(); // Emite el evento para eliminar la tarea
  }
}