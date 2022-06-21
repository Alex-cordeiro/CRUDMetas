import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Empresa } from 'src/app/model/empresa.model';
import { PecasEServicosForm } from 'src/app/model/formularios/pecas-form.model';
import { Vendedor } from 'src/app/model/vendedor.model';
import { EmpresaService } from 'src/app/service/empresa.service';

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



  public empresaSelecionada: string =  '';


  constructor(private formBuilder: FormBuilder, private empresaService: EmpresaService) { }



  ngOnInit(): void {
    this.retornaEmpresas();
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


  public retornaEmpresas(){
    this.empresaService.retornaEmpresas().subscribe((empresasRetorno: any[]) => {
      this.empresas = empresasRetorno;
    });
  }

  public retornaFuncionarioPorEmpresas(idEmpresa: number){
    this.empresaService.retornaVendedoresPorIdEmpresa(idEmpresa).subscribe((vendedoresRetorno: any[]) => {
      this.vendedores = vendedoresRetorno;
    });
  }

  public selecionaEmpresa(e:any): void{
    alert(e.target.value);
    console.log(e.target.value);
  }
}
