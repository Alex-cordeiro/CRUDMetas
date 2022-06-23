import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AutenticacaoComponent } from './components/conta/autenticacao/autenticacao.component';
import { LoginComponent } from './components/conta/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { MasterComponent } from './components/master/master.component';
import { FormularioPecasComponent} from './components/formularios/formulario-pecas/formulario-pecas.component';
import { FormularioVeiculoComponent } from './components/formularios/formulario-veiculo/formulario-veiculo.component';
import { AuthGuard } from './guard/auth.guard';
import { FormularioServicosComponent } from './components/formularios/formulario-servicos/formulario-servicos.component';

const routes: Routes = [
  {path: '', 
  component: MasterComponent,
  children: [
    {path: 'veiculos', component: FormularioVeiculoComponent},
    {path: 'pecas', component: FormularioPecasComponent},
    {path: 'servicos', component: FormularioServicosComponent},
  ],
  canActivate: [AuthGuard]
  },
 
  {
    path: '',
    component: AutenticacaoComponent,
    children:[
      {path: '', redirectTo: 'login', pathMatch: 'full'},
      {path: 'login', component: LoginComponent},
    ]
  },
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
