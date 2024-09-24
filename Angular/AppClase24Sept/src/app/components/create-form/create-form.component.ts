import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-create-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './create-form.component.html',
  styleUrl: './create-form.component.css'
})
export class CreateFormComponent{
  createUser!: FormGroup;
  
    constructor(private fb: FormBuilder) {
      this.createUser = this.fb.group({
        name: new FormControl('', [Validators.required]),
        age: new FormControl('', [Validators.required, Validators.min(18),Validators.max(99)]),
        genre: new FormControl('', [Validators.required])
      });
    }

    onSubmit() {
      if(this.createUser.valid) {
        console.log('Usuario creado: ', this.createUser.value);
      }
    }
}
