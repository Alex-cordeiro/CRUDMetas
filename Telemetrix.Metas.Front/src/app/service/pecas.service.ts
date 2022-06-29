import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { catchError, Observable, retry, tap, throwError } from "rxjs";
import { PecasForm } from "../model/formularios/pecas-form.model";
import { environment } from "src/environments/environment";
import { PecaDTO } from "../model/DTOs/PecaDTO.model";

@Injectable({
    providedIn: 'root'
})
export class PecasService {

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    novoRegistro(novoRegistro: PecasForm) {
        return this.httpclient.post<PecasForm>(`${environment.api}/Peca`, novoRegistro, this.httpOptions)
                .subscribe(
                    res => {
                        
                    },
                    erro =>{
                        if(erro.status == 400)
                        alert(erro);       
                    }
                )
    }

    retornaHistoricoPecas(): Observable<PecaDTO[]>{
       return this.httpclient.get<PecaDTO[]>(`${environment.api}/Peca`, this.httpOptions) 
    }

    editaPeca(pecaEdicao: PecaDTO): Observable<PecaDTO>{
        return this.httpclient.post<PecaDTO>(`${environment.api}/Peca/EditaPeca`, pecaEdicao, this.httpOptions)
            .pipe(
                tap(
                    (resposta) => {
                        if(resposta){
                            //inserir futura mensagem para o usuario
                        }
                    }
                ),
                retry(2),
                catchError((err) => {
                    console.log('erro no serviço!')
                    console.error(err);
                    return throwError(err);
                })
                )
    }


    handleError(error: HttpErrorResponse) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
          // Erro ocorreu no lado do client
          errorMessage = error.error.message;
        } else {
          // Erro ocorreu no lado do servidor
          errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
      };
    
}