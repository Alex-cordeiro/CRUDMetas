import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { catchError, Observable, retry, tap, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { VeiculoDTO } from "../model/DTOs/VeiculoDTO.model";
import { VeiculoForm } from "../model/formularios/veiculo-form.model";

@Injectable({
    providedIn: 'root'
})
export class VeiculoService {

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    novoRegistro(novoVeiculo: VeiculoForm) {
        return this.httpclient.post<VeiculoForm>(`${environment.api}/veiculo`, novoVeiculo, this.httpOptions)
                .subscribe((retornoNovoRegistro) => {
                    alert(retornoNovoRegistro);
                })
    }

    retornaHistoricoVeiculos(): Observable<VeiculoDTO[]>{
       return this.httpclient.get<VeiculoDTO[]>(`${environment.api}/veiculo`, this.httpOptions) 
    }

    editaVeiculo(veiculoEdicao: VeiculoDTO): Observable<VeiculoDTO>{
        return this.httpclient.put<VeiculoDTO>(`${environment.api}/veiculo/EditaVeiculo`, veiculoEdicao, this.httpOptions)
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