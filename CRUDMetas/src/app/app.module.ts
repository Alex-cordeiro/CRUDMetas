import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HistoricoMetasComponent } from './components/paginas/historico-metas/historico-metas.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormularioVeiculoComponent } from './components/templates/formularios/formulario-veiculo/formulario-veiculo.component';
import { FormularioPecasServicosComponent } from './components/templates/formularios/formulario-pecas-servicos/formulario-pecas-servicos.component';
import { MasterComponent } from './components/master/master.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/conta/login/login.component';
import { AutenticacaoComponent } from './components/conta/autenticacao/autenticacao.component';
import { httpInterceptorProviders } from './Interceptors';
import { RelatorioVeiculosComponent } from './components/templates/formularios/relatorios/relatorio-veiculos/relatorio-veiculos.component';
import { RelatorioPecasEServicosComponent } from './components/templates/formularios/relatorios/relatorio-pecas-e-servicos/relatorio-pecas-e-servicos.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HistoricoMetasComponent,
    FormularioVeiculoComponent,
    FormularioPecasServicosComponent,
    MasterComponent,
    LoginComponent,
    AutenticacaoComponent,
    RelatorioVeiculosComponent,
    RelatorioPecasEServicosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
