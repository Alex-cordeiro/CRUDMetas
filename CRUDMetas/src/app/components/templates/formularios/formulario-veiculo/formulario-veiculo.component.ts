import {Component,OnInit} from '@angular/core';
import {FormBuilder,FormControl,FormControlName,FormGroup} from '@angular/forms';
import { Empresa } from 'src/app/model/empresa.model';
import { Filial } from 'src/app/model/filial.model';
import {VeiculoForm} from 'src/app/model/formularios/veiculo-form.model';
import { Setor } from 'src/app/model/setor.model';
import { Vendedor } from 'src/app/model/vendedor.model';
import { EmpresaService } from 'src/app/service/empresa.service';

@Component({
  selector: 'formulario-veiculo',
  templateUrl: './formulario-veiculo.component.html',
  styleUrls: ['./formulario-veiculo.component.sass']
})
export class FormularioVeiculoComponent implements OnInit {

  public empresas!: Array<Empresa>;
  public vendedores!: Array<Vendedor>;
  public setores!: Array<Setor>;
  public filiais!: Array<Filial>;
  
  public formVeiculo!: FormGroup;
  constructor(private formBuilder: FormBuilder,
              private empresaService: EmpresaService) {}

  ngOnInit(): void {
    this.retornaEmpresas();
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

  public retornaFilialPorEmpresa(idEmpresa: number){
    this.empresaService.retornaFiliaisPorIdEmpresa(idEmpresa).subscribe((filiaisRetorno: any[]) => {
      this.filiais = filiaisRetorno;
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
      this.retornaFilialPorEmpresa(empresaId);
      this.retornaSetorPorEmpresa(empresaId);
    }else {
      alert("Erro tente novamente");
    }
  }
}
