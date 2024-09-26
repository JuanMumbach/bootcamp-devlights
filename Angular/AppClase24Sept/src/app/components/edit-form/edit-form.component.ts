import { Component, OnInit} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-edit-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    RouterModule
  ],
  templateUrl: './edit-form.component.html',
  styleUrl: './edit-form.component.css'
})
export class EditFormComponent {

  editUser!: FormGroup;
  user: any;
  
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.editUser = this.fb.group({
      name: new FormControl('', [Validators.required]),
      age: new FormControl('', [Validators.required, Validators.min(18), Validators.max(99)]),
      genre: new FormControl('', [Validators.required])
    });
  }

  ngOnInit(): void {
    this.userService.getPerson().subscribe(
      (data: any) => {
        this.user = data;
        
        // Asegúrate de que los valores coincidan con el objeto "identification"
        this.editUser.patchValue({
          name: this.user.identification.full_name,  // Extrae el nombre de "identification"
          age: this.user.identification.age,         // Extrae la edad de "identification"
          genre: this.user.identification.gender     // Extrae el género de "identification"
        });

        console.log(this.user);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onSubmit() {
    if (this.editUser.valid) {
      console.log(this.editUser.value);
    }
  }

}