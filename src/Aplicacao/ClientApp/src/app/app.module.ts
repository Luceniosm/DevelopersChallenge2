import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxCurrencyModule } from 'ngx-currency';
import { NgxPaginationModule } from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { ConfirmComponent } from './common/confirm/confirm.component';
import { ConfirmService } from './common/confirm/confirm.service';
import { CarregarExtratoComponent } from './extrato/carregar-extrato/carregar-extrato.component';
import { EditarExtratoComponent } from './extrato/editar-extrato/editar-extrato.component';
import { ListarExtratoComponent } from './extrato/listar-extrato/listar-extrato.component';
import { VisualizarExtratoComponent } from './extrato/visualizar-extrato/visualizar-extrato.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CarregarExtratoComponent,
    EditarExtratoComponent,
    ListarExtratoComponent,
    VisualizarExtratoComponent,
    ConfirmComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
    NgxCurrencyModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    AppRoutingModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      closeButton: false,
      disableTimeOut: false,
      tapToDismiss: true,
      preventDuplicates: true,
      positionClass: 'toast-top-right'
    })
  ],
  providers: [
    ConfirmService
  ],
  bootstrap: [AppComponent],
  entryComponents: [ConfirmComponent],
})
export class AppModule { }
