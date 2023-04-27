import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxCurrencyModule } from "ngx-currency";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CategoriasComponent } from './components/categorias/categorias.component';
import { CategoriaListaComponent } from './components/categorias/categoria-lista/categoria-lista.component';
import { CategoriaDetalheComponent } from './components/categorias/categoria-detalhe/categoria-detalhe.component';

import { GastosComponent } from './components/gastos/gastos.component';
import { GastoListaComponent } from './components/gastos/gasto-lista/gasto-lista.component';
import { GastoDetalheComponent } from './components/gastos/gasto-detalhe/gasto-detalhe.component';

import { FormasPagamentoComponent } from './components/formas-pagamento/formas-pagamento.component';
import { FormaPagamentoListaComponent } from './components/formas-pagamento/forma-pagamento-lista/forma-pagamento-lista.component';
import { FormaPagamentoDetalheComponent } from './components/formas-pagamento/forma-pagamento-detalhe/forma-pagamento-detalhe.component';

import { EstabelecimentosComponent } from './components/estabelecimentos/estabelecimentos.component';
import { EstabelecimentoListaComponent } from './components/estabelecimentos/estabelecimento-lista/estabelecimento-lista.component';
import { EstabelecimentoDetalheComponent } from './components/estabelecimentos/estabelecimento-detalhe/estabelecimento-detalhe.component';

import { ParceladosComponent } from './components/parcelados/parcelados.component';
import { ParceladoListaComponent } from './components/parcelados/parcelado-lista/parcelado-lista.component';
import { ParceladoDetalheComponent } from './components/parcelados/parcelado-detalhe/parcelado-detalhe.component';

import { NavComponent } from './shared/nav/nav.component';

import { TituloComponent } from './shared/titulo/titulo.component';

import { DashboardComponent } from './components/dashboard/dashboard.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

import { CategoriaService } from './services/categoria.service';
import { GastoService } from './services/gasto.service';
import { ParceladoService } from './services/parcelado.service';
import { ParcelaService } from './services/parcela.service';
import { FormaPagamentoService } from './services/formaPagamento.service';
import { EstabelecimentoService } from './services/estabelecimento.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

import { LOCALE_ID, DEFAULT_CURRENCY_CODE } from '@angular/core';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

defineLocale('pt-br', ptBrLocale);
registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [
    AppComponent,
    CategoriasComponent,
    GastosComponent,
    ParceladosComponent,
    NavComponent,
    DateTimeFormatPipe,
    TituloComponent,
    PerfilComponent,
    DashboardComponent,
    GastoDetalheComponent,
    GastoListaComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
    CategoriaDetalheComponent,
    CategoriaListaComponent,
    ParceladoListaComponent,
    ParceladoDetalheComponent,
    FormasPagamentoComponent,
    FormaPagamentoListaComponent,
    FormaPagamentoDetalheComponent,
    EstabelecimentosComponent,
    EstabelecimentoListaComponent,
    EstabelecimentoDetalheComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgxCurrencyModule.forRoot({
      align: "rigth",
      allowNegative: false,
      allowZero: false,
      decimal: ",",
      precision: 2,
      prefix: "R$ ",
      suffix: "",
      thousands: ".",
      nullable: false
    }),
    ToastrModule.forRoot(
      {
        timeOut: 3000,
        positionClass: 'toast-bottom-right',
        preventDuplicates: true,
        progressBar: true,
        progressAnimation: 'increasing',
      }
    ),
  ],

  providers: [
    CategoriaService,
    GastoService,
    ParceladoService,
    ParcelaService,
    FormaPagamentoService,
    EstabelecimentoService,
    {
      provide: LOCALE_ID,
      useValue: 'pt'
    },
    {
      provide:  DEFAULT_CURRENCY_CODE,
      useValue: 'BRL'
    }
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
