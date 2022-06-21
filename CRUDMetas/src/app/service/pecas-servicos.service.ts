import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable } from "rxjs";
import { Empresa } from "../model/empresa.model";
import { Vendedor } from "../model/vendedor.model";
import { Filial } from "../model/filial.model";
import { Setor } from "../model/setor.model";
import { PecasEServicosForm } from "../model/formularios/pecas-form.model";
import { environment } from "src/environments/environment";
import { PecasEServicosDTO } from "../model/DTOs/PecasEServicosDTO.model";

@Injectable({
    providedIn: 'root'
})
export class PecasServicosService {
    url = 'https://localhost:5001/api'

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    novoRegistro(pecasServicos: PecasEServicosForm) {
        return this.httpclient.post<PecasEServicosForm>(`${environment.api}/PecasServicos`, pecasServicos, this.httpOptions)
                .subscribe((retornoNovoRegistro) => {
                    alert(retornoNovoRegistro);
                })
    }

    retornaHistoricopecasServicos(): Observable<PecasEServicosDTO[]>{
       return this.httpclient.get<PecasEServicosDTO[]>(`${environment.api}/PecasServicos`, this.httpOptions) 
    }
    
}