import { Component, OnInit } from '@angular/core';
import { TipoMeta } from 'src/app/model/tipo-meta.model';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.sass']
})
export class MasterComponent implements OnInit {

  constructor() { }
  public tiposMetas: Array<TipoMeta> = [];
  public teste!: string;
  ngOnInit(): void {
    this.criaOpcoesTipo();
  }


 
  //METODO DE MOCK RETIRAR APÓS O DESENVOLVIMENTO DO BACKEND!!!
  public criaOpcoesTipo(){
    this.tiposMetas.push(new TipoMeta(1,'Peças e Serviços', 'pecas-servicos'));
    this.tiposMetas.push(new TipoMeta(2,'Veiculos', 'veiculos'));
  }

}
