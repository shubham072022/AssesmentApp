import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  form:FormGroup = new FormGroup({});

  constructor(private fb:FormBuilder,private service:AuthService) {
    this.form = this.fb.group({
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required,Validators.minLength(8)]],
      confirmPassword:['',[Validators.required,Validators.minLength(8)]]
    });
  }

  register(){
    if(this.form.valid)
    {
      this.service.register(this.form.value);
    }
  }
}
