import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Empresa } from 'src/app/model/empresa.model';
import { Departamento } from 'src/app/model/departamento.model';
import { PecasForm } from 'src/app/model/formularios/pecas-form.model';
import { Setor } from 'src/app/model/setor.model';
import { Vendedor } from 'src/app/model/vendedor.model';
import { EmpresaService } from 'src/app/service/empresa.service';
import { PecasService } from 'src/app/service/pecas.service';
import { PecaDTO } from 'src/app/model/DTOs/PecaDTO.model';
import { TipoEnum } from 'src/app/model/enum/tipo.enum';
import { TipoEntradaMeta } from 'src/app/model/tipos-entrada-meta.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-formulario-pecas',
  templateUrl: './formulario-pecas.component.html',
  styleUrls: ['./formulario-pecas.component.sass']
})
export class FormularioPecasComponent implements OnInit {

  public formPecas!: FormGroup;
  public empresas!: Array<Empresa>;
  public vendedores!: Array<Vendedor>;
  public empresaEnvio!: Empresa;
  public vendedorEnvio!: Vendedor;
  public setores!: Array<Setor>;
  public departamentos!: Array<Departamento>;
  public empresaSelecionada: string =  '';
  public formulariopecasEnvio!: PecasForm;
  public validaEditar!: boolean;
  public pecaEdicao!: PecaDTO;
  public editar!: boolean;
  public formPecasEditar!: PecaDTO;
  public enumKeys: Array<any> = [];
  public tiposEntradaMeta: Array<TipoEntradaMeta> = [];

  constructor(private formBuilder: FormBuilder,
     private pecasServicosService: PecasService,
     private empresaService: EmpresaService,
     private router: Router
     ) {}
     

  ngOnInit(): void {
    this.retornaEmpresas();
    this.geraFormulario(new PecasForm());
    this.criaTipos();
  }

  onSubmit(){
      this.formulariopecasEnvio = {
        idEmpresa: this.formPecas.controls['empresa'].value,
        idDepartamento: this.formPecas.controls['departamento'].value,
        idSetor: this.formPecas.controls['setor'].value,
        idVendedor: this.formPecas.controls['vendedor'].value,
        valor: this.formPecas.controls['valor'].value,
        codigo: this.formPecas.controls['codigo'].value,
        tipo : this.formPecas.controls['tipo'].value,
        dataValidade: new Date(this.formPecas.controls['dataValidade'].value),
        cpf: this.formPecas.controls['cpf'].value
      }
      this.pecasServicosService.novoRegistro(this.formulariopecasEnvio);
      this.formPecas.reset();
      this.reloadComponent();
  }

  public geraFormulario(pecasForm: PecasForm){
    this.formPecas = this.formBuilder.group({
      vendedor: new FormControl(pecasForm.idVendedor),
      empresa: new FormControl(pecasForm.idEmpresa),
      departamento: new FormControl(pecasForm.idDepartamento),
      setor: new FormControl(pecasForm.idSetor),
      cpf: new FormControl(pecasForm.cpf),
      valor: new FormControl(pecasForm.valor),
      tipo: new FormControl(pecasForm.tipo),
      codigo: new FormControl(pecasForm.codigo),
      dataValidade: new FormControl(pecasForm.dataValidade)
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

  public criaTipos(){
    this.tiposEntradaMeta.push(new TipoEntradaMeta(1, "Volume", "Volume"));
    this.tiposEntradaMeta.push(new TipoEntradaMeta(2, "Faturamento", "Faturamento (R$)"));
    this.tiposEntradaMeta.push(new TipoEntradaMeta(3, "Margem", "Margem(R$)"));
    this.tiposEntradaMeta.push(new TipoEntradaMeta(4, "Margem", "Margem(%)"));
  }

  reloadComponent() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/pecas']);
}
}
