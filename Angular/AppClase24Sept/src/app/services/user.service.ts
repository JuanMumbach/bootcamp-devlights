import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; // Importamos HttpClient
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://random-person-generator.com/api'; // URL de una API de ejemplo

  constructor(private http: HttpClient) {}

  // Método para obtener los usuarios desde la API
  getUsers(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
