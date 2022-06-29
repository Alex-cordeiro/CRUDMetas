import {Component,OnInit} from '@angular/core';
import {FormBuilder,FormControl,FormControlName,FormGroup} from '@angular/forms';
import { Empresa } from 'src/app/model/empresa.model';
import { Departamento } from 'src/app/model/departamento.model';
import {VeiculoForm} from 'src/app/model/formularios/veiculo-form.model';
import { Setor } from 'src/app/model/setor.model';
import { Vendedor } from 'src/app/model/vendedor.model';
import { EmpresaService } from 'src/app/service/empresa.service';
import { VeiculoService } from 'src/app/service/veiculo.service';

@Component({
  selector: 'formulario-veiculo',
  templateUrl: './formulario-veiculo.component.html',
  styleUrls: ['./formulario-veiculo.component.sass']
})
export class FormularioVeiculoComponent implements OnInit {

  public empresas!: Array<Empresa>;
  public vendedores!: Array<Vendedor>;
  public setores!: Array<Setor>;
  public departamentos!: Array<Departamento>;
  public formVeiculo!: FormGroup;
  public veiculoEnvio!: VeiculoForm;
  
  constructor(private formBuilder: FormBuilder,
              private empresaService: EmpresaService,
              private veiculoService: VeiculoService) {}

  ngOnInit(): void {
    this.retornaEmpresas();
    this.criarFormulario(new VeiculoForm());
  }
  onSubmit(){
    this.veiculoEnvio = {
      idEmpresa: this.formVeiculo.controls['empresa'].value,
      idDepartamento: this.formVeiculo.controls['departamento'].value,
      idSetor: this.formVeiculo.controls['setor'].value,
      idVendedor: this.formVeiculo.controls['vendedor'].value,
      valor: this.formVeiculo.controls['valor'].value,
      codigo: this.formVeiculo.controls['codigo'].value,
      tipo : this.formVeiculo.controls['tipo'].value,
      familia: this.formVeiculo.controls['familia'].value,
      quantidade: this.formVeiculo.controls['quantidade'].value
    }

  this.veiculoService.novoRegistro(this.veiculoEnvio);
  this.formVeiculo.reset();
  location.reload();
  }

  public criarFormulario(veiculoForm: VeiculoForm) {
    this.formVeiculo = this.formBuilder.group({
      vendedor: new FormControl(veiculoForm.idVendedor),
      empresa: new FormControl(veiculoForm.idEmpresa),
      departamento: new FormControl(veiculoForm.idDepartamento),
      setor: new FormControl(veiculoForm.idSetor),
      //dataValidade: new FormControl(veiculoForm.dataValidade),
      valor: new FormControl(veiculoForm.valor),
      quantidade: new FormControl(veiculoForm.quantidade),
      familia: new FormControl(veiculoForm.familia),
      codigo: new FormControl(veiculoForm.codigo),
      tipo: new FormControl(veiculoForm.tipo)
    })
  }

  public retornaEmpresas(){
    this.empresaService.retornaEmpresas().subscribe((empresasRetorno: any[]) => {
      this.empresas = empresasRetorno;
    });
  }

  public retornaFuncionarioPorEmpresa(idEmpresa: number){
    this.empresaService.retornaVendedoresPorIdEmpresa(idEmpresa).subscribe((vendedoresRetorno: any[]) => {
      this.vendedores = vendedoresRetorno;
    });
  }

  public retornaDepartamentosPorEmpresa(idEmpresa: number){
    this.empresaService.retornaDepartamentosPorIdEmpresa(idEmpresa).subscribe((departamentosRetorno: any[]) => {
      this.departamentos = departamentosRetorno;
    });
  }

  public retornaSetorPorEmpresa(idEmpresa: number){
    this.empresaService.retornaSetoresPorIdEmpresa(idEmpresa).subscribe((setorRetorno: any[]) => {
      this.setores = setorRetorno;
    });
  }

  public selecionaEmpresa(e:any): void{
    if(e.target.value != null){
      const empresaId = e.target.value
      this.retornaFuncionarioPorEmpresa(empresaId);
      this.retornaDepartamentosPorEmpresa(empresaId);
      this.retornaSetorPorEmpresa(empresaId);
    }else {
      alert("Erro tente novamente");
    }
  }
}
