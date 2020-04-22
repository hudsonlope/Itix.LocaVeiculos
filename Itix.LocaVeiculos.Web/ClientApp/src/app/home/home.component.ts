import { Component } from '@angular/core';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  private _usuarioAutenticado: boolean;

  constructor(private usuarioServico: UsuarioServico) {
    this._usuarioAutenticado = usuarioServico.usuario_autenticado();
  }

}
