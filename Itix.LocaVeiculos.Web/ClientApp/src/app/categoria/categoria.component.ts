import { Component, OnInit } from "@angular/core"
import { Categoria } from "../model/categoria";
import { CategoriaServico } from "../servicos/categoria/categoria.servico";
import { UsuarioServico } from "../servicos/usuario/usuario.servico";

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})

export class CategoriaComponent implements OnInit {
  public categoria: Categoria;
  public ativar_spinner: boolean;
  public categoriaCadastrada: boolean; 
  public mensagem: string;
  //public _UrlCategoria = this.usuarioServico.baseURL + "categoria";

  constructor(private categoriaServico: CategoriaServico, private usuarioServico: UsuarioServico) {

  }
  ngOnInit(): void {
    this.categoria = new Categoria();
  }


  public cadastrar() {
    this.ativar_spinner = true;

    this.categoriaServico.cadastrar(this.categoria).subscribe(
      categoriaJson => {
        this.mensagem = "";
        this.ativar_spinner = false;
        this.categoriaCadastrada = true;

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
