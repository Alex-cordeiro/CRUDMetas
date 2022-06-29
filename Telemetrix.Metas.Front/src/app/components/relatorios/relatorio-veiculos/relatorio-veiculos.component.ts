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
  public veiculoParaEditar!: VeiculoDTO;
  public valorEditar!: number;

  ngOnInit(): void {
    this.retornaVeiculos();
  }

  public retornaVeiculos(){
    this.veiculosService.retornaHistoricoVeiculos().subscribe((retornoVeiculos) => {
      this.veiculos = retornoVeiculos;
    });
  }

  async editaPeca(idPeca: number){
    const veiculoEncontrado = this.veiculos.find(x => x.id == idPeca);
      if(veiculoEncontrado != null){
        this.veiculoParaEditar = veiculoEncontrado;
        if(this.veiculoParaEditar != null){
          this.veiculoParaEditar.valor = this.valorEditar
          this.valorEditar = 0;
        }
         await this.veiculosService.editaVeiculo(this.veiculoParaEditar).subscribe((res) => {
          console.log(JSON.stringify(res));
        })
      }
  }

  public recebeValorEditado(valor:any){
    this.valorEditar = 0;
    this.valorEditar = valor.target.value;
  }
}
