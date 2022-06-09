import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MasterComponent } from './components/master/master.component';
import { FormularioPecasServicosComponent } from './components/templates/formularios/formulario-pecas-servicos/formulario-pecas-servicos.component';
import { FormularioVeiculoComponent } from './components/templates/formularios/formulario-veiculo/formulario-veiculo.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'veiculos', component: FormularioVeiculoComponent},
  {path: 'pecas-servicos', component: FormularioPecasServicosComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
