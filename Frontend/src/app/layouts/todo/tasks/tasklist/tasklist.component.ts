import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from 'src/app/shared/dtos/Todo.DTO';
import { TodoEditModel } from 'src/app/shared/models/todoedit.model';

@Component({
  selector: 'app-tasklist',
  templateUrl: './tasklist.component.html',
  styleUrls: ['./tasklist.component.scss']
})
export class TasklistComponent {
  checked = false;
  @Input() todos$:Observable<Array<Todo>> = new Observable<Array<Todo>>();

  @Output() modify:EventEmitter<TodoEditModel> = new EventEmitter<TodoEditModel>();
  @Output() delete:EventEmitter<number> = new EventEmitter<number>();

  constructor()
  {}

  modifytodo(todo:Todo){
    this.modify.emit(todo as TodoEditModel);
  }

  deleteTodo(id:number){
    this.delete.emit(id);
  }

}
