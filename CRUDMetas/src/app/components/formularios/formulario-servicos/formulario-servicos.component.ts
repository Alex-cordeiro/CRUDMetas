import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Departamento } from 'src/app/model/departamento.model';
import { Empresa } from 'src/app/model/empresa.model';
import { PecasForm } from 'src/app/model/formularios/pecas-form.model';
import { ServicosForm } from 'src/app/model/formularios/servicos-form.model';
import { Setor } from 'src/app/model/setor.model';
import { Vendedor } from 'src/app/model/vendedor.model';
import { EmpresaService } from 'src/app/service/empresa.service';
import { ServicosService } from 'src/app/service/servicos.service';

@Component({
  selector: 'app-formulario-servicos',
  templateUrl: './formulario-servicos.component.html',
  styleUrls: ['./formulario-servicos.component.sass']
})
export class FormularioServicosComponent implements OnInit {

  constructor(private servicoService: ServicosService,
              private formBuilder: FormBuilder,
              private empresaService: EmpresaService) { }

  public formServico!: FormGroup;
  public empresas!: Array<Empresa>;
  public vendedores!: Array<Vendedor>;
  public empresaEnvio!: Empresa;
  public vendedorEnvio!: Vendedor;
  public setores!: Array<Setor>;
  public departamentos!: Array<Departamento>;

  public empresaSelecionada: string =  '';
  public formulariopecasEnvio!: ServicosForm;



  ngOnInit(): void {
    this.retornaEmpresas();
    this.geraFormulario(new ServicosForm());
  }

  onSubmit(){
    if(this.formServico.valid){
      this.formulariopecasEnvio = {
        idEmpresa: this.formServico.controls['empresa'].value,
        idDepartamento: this.formServico.controls['departamento'].value,
        idSetor: this.formServico.controls['setor'].value,
        idVendedor: this.formServico.controls['vendedor'].value,
        valor: this.formServico.controls['valor'].value,
        codigo: this.formServico.controls['codigo'].value,
        tipo: this.formServico.controls['tipo'].value
      }
    }

    this.servicoService.novoRegistro(this.formulariopecasEnvio);
  }

  public geraFormulario(servicosForm: ServicosForm){
    this.formServico = this.formBuilder.group({
      vendedor: new FormControl(servicosForm.idVendedor),
      empresa: new FormControl(servicosForm.idEmpresa),
      departamento: new FormControl(servicosForm.idDepartamento),
      setor: new FormControl(servicosForm.idSetor),
      valor: new FormControl(servicosForm.valor),
      tipo: new FormControl(servicosForm.tipo),
      codigo: new FormControl(servicosForm.codigo)
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
      this.retornaFilialPorEmpresa(empresaId);
      this.retornaSetorPorEmpresa(empresaId);
    }else {
      alert("Erro tente novamente");
    }
  }

  public selecionaFilial(e:any): void{
    if(e != null){
      this.retornaFilialPorEmpresa(e.target.value);
    }else {
      alert("Erro tente novamente");
    }
  }

  public selecionaSetor(e:any): void{
    if(e != null){
      this.retornaSetorPorEmpresa(e.target.value);
    }else {
      alert("Erro tente novamente");
    }
  }

}
