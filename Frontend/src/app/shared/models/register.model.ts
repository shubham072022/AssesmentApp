export interface IRegisterModel
{
    email:string;
    password:string;
    confirmPassword:string;
}

export class RegisterModel implements IRegisterModel
{
    email:string;
    password:string;
    confirmPassword:string;
    constructor(){
        this.email = '';
        this.password = '';
        this.confirmPassword = '';
    }
}