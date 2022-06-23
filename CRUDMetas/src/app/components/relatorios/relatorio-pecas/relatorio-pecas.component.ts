import { Component, OnInit, Output } from '@angular/core';
import { PecaDTO } from 'src/app/model/DTOs/PecaDTO.model';
import { PecasService } from 'src/app/service/pecas.service';
import { EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-relatorio-pecas',
  templateUrl: './relatorio-pecas.component.html',
  styleUrls: ['./relatorio-pecas.component.sass']
})
export class RelatorioPecasComponent implements OnInit {

  constructor(private pecasService: PecasService,
              private formbuilder: FormBuilder) { }

  public pecas: Array<PecaDTO> = [];
  public pecaParaEditar!: PecaDTO;
  public formEditar!: FormGroup;
  @Output() pecaEdicao = new EventEmitter();


  ngOnInit(): void {
    this.gerarFormulario(new PecaDTO)
    this.retornaPecasServicos();
    
  }

  public retornaPecasServicos(){
    this.pecasService.retornaHistoricoPecas().subscribe((retornoPecas) => {
      this.pecas = retornoPecas;
      console.log(this.pecas);
    });
  }

  public editaPeca(idPeca: number){
    const pecaEncontrada = this.pecas.find(x => x.id == idPeca);
    if(pecaEncontrada != null){
      this.pecaParaEditar = pecaEncontrada;
    }
    if(this.formEditar.controls['valorPeca'].value != this.pecaParaEditar.valor){
      this.pecaParaEditar.valor = this.formEditar.controls['valorPeca'].value 
      this.pecaParaEditar.id = idPeca
    }
  }

  public gerarFormulario(pecaDto: PecaDTO){
    this.formEditar = this.formbuilder.group({
      idPeca: new FormControl(pecaDto.id),
      valorPeca: new FormControl(pecaDto.valor)
    })
  }
}
