import { Component } from '@angular/core';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  //private _usuarioAutenticado: boolean;
  public _usuarioAutenticado: boolean;

  get usuario() {
    return this.usuarioServico.usuario;
  }

  constructor(private usuarioServico: UsuarioServico) {
    //this._usuarioAutenticado = usuarioServico.usuario_autenticado();
    this._usuarioAutenticado = sessionStorage.getItem("usuarioLogado") == "true";
  }

}
