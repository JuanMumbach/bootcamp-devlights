import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'https://randomuser.me/api/';  
  
  constructor(private http: HttpClient) {}

  getPersons(page : number, size : number):Observable<any>{    
    return this.http.get(this.apiUrl+"?page="+page+"&results="+size);
  }  
}