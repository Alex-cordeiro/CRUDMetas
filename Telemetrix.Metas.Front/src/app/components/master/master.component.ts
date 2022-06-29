import { Component, OnInit } from '@angular/core';
import { TipoMeta } from 'src/app/model/tipo-meta.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.sass']
})
export class MasterComponent implements OnInit {

  constructor(private authService: AuthService) { }
  public tiposMetas: Array<TipoMeta> = [];
  public parametroEditar!: string;
  ngOnInit(): void {
    this.criaOpcoesTipo();
  }


 
  //METODO DE MOCK RETIRAR APÓS O DESENVOLVIMENTO DO BACKEND!!!
  public criaOpcoesTipo(){
    this.tiposMetas.push(new TipoMeta(1,'Peças', 'pecas'));
    this.tiposMetas.push(new TipoMeta(2,'Veiculos', 'veiculos'));
    this.tiposMetas.push(new TipoMeta(3,'Serviços', 'servicos'));
  }

  public deslogar(){
    this.authService.logOff();
  }
}
