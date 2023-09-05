export interface ITodoEditModel{
    id:number;
    title:string;
    isCompleted:boolean;
}

export class TodoEditModel implements ITodoEditModel
{
    id:number;
    title:string;
    isCompleted:boolean;
    constructor(){
        this.id = 0;
        this.title = "";
        this.isCompleted = false;
    }
}