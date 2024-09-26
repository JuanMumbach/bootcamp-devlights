import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Route } from '@angular/router';
import { AppComponent } from './app/app.component';
import { CreateFormComponent } from './app/components/create-form/create-form.component';
import { EditFormComponent } from './app/components/edit-form/edit-form.component';
import { importProvidersFrom } from '@angular/core'; 
import { provideHttpClient } from '@angular/common/http';


const routes: Route[] = [
  { path: '', redirectTo: 'create', pathMatch: 'full' },  // Redirige la ruta vacía a '/create'
  { path: 'create', component: CreateFormComponent },
  { path: 'edit/:id', component: EditFormComponent },
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient()
  ]
});
