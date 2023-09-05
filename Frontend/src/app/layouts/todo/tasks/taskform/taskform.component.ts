import { Component,EventEmitter,Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { TodoCreateModel } from 'src/app/shared/models/todocreate.model';

@Component({
  selector: 'app-taskform',
  templateUrl: './taskform.component.html',
  styleUrls: ['./taskform.component.scss']
})
export class TaskformComponent {
  todoForm:FormGroup = new FormGroup({})

  @Output() addTodo:EventEmitter<TodoCreateModel> = new EventEmitter<TodoCreateModel>();

  constructor(private formBuilder:FormBuilder)
  {
    this.todoForm = this.formBuilder.group({
      title:[''],
      isCompleted:[false]
    })
  }

  save(){
    this.addTodo.emit(this.todoForm.value as TodoCreateModel);
    this.todoForm.reset();
  }
}
