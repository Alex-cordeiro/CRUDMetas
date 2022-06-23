import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable } from "rxjs";
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
    
}