import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

//Remover
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { CategoriaComponent } from './categoria/categoria.component';
import { LoginComponent } from './usuario/login/login.component';
import { GuardaRotas } from './autorizacao/guarda.rotas';
import { UsuarioServico } from './servicos/usuario/usuario.servico';
import { CadastroUsuarioComponent } from './usuario/cadastro/cadastro.usuario.component';
import { CategoriaServico } from './servicos/categoria/categoria.servico';
import { CarroServico } from './servicos/carro/carro.servico';
import { CarroComponent } from './carro/carro.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,

    //Remover
    CounterComponent,
    FetchDataComponent,

    CategoriaComponent,
    CarroComponent,
    LoginComponent,
    CadastroUsuarioComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'app-home', component: HomeComponent, canActivate: [GuardaRotas] },
      { path: 'categoria', component: CategoriaComponent, canActivate: [GuardaRotas] },
      { path: 'carro', component: CarroComponent, canActivate: [GuardaRotas] },

      //Remover
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },

      { path: '', component: LoginComponent },
      { path: 'novo-usuario', component: CadastroUsuarioComponent }

    ])
  ],
  providers: [UsuarioServico, CategoriaServico, CarroServico],
  bootstrap: [AppComponent]
})
export class AppModule { }


//{ path: 'app-home', component: HomeComponent, pathMatch: 'full' },
//{ path: 'categoria', component: CategoriaComponent, canActivate: [GuardaRotas] },
