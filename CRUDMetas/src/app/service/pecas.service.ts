import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable } from "rxjs";
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

    editaPeca(pecaEdicao: PecaDTO){
        return this.httpclient.put<PecaDTO>(`${environment.api}/Peca`, pecaEdicao, this.httpOptions)
    }
    
}