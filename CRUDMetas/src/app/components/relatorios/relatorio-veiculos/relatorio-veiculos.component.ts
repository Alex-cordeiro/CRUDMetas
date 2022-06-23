import { Component, OnInit } from '@angular/core';
import { VeiculoDTO } from 'src/app/model/DTOs/VeiculoDTO.model';
import { VeiculoService } from 'src/app/service/veiculo.service';


@Component({
  selector: 'app-relatorio-veiculos',
  templateUrl: './relatorio-veiculos.component.html',
  styleUrls: ['./relatorio-veiculos.component.sass']
})
export class RelatorioVeiculosComponent implements OnInit {

  constructor(private veiculosService: VeiculoService) { }

  public veiculos!: Array<VeiculoDTO>;

  ngOnInit(): void {
    this.retornaVeiculos();
  }

  public retornaVeiculos(){
    this.veiculosService.retornaHistoricoVeiculos().subscribe((retornoVeiculos) => {
      this.veiculos = retornoVeiculos;
    });
  }
}
