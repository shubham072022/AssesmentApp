import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
  {
    path:'auth',
    loadChildren: () => import('./layouts/auth/auth.module').then( m => m.AuthModule)
  },
  {
    path:'todo',
    loadChildren: () => import('./layouts/todo/todo.module').then(m => m.TodoModule),
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
