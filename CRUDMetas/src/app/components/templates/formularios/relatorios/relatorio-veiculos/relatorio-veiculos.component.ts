import { Component, OnInit } from '@angular/core';
import { PecasEServicosDTO } from 'src/app/model/DTOs/PecasEServicosDTO.model';
import { VeiculoService } from 'src/app/service/veiculo.service';


@Component({
  selector: 'app-relatorio-veiculos',
  templateUrl: './relatorio-veiculos.component.html',
  styleUrls: ['./relatorio-veiculos.component.sass']
})
export class RelatorioVeiculosComponent implements OnInit {

  constructor(private veiculosService: VeiculoService) { }

  public pecasServicos!: Array<PecasEServicosDTO>;

  ngOnInit(): void {
    this.retornaVeiculos();
  }

  public retornaVeiculos(){
    this.veiculosService.retornaHistoricoVeiculos().subscribe((retornoPecasServicos) => {
      this.pecasServicos = retornoPecasServicos;
    });
  }
}
