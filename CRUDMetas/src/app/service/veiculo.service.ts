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
import { VeiculoDTO } from "../model/DTOs/VeiculosDTO.model";

@Injectable({
    providedIn: 'root'
})
export class VeiculoService {

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    novoRegistro(pecasServicos: VeiculoDTO) {
        return this.httpclient.post<VeiculoDTO>(`${environment.api}/veiculos`, pecasServicos, this.httpOptions)
                .subscribe((retornoNovoRegistro) => {
                    alert(retornoNovoRegistro);
                })
    }

    retornaHistoricoVeiculos(): Observable<VeiculoDTO[]>{
       return this.httpclient.get<VeiculoDTO[]>(`${environment.api}/veiculos`, this.httpOptions) 
    }
    
}