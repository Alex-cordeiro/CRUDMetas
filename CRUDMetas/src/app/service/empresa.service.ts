import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable } from "rxjs";
import { Empresa } from "../model/empresa.model";
import { Vendedor } from "../model/vendedor.model";
import { Departamento } from "../model/departamento.model";
import { Setor } from "../model/setor.model";

@Injectable({
    providedIn: 'root'
})
export class EmpresaService {
    url = 'https://localhost:5001/api'

    constructor(private httpclient: HttpClient) {}

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    retornaEmpresas(): Observable<Empresa[]> {
        return this.httpclient.get<Empresa[]>(this.url + '/empresa')
    }

    retornaVendedoresPorIdEmpresa(idEmpresa: number): Observable<Vendedor[]> {
        return this.httpclient.get<Vendedor[]>(this.url + '/vendedor/' + idEmpresa)
    }

    retornaDepartamentosPorIdEmpresa(idEmpresa: number): Observable<Departamento[]> {
        return this.httpclient.get<Departamento[]>(this.url + '/departamento/' + idEmpresa)
    }

    retornaSetoresPorIdEmpresa(idEmpresa: number): Observable<Setor[]> {
        return this.httpclient.get<Setor[]>(this.url + '/setor/' + idEmpresa)
    }
    
}