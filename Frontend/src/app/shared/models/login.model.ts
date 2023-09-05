export interface ILoginModel
{
    email:string;
    password:string;
}

export class LoginModel implements ILoginModel
{
    email:string;
    password:string;
    constructor(){
        this.email = '';
        this.password = ''
    }
}