export interface ITodo{
    id:number;
    title:string;
    isCompleted:boolean;
}

export class Todo implements ITodo {
    id:number;
    title:string;
    isCompleted:boolean;
    constructor(){
        this.id = 0;
        this.title = '';
        this.isCompleted = false;
    }
}