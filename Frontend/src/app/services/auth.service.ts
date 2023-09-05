import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegisterModel } from '../shared/models/register.model';
import { IResponse } from '../shared/dtos/Response.DTO';
import { LoginResponse } from '../shared/dtos/LoginResponse.DTO';
import { Router } from '@angular/router';
import { LoginModel } from '../shared/models/login.model';
import { baseRoute } from '../app.module';
import { MatSnackBar } from '@angular/material/snack-bar';
import { map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient,private router:Router,private snackbar:MatSnackBar) { }

  register(model:IRegisterModel)
  {
    this.http.post(baseRoute + 'auth/register',model).subscribe(res => {
      debugger
      var response = res as IResponse;
      if(response.success)
      {
        var token = response.data as LoginResponse;
        localStorage.setItem("Token",token.accessToken);
        localStorage.setItem("token",token.accessToken);
        localStorage.setItem("RefreshToken",token.refreshToken);
        localStorage.setItem("refreshtoken",token.refreshToken);
        this.router.navigate(["/todo"])
      } else {
        this.snackbar.open(response.errors.join(','),'close');
      }
    })
  }

  login(model:LoginModel){
    this.http.post(baseRoute + 'auth/login',model).subscribe(res => {
      var response = res as IResponse;
      if(response.success)
      {
        var token = response.data as LoginResponse;
        localStorage.setItem("Token",token.accessToken);
        localStorage.setItem("token",token.accessToken);
        localStorage.setItem("RefreshToken",token.refreshToken);
        localStorage.setItem("refreshtoken",token.refreshToken);
        this.router.navigate(["/todo"])
      } else {
        this.snackbar.open(response.errors.join(','),'close');
      }
    })
  }

  logout(){
    localStorage.removeItem("Token");
    localStorage.removeItem("token");
    localStorage.removeItem("RefreshToken");
    localStorage.removeItem("refreshtoken");
    this.router.navigate(["/auth/login"])
  }

  refreshToken(){
    return this.http
      .post(baseRoute + '/auth/refreshtoken', {
        refreshToken: localStorage.getItem("refreshtoken"),
        currentToken: localStorage.getItem("token"),
      });
  }
}
