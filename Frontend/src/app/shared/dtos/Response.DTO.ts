export interface IResponse{
    statusCode:number;
    success:boolean;
    message:string;
    errors:string[];
    data:any;
}