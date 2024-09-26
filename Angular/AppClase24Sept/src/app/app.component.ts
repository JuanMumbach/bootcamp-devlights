import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CreateFormComponent } from './components/create-form/create-form.component';
import { EditFormComponent } from "./components/edit-form/edit-form.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CreateFormComponent,
    EditFormComponent
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AppClase24Sept';
}

