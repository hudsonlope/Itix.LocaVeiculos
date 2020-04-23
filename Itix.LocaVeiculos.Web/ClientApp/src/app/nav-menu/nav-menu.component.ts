import { Component } from '@angular/core';
import { Usuario } from '../model/usuario';
import { Router } from '@angular/router';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  get usuario() {
    return this.usuarioServico.usuario;
  }

  constructor(private router: Router, private usuarioServico: UsuarioServico) {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean {
    var _usuarioAutenticado = this.usuarioServico._usuarioAutenticado;
    if (this.usuarioServico.usuario_autenticado() || _usuarioAutenticado) {
      return true;
    }
    return false;
  }

  sair() {
    sessionStorage.setItem("usuarioLogado", "");
    this.usuarioServico.limpar_sessao();
    window.location.href = this.usuarioServico.baseURL;
    //this.router.navigate(['/']);
  }
}
