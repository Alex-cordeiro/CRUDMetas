import { Component, ElementRef, OnInit, Output, ViewChild } from '@angular/core';
import { PecaDTO } from 'src/app/model/DTOs/PecaDTO.model';
import { PecasService } from 'src/app/service/pecas.service';
import { EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { debounceTime, fromEvent, pipe } from 'rxjs';

@Component({
  selector: 'app-relatorio-pecas',
  templateUrl: './relatorio-pecas.component.html',
  styleUrls: ['./relatorio-pecas.component.sass'],
})
export class RelatorioPecasComponent implements OnInit {

  constructor(private pecasService: PecasService,
              private formbuilder: FormBuilder,
             ) { }

  public pecas: Array<PecaDTO> = [];
  public pecasFiltroAuxiliar: Array<PecaDTO> = [];
  public pecaParaEditar!: PecaDTO;
  public formEditar!: FormGroup;
  public valorEditar!: number;
  public filtroAnterior!: string;
  public tabelaTotal: boolean = true;

  @ViewChild('campoBusca') campoBusca!: ElementRef<HTMLInputElement>;

  @Output() pecaEdicao = new EventEmitter();


  ngOnInit(): void {
    this.retornaPecasServicos();
  }

  public retornaPecasServicos(){
    this.pecasService.retornaHistoricoPecas().subscribe((retornoPecas) => {
      this.pecas = retornoPecas;
      this.pecasFiltroAuxiliar = retornoPecas;
    });
  }

  public gerarFormulario(pecaDto: PecaDTO){
    this.formEditar = this.formbuilder.group({
      idPeca: new FormControl(pecaDto.id),
      valorPeca: new FormControl(pecaDto.valor)
    })
  }

  async editaPeca(idPeca: number){
    const pecaEncontrada = this.pecas.find(x => x.id == idPeca);
      if(pecaEncontrada != null){
        this.pecaParaEditar = pecaEncontrada;
        if(this.valorEditar != null){
          this.pecaParaEditar.valor = this.valorEditar
        }
         await this.pecasService.editaPeca(this.pecaParaEditar).subscribe((res) => {
          console.log(JSON.stringify(res));
        })
      }
  }
  deletaPeca(idPeca: number){
    const pecaEncontrada = this.pecas.find(x => x.id == idPeca);
    if(pecaEncontrada != null){
      this.pecaParaEditar = pecaEncontrada;
      if(this.valorEditar != null){
        this.pecaParaEditar.valor = this.valorEditar
      }
       this.pecasService.editaPeca(this.pecaParaEditar).subscribe((res) => {
        console.log(JSON.stringify(res));
      })
    }
  }

  public recebeValorEditado(valor:any){
    this.valorEditar = 0;
    this.valorEditar = valor.target.value;
  }

  public filtrar(palavrachave: any){
      palavrachave = palavrachave.target.value.toUpperCase();
      if(this.filtroAnterior != palavrachave){
        this.pecas = this.pecasFiltroAuxiliar;
        this.pecas = this.pecas.filter(p =>
          p.vendedor.toUpperCase().indexOf(palavrachave) >= 0);
      }
      
      this.filtroAnterior = palavrachave;
      if(palavrachave == ''){
        console.log('pesquisa vazia')
        this.pecas = this.pecasFiltroAuxiliar;
      }
    this.filtroAnterior = palavrachave;
  }
}

