import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { CommonModule} from '@angular/common';

@Component({
  selector: 'app-mostrar-personas',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './showcase.component.html',
  styleUrl: './showcase.component.css'
})

export class ShowcaseComponent implements OnInit {
  
  listSize: number = 10;
  persons: any[] = [];
  constructor(private apiService: ApiService){}

  ngOnInit(): void {
    
    this.apiService.getPersons(1,9).subscribe((data: any) => {
      this.persons = data.results;

      console.log(this.persons);
    },
    (error) => {
      console.error(error);
    })
  }

}
