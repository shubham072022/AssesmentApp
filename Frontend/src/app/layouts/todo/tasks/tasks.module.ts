import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TasksComponent } from './tasks.component';
import { TaskformComponent } from './taskform/taskform.component';
import { TasklistComponent } from './tasklist/tasklist.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { TodoComponent } from '../todo.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { LetModule, PushModule } from '@ngrx/component';

const taskRoutes:Routes = [
  {
    path:'',
    component: TasksComponent
  }
]

@NgModule({
  declarations: [
    TasksComponent,
    TaskformComponent,
    TasklistComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    LetModule,
    RouterModule.forChild(taskRoutes)
  ]
})
export class TasksModule { }
