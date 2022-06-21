import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, throwError } from "rxjs";
import { AuthService } from "src/app/service/auth.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor{
    constructor(
        private authService: AuthService
    ){}

    intercept(req: HttpRequest<any>, next: HttpHandler){
        const token = this.authService.getAuthToken();
        let request: HttpRequest<any> = req;

        if(token) {
            request = req.clone({
                headers: req.headers.set('Authorization', `Bearer ${token}`)
            });
        }

        return next.handle(request)
            .pipe(
                catchError(this.handleError)
            );
    }

    private handleError(error: HttpErrorResponse){
        if(error.error instanceof ErrorEvent){
            console.error('Ocorreu um erro:', error.error.message);
        }else{
            console.error(
                `Codigo do erro ${error.status}`, + 
                `Erro: ${JSON.stringify(error.error)}`
            );
        }
        return throwError('Ocorreu um erro, tente novamente');
    }
}