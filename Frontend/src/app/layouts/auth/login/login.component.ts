import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm:FormGroup = new FormGroup({});
  validationMessages = {
    email: [{ type: 'required', message: 'Email is required!' },{type:'email', message:'Enter valid email!'}],
    password: [{ type: 'required', message: 'Password is required!' }]
  }

  constructor(private fb:FormBuilder,private service:AuthService)
  {
    this.loginForm = this.fb.group({
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required]]
    })
  }

  login(){
    this.loginForm.markAllAsTouched();
    this.loginForm.markAsDirty();
    if(this.loginForm.valid){
      this.service.login(this.loginForm.value);
    }
  }
}
