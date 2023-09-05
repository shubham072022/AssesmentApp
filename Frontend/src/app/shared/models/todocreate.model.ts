export interface ITodoCreateModel{
    title:String;
    isCompleted:boolean;
}

export class TodoCreateModel implements ITodoCreateModel {
    title:String;
    isCompleted:boolean;
    constructor(){
        this.title = '';
        this.isCompleted = false;
    }
}