import { Injectable } from '@angular/core';
import { UsuarioLogin } from '../model/usuario-login.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { catchError, delay, retry } from 'rxjs/operators';
import jwt_Decode from 'jwt-decode';
import { LoginResponse } from '../model/login-response.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient,
              private router: Router) { }

  private usuarioLogin!: UsuarioLogin;
  private loginResponse!: LoginResponse;

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  login(usuarioLogin: UsuarioLogin): Observable<any> {
    return this.httpClient.post<any>(`${environment.api}/login`, usuarioLogin, this.httpOptions).pipe(
      tap((resposta) => {
        if(!resposta.authenticated) return;
        this.loginResponse = {
            authenticated: resposta.authenticated,
            created: resposta.created,
            expiration: resposta.expiration,
            accessToken: resposta.accessToken,
            refreshToken: resposta.refreshToken
          };     
        window.localStorage.setItem('token', this.loginResponse.accessToken);
        this.router.navigate(['']);  
      })
    )
  }

  logOff(){
    window.localStorage.clear();
    this.router.navigate(['login']);
  }
  getAuthToken(){
    const token = window.localStorage.getItem('token');
    return token;
  }

  getTokenExpirationDate(token: string): Date | string {
    const decoded: any = jwt_Decode(token);

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
