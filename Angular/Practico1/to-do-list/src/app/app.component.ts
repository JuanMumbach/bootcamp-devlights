import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToDoListAppComponent } from "./to-do-list-app/to-do-list-app.component";
import { TaskComponent } from './task/task.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToDoListAppComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'to-do-list';
}
