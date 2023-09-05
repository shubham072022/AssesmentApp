import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Todo } from '../shared/dtos/Todo.DTO';
import { baseRoute } from '../app.module';
import { IResponse } from '../shared/dtos/Response.DTO';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TodoCreateModel } from '../shared/models/todocreate.model';
import { TodoEditModel } from '../shared/models/todoedit.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  _todoList:BehaviorSubject<Array<Todo>> = new BehaviorSubject<Array<Todo>>([]);
  todoList$:Observable<Array<Todo>> = this._todoList.asObservable();

  constructor(private http:HttpClient,private snackbar:MatSnackBar) { 

  }

  getAllTodo()
  {
    this.http.get(baseRoute + "todo").subscribe(res => {
      var response = res as IResponse;
      if(response.success)
      {
        this._todoList.next(response.data as Todo[]);
      } else {
        this.snackbar.open(response.errors.join(','),'close');
      }
    });
  }

  addTodo(todo:TodoCreateModel)
  {
    this.http.post(baseRoute + 'todo/add',todo)
    .subscribe(res => {
      var response = res as IResponse;
      if(response.success)
      {
        this.getAllTodo();
      }
      else{
        this.snackbar.open(response.errors.join(','),'close');
      }
    });
  }

  modifyTodo(todo:TodoEditModel){
    this.http.put(baseRoute + 'todo/update',todo)
    .subscribe(res => {
      var response = res as IResponse;
      if(response.success)
      {
        this.getAllTodo();
      }
      else{
        this.snackbar.open(response.errors.join(','),'close');
      }
    });
  }

  deletetodod(id:number){
    this.http.delete(baseRoute + 'todo/delete/'+id).subscribe(res => {
      var response = res as IResponse;
      if(response.success)
      {
        this.getAllTodo();
      }
      else{
        this.snackbar.open(response.errors.join(','),'close');
      }
    })
  }
}
