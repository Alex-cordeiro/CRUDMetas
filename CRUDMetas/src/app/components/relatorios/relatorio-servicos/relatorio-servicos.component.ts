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

  public servicos!: Array<ServicoDTO>
  ngOnInit(): void {
    this.retornaPecasServicos();
  }

  public retornaPecasServicos(){
    this.servicoService.retornaHistoricoServicos().subscribe((retornoServicos) => {
      this.servicos = retornoServicos;
      console.log(this.servicos);
    });
  }
}
