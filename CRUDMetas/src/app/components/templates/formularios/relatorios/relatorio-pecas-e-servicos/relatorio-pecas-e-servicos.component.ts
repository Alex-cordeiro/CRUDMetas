import { Component, OnInit } from '@angular/core';
import { PecasEServicosDTO } from 'src/app/model/DTOs/PecasEServicosDTO.model';
import { PecasServicosService } from 'src/app/service/pecas-servicos.service';

@Component({
  selector: 'app-relatorio-pecas-e-servicos',
  templateUrl: './relatorio-pecas-e-servicos.component.html',
  styleUrls: ['./relatorio-pecas-e-servicos.component.sass']
})
export class RelatorioPecasEServicosComponent implements OnInit {

  constructor(private pecasServicosService: PecasServicosService) { }

  public pecasServicos!: Array<PecasEServicosDTO>;
  ngOnInit(): void {
    this.retornaPecasServicos();
  }

  public retornaPecasServicos(){
    this.pecasServicosService.retornaHistoricopecasServicos().subscribe((retornoPecasServicos) => {
      this.pecasServicos = retornoPecasServicos;
      console.log(this.pecasServicos);
    });
  }

}
