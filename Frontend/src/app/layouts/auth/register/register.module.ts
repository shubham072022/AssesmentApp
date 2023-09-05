import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

const registerRoutes:Routes = [
  {
    path:'',
    component: RegisterComponent,
  }
]

@NgModule({
  declarations: [
    RegisterComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(registerRoutes)
  ]
})
export class RegisterModule { }
