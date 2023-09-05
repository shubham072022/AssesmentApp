import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth.component';
import { RouterModule, Routes } from '@angular/router';

const authRoutes:Routes = [
  {
    path:'',
    component:AuthComponent,
    children:[
      {
        path:'login',
        loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
      },
      {
        path:'register',
        loadChildren: () => import('./register/register.module').then(m => m.RegisterModule)
      }
    ]
  }
]

@NgModule({
  declarations: [
    AuthComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(authRoutes)
  ]
})
export class AuthModule { }
