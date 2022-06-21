import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Empresa } from 'src/app/model/empresa.model';
import { Filial } from 'src/app/model/filial.model';
import { PecasEServicosForm } from 'src/app/model/formularios/pecas-form.model';
import { Setor } from 'src/app/model/setor.model';
import { Vendedor } from 'src/app/model/vendedor.model';
import { EmpresaService } from 'src/app/service/empresa.service';
import { PecasServicosService } from 'src/app/service/pecas-servicos.service';

@Component({
  selector: 'app-formulario-pecas-servicos',
  templateUrl: './formulario-pecas-servicos.component.html',
  styleUrls: ['./formulario-pecas-servicos.component.sass']
})
export class FormularioPecasServicosComponent implements OnInit {

  public formPecasServicos!: FormGroup;
  public empresas!: Array<Empresa>;
  public vendedores!: Array<Vendedor>;
  public empresaEnvio!: Empresa;
  public vendedorEnvio!: Vendedor;
  public setores!: Array<Setor>;
  public filiais!: Array<Filial>;


  public empresaSelecionada: string =  '';
  public formulariopecasServicosEnvio!: PecasEServicosForm;

  constructor(private formBuilder: FormBuilder,
     private pecasServicosService: PecasServicosService,
     private empresaService: EmpresaService
              ) { }



  ngOnInit(): void {
    this.retornaEmpresas();
    this.geraFormulario(new PecasEServicosForm());
  }

  onSubmit(){
    if(this.formPecasServicos.valid){
      this.formulariopecasServicosEnvio = {
        idEmpresa: this.formPecasServicos.controls['empresa'].value,
        idFilial: this.formPecasServicos.controls['filial'].value,
        idSetor: this.formPecasServicos.controls['setor'].value,
        idVendedor: this.formPecasServicos.controls['vendedor'].value,
        valor: this.formPecasServicos.controls['valor'].value,
      }
    }

    this.pecasServicosService.novoRegistro(this.formulariopecasServicosEnvio);
  }

  public geraFormulario(pecasEServicosForm: PecasEServicosForm){
    this.formPecasServicos = this.formBuilder.group({
      vendedor: new FormControl(pecasEServicosForm.idVendedor),
      empresa: new FormControl(pecasEServicosForm.idEmpresa),
      filial: new FormControl(pecasEServicosForm.idFilial),
      setor: new FormControl(pecasEServicosForm.idSetor),
      valor: new FormControl(pecasEServicosForm.valor)
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
