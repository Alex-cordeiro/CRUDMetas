import { Component, OnInit } from '@angular/core';
import { ServicoDTO } from 'src/app/model/DTOs/ServicoDTO.model';
import { ServicosService } from 'src/app/service/servicos.service';

@Component({
  selector: 'app-relatorio-servicos',
  templateUrl: './relatorio-servicos.component.html',
  styleUrls: ['./relatorio-servicos.component.sass']
})
export class RelatorioServicosComponent implements OnInit {


  constructor(private servicoService: ServicosService) { }
  public valorEditar!: number;
  public servicos!: Array<ServicoDTO>
  public servicoParaEditar!: ServicoDTO;
  ngOnInit(): void {
    this.retornaPecasServicos();
  }

  public retornaPecasServicos(){
    this.servicoService.retornaHistoricoServicos().subscribe((retornoServicos) => {
      this.servicos = retornoServicos;
      console.log(this.servicos);
    });
  }

  async editaPeca(idPeca: number){
    const servicoEncontrado = this.servicos.find(x => x.id == idPeca);
      if(servicoEncontrado != null){
        this.servicoParaEditar = servicoEncontrado;
        if(this.valorEditar != null){
          this.servicoParaEditar.valor = this.valorEditar
        }
         await this.servicoService.editaServico(this.servicoParaEditar).subscribe((res) => {
          console.log(JSON.stringify(res));
        })
      }
  }

  public recebeValorEditado(valor:any){
    this.valorEditar = 0;
    this.valorEditar = valor.target.value;
  }
}
