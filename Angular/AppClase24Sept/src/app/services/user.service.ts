import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://random-person-generator.com/api';

  constructor(private http : HttpClient) { }

  getPerson():Observable<any>{    
    return this.http.get(this.apiUrl);
  }  
}
