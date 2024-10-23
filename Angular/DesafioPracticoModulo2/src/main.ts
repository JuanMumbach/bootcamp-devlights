import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Route } from '@angular/router';
import { AppComponent } from './app/app.component';
import { ShowcaseComponent } from './app/components/mostrar-personas/showcase.component';
import { importProvidersFrom } from '@angular/core'; 
import { provideHttpClient } from '@angular/common/http';


const routes: Route[] = [
  { path: '', redirectTo: 'Showcase', pathMatch: 'full' },  // Redirige la ruta vacía a '/create'
  { path: 'Showcase', component: ShowcaseComponent }
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient()
  ]
});
