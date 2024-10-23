import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ShowcaseComponent } from "./components/mostrar-personas/showcase.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ShowcaseComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'DesafioPracticoModulo2';
}
