import { Injectable } from "@angular/core";
import { Route, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router"
import { UsuarioServico } from "../servicos/usuario/usuario.servico";

@Injectable({
  providedIn: 'root'
})
export class GuardaRotas implements CanActivate {

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }

  canActivate(_route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    //this.usuarioServico
    if (this.usuarioServico.usuario_autenticado()) {
      return true;
    }

    //se usuario não autenticado
    this.router.navigate([''], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
