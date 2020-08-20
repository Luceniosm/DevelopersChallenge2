import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarregarExtratoComponent } from './extrato/carregar-extrato/carregar-extrato.component';
import { VisualizarExtratoComponent } from './extrato/visualizar-extrato/visualizar-extrato.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'carregar-extrato', component: CarregarExtratoComponent },
  { path: 'visualizar-extrato', component: VisualizarExtratoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled', useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
