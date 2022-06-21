import { Injectable } from '@angular/core';
import { UsuarioLogin } from '../model/usuario-login.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError, delay, retry } from 'rxjs/operators';
import jwt_decode from "jwt-decode";
import { LoginResponse } from '../model/login-response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://localhost:5001/api';

  private usuarioLogin!: UsuarioLogin;
  private loginResponse!: LoginResponse;

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  login(usuarioLogin: UsuarioLogin){
    this.httpClient.post<any>(`${environment.api}/login`, usuarioLogin, this.httpOptions)
      .subscribe((resultReq) => {
        this.loginResponse = {
          authenticated: resultReq.authenticated,
          created: resultReq.created,
          expiration: resultReq.expiration,
          accessToken: resultReq.accessToken,
          refreshToken: resultReq.refreshToken
        };     
          window.localStorage.setItem('token', this.loginResponse.accessToken);  
      })
      if(this.getAuthToken()){
        return true;
      }
    return false;
  }

  getAuthToken(){
    const token = window.localStorage.getItem('token');
    return token;
  }

  getTokenExpirationDate(token: string): Date | string {
    const decoded: any = jwt_decode(token);

    if(decoded.exp === undefined){
      return '';
    }

    const date = new Date(0);
    date.setUTCSeconds(decoded.exp);
    return date;
  }

  isTokenExpired(token?: string): boolean{
    if(!token){
      return true;
    }
    const date = this.getTokenExpirationDate(token);
    if(date === ''){
      return false;
    }

    return !(date.valueOf() > new Date().valueOf());
  }

  isUserLoggedIn(){
    const token = this.getAuthToken();
    if(!token) {
      return false;
    }else if (this.isTokenExpired(token)){
      return false;
    }
    return true;
  }
}
