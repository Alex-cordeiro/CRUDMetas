import {Component,OnInit} from '@angular/core';
import {FormBuilder,FormControl,FormControlName,FormGroup} from '@angular/forms';
import {VeiculoForm} from 'src/app/model/formularios/veiculo-form.model';

@Component({
  selector: 'formulario-veiculo',
  templateUrl: './formulario-veiculo.component.html',
  styleUrls: ['./formulario-veiculo.component.sass']
})
export class FormularioVeiculoComponent implements OnInit {

  public formVeiculo!: FormGroup;
  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.criarFormulario(new VeiculoForm());
  }
  onSubmit(){
    console.log(this.formVeiculo.value);
  }

  public criarFormulario(veiculoForm: VeiculoForm) {
    this.formVeiculo = this.formBuilder.group({
      vendedor: new FormControl(veiculoForm.idVendedor),
      empresa: new FormControl(veiculoForm.idEmpresa),
      filial: new FormControl(veiculoForm.idFilial),
      setor: new FormControl(veiculoForm.idSetor),
      dataValidade: new FormControl(veiculoForm.dataValidade),
      valor: new FormControl(veiculoForm.valor),
      quantidade: new FormControl(veiculoForm.quantidade),
      familia: new FormControl(veiculoForm.familia),
    })
  }

}
