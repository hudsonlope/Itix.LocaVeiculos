import { Component, OnInit } from "@angular/core"
import { Usuario } from "../../model/usuario";
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  public usuario: Usuario;
  public returnUrl: string;
  public mensagem: string;
  private ativar_spinner: boolean;
  public _usuarioAutenticado = this.usuarioServico._usuarioAutenticado;
  public _UrlNovoUsuario = this.usuarioServico.baseURL + "novo-usuario";

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private usuarioServico: UsuarioServico) {

  }
  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.usuario = new Usuario();
  }

  entrar() {
    this.ativar_spinner = true;
    this.usuarioServico.verificarUsuario(this.usuario).subscribe(
      usuario_json => {

        this.usuarioServico.usuario = usuario_json;

        if (this.returnUrl == null) {
          //this.router.navigate(['/app-home']);
          sessionStorage.setItem("usuarioLogado", "true");
          window.location.href = this.usuarioServico.baseURL + "app-home";
        }
        else {
          this.router.navigate([this.returnUrl]);
        }
      },
      err => {
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );
  }


}
