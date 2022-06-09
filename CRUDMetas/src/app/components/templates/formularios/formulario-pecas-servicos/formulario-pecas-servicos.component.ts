import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { PecasEServicosForm } from 'src/app/model/formularios/pecas-form.model';

@Component({
  selector: 'app-formulario-pecas-servicos',
  templateUrl: './formulario-pecas-servicos.component.html',
  styleUrls: ['./formulario-pecas-servicos.component.sass']
})
export class FormularioPecasServicosComponent implements OnInit {

  public formPecasServicos!: FormGroup;


  constructor(private formBuilder: FormBuilder) { }



  ngOnInit(): void {
    this.geraFormulario(new PecasEServicosForm());
  }

  onSubmit(){
    console.log(this.formPecasServicos.value);
  }

  public geraFormulario(pecasEServicosForm: PecasEServicosForm){
    this.formPecasServicos = this.formBuilder.group({
      vendedor: new FormControl(pecasEServicosForm.idVendedor),
      empresa: new FormControl(pecasEServicosForm.idEmpresa),
      filial: new FormControl(pecasEServicosForm.idFilial),
      setor: new FormControl(pecasEServicosForm.idSetor),
      dataValidade: new FormControl(pecasEServicosForm.dataValidade),
      valor: new FormControl(pecasEServicosForm.valor)
    })
  }
}
