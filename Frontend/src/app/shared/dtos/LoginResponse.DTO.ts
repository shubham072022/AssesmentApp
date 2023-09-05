export interface ILoginResponse {
    accessToken:string;
    refreshToken:string;
}

export class LoginResponse implements ILoginResponse{
    accessToken:string;
    refreshToken:string;
    constructor()
    {
        this.accessToken = '';
        this.refreshToken = '';
    }
}