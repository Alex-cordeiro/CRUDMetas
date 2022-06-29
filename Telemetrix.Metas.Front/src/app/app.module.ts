import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HistoricoMetasComponent } from './components/paginas/historico-metas/historico-metas.component';
import { FormularioVeiculoComponent } from './components/formularios/formulario-veiculo/formulario-veiculo.component';
import { FormularioPecasComponent } from './components/formularios/formulario-pecas/formulario-pecas.component';
import { MasterComponent } from './components/master/master.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/conta/login/login.component';
import { AutenticacaoComponent } from './components/conta/autenticacao/autenticacao.component';
import { httpInterceptorProviders } from './Interceptors';
import { RelatorioVeiculosComponent } from './components/relatorios/relatorio-veiculos/relatorio-veiculos.component';
import { RelatorioPecasComponent } from './components/relatorios/relatorio-pecas/relatorio-pecas.component';
import { FormularioServicosComponent } from './components/formularios/formulario-servicos/formulario-servicos.component';
import { RelatorioServicosComponent } from './components/relatorios/relatorio-servicos/relatorio-servicos.component';
import { InputEditarComponent } from './components/templates/input-editar/input-editar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FiltroPecasPipe } from './components/pipes/filtro-pecas.pipe';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HistoricoMetasComponent,
    FormularioVeiculoComponent,
    FormularioPecasComponent,
    MasterComponent,
    LoginComponent,
    AutenticacaoComponent,
    RelatorioVeiculosComponent,
    RelatorioPecasComponent,
    FormularioServicosComponent,
    RelatorioServicosComponent,
    InputEditarComponent,
    FiltroPecasPipe,
   
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
