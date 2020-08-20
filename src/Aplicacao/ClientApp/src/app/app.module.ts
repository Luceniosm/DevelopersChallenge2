import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxCurrencyModule } from 'ngx-currency';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConfirmComponent } from './common/confirm/confirm.component';
import { ConfirmService } from './common/confirm/confirm.service';
import { CarregarExtratoComponent } from './extrato/carregar-extrato/carregar-extrato.component';
import { EditarExtratoComponent } from './extrato/editar-extrato/editar-extrato.component';
import { ListarExtratoComponent } from './extrato/listar-extrato/listar-extrato.component';
import { VisualizarExtratoComponent } from './extrato/visualizar-extrato/visualizar-extrato.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';


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
    NgxCurrencyModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    AppRoutingModule,
    PaginationModule.forRoot(),
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
