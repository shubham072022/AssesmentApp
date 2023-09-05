import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, catchError, map, switchMap, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IResponse } from '../dtos/Response.DTO';
import { AuthService } from 'src/app/services/auth.service';

@Injectable()
export class HttpInterceptorInterceptor implements HttpInterceptor {

  constructor(private snackbar:MatSnackBar,private authService:AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone({
      setHeaders: {
        'Content-Type': 'application/json',
      }
    });

    var token = localStorage.getItem("token");
    if(token)
    {
      request = request.clone({
        headers: request.headers.append('Authorization',`Bearer ${token}`),
      });
    }
    
    return next.handle(request);
  }
}
