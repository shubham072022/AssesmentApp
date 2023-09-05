import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './todo.component';
import { RouterModule, Routes } from '@angular/router';

const todoRoutes:Routes = [
  {
    path:'',
    component:TodoComponent,
    children: [
      {
        path:'',
        loadChildren: () => import('./tasks/tasks.module').then(m => m.TasksModule)
      }
    ]
  }
]

@NgModule({
  declarations: [
    TodoComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(todoRoutes)
  ]
})
export class TodoModule { }
