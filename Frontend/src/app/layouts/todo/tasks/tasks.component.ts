import { Component } from '@angular/core';
import { Observable, map } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { TodoService } from 'src/app/services/todo.service';
import { Todo } from 'src/app/shared/dtos/Todo.DTO';
import { TodoCreateModel } from 'src/app/shared/models/todocreate.model';
import { TodoEditModel } from 'src/app/shared/models/todoedit.model';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss']
})
export class TasksComponent {
  todos$:Observable<Array<Todo>> = new Observable<Array<Todo>>();

  constructor(private service:TodoService,private authservice:AuthService){
    this.todos$ = this.service.todoList$.pipe(map(res => {
      return res;
    }));

    this.service.getAllTodo();
  }

  add(todo:TodoCreateModel){
    this.service.addTodo(todo);
  }

  modify(todo:TodoEditModel){
    this.service.modifyTodo(todo);
  }

  delete(id:number){
    this.service.deletetodod(id);
  }

  logout(){
    this.authservice.logout();
  }

}
