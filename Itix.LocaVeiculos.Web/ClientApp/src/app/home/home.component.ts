import { Component } from '@angular/core';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';
import { CarroServico } from '../servicos/carro/carro.servico';
import { Carro } from '../model/carro';
import { HomeServico } from '../servicos/home/home.servico';
import { carroLocado } from '../model/carroLocado';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  //private _usuarioAutenticado: boolean;
  public _usuarioAutenticado: boolean;

  public carroLocado: carroLocado;
  public ativar_spinner: boolean;
  public cadastrado: boolean;
  public mensagem: string;
  public carros: Carro[];

  get usuario() {
    return this.usuarioServico.usuario;
  }

  constructor(private usuarioServico: UsuarioServico, private carroServico: CarroServico, private homeServico: HomeServico) {
    //this._usuarioAutenticado = usuarioServico.usuario_autenticado();
    this._usuarioAutenticado = sessionStorage.getItem("usuarioLogado") == "true";
    this.carroLocado = new carroLocado();
    this.obterCarros();
  }


  public obterCarros() {
    this.carroServico.obterTodosCarros().subscribe(
      carrosJson => {
        var defaultCarro = new Carro();
        defaultCarro.carro_Id = 9999999;
        defaultCarro.marca = "Selecione um veículo";
        defaultCarro.modelo = "";
        defaultCarro.ano = "";


        carrosJson.push(defaultCarro);
        this.carros = carrosJson;
      },
      err => {
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );
  }

  public cadastrar() {
    this.ativar_spinner = true;
    this.carroLocado.usuario_Id = this.usuario.usuario_Id;
    this.homeServico.cadastrar(this.carroLocado).subscribe(
      carroJson => {
        debugger;
        this.mensagem = "";
        this.ativar_spinner = false;
        this.cadastrado = true;
        this.ResetForm();


      },
      err => {
        console.log(err.error);
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );
  }

  ResetForm() {
    var resetForm: HTMLFormElement;
    resetForm = <HTMLFormElement>document.getElementById('formulario');
    if (resetForm)
      resetForm.reset();
  }
}
