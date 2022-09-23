import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';

import { CategoriasComponent } from './components/categorias/categorias.component';
import { CategoriaDetalheComponent } from './components/categorias/categoria-detalhe/categoria-detalhe.component';
import { CategoriaListaComponent } from './components/categorias/categoria-lista/categoria-lista.component';

import { GastosComponent } from './components/gastos/gastos.component';
import { GastoDetalheComponent } from './components/gastos/gasto-detalhe/gasto-detalhe.component';
import { GastoListaComponent } from './components/gastos/gasto-lista/gasto-lista.component';

import { ParceladosComponent } from './components/parcelados/parcelados.component';
import { ParceladoDetalheComponent } from './components/parcelados/parcelado-detalhe/parcelado-detalhe.component';
import { ParceladoListaComponent } from './components/parcelados/parcelado-lista/parcelado-lista.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ]
  },

  { path: 'user/perfil', component: PerfilComponent },

  {
    path: 'dashboard', component: DashboardComponent
  },

  { path: 'gasto', redirectTo: 'gasto/lista' },
  {
    path: 'gasto', component: GastosComponent,
    children: [
      { path: 'detalhe/:id', component: GastoDetalheComponent },
      { path: 'detalhe', component: GastoDetalheComponent },
      { path: 'lista', component: GastoListaComponent },
    ]
  },

  { path: 'parcelado', redirectTo: 'parcelado/lista' },
  {
    path: 'parcelado', component: ParceladosComponent,
    children: [
      { path: 'detalhe/:id', component: ParceladoDetalheComponent },
      { path: 'detalhe', component: ParceladoDetalheComponent },
      { path: 'lista', component: ParceladoListaComponent },
    ]
  },

  { path: 'categoria', redirectTo: 'categoria/lista' },
  {
    path: 'categoria', component: CategoriasComponent,
    children: [
      { path: 'detalhe/:id', component: CategoriaDetalheComponent },
      { path: 'detalhe', component: CategoriaDetalheComponent },
      { path: 'lista', component: CategoriaListaComponent },
    ]
  },

  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
