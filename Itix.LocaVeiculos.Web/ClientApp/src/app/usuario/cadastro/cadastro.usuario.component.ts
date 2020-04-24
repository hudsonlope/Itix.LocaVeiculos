import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../model/usuario";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: 'cadastro-usuario',
  templateUrl: './cadastro.usuario.component.html',
  styleUrls: ['./cadastro.usuario.component.css']
})

export class CadastroUsuarioComponent implements OnInit {
  public usuario: Usuario;
  public ativar_spinner: boolean;
  public mensagem: string;
  public usuarioCadastrado: boolean;
  public _UrlVoltar = this.usuarioServico.baseURL + "";

  constructor(private usuarioServico: UsuarioServico) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  public cadastrar() {
    this.ativar_spinner = true;

    this.usuarioServico.cadastrarUsuario(this.usuario).subscribe(
      usuarioJson => {
        this.usuarioCadastrado = true;
        this.mensagem = "";
        this.ativar_spinner = false;

        var resetForm: HTMLFormElement;
        resetForm = <HTMLFormElement>document.getElementById('formulario');
        if (resetForm)
          resetForm.reset();
      },
      err => {
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );
  }
}
