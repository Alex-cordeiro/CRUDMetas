import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable, tap, retry, throwError, catchError } from "rxjs";
import { environment } from "src/environments/environment";
import { ServicoDTO } from "../model/DTOs/ServicoDTO.model";
import { ServicosForm } from "../model/formularios/servicos-form.model";

@Injectable({
    providedIn: 'root'
})
export class ServicosService {

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    novoRegistro(novoServico: ServicosForm) {
        return this.httpclient.post<ServicosForm>(`${environment.api}/servico`, novoServico, this.httpOptions)
                .subscribe(
                    (retornoNovoRegistro) => {
                        //informar ao serviço de mensagem posterior
                    alert(retornoNovoRegistro);
                })
    }

    retornaHistoricoServicos(): Observable<ServicoDTO[]>{
       return this.httpclient.get<ServicoDTO[]>(`${environment.api}/servico`, this.httpOptions) 
    }

    editaServico(pecaEdicao: ServicoDTO): Observable<ServicoDTO>{
        return this.httpclient.put<ServicoDTO>(`${environment.api}/servico/EditaServico`, pecaEdicao, this.httpOptions)
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