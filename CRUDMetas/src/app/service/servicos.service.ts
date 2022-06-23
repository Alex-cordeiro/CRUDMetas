import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { ServicoDTO } from "../model/DTOs/ServicoDTO.model";
import { ServicosForm } from "../model/formularios/servicos-form.model";

@Injectable({
    providedIn: 'root'
})
export class ServicosService {
    url = 'https://localhost:5001/api'

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    novoRegistro(novoServico: ServicosForm) {
        return this.httpclient.post<ServicosForm>(`${environment.api}/servicos`, novoServico, this.httpOptions)
                .subscribe((retornoNovoRegistro) => {
                    alert(retornoNovoRegistro);
                })
    }

    retornaHistoricoServicos(): Observable<ServicoDTO[]>{
       return this.httpclient.get<ServicoDTO[]>(`${environment.api}/servicos`, this.httpOptions) 
    }
    
}