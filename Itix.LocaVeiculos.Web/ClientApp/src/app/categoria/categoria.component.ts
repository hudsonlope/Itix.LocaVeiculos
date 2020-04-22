import { Component, OnInit } from "@angular/core"
import { Categoria } from "../model/categoria";
import { CategoriaServico } from "../servicos/categoria/categoria.servico";

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

  constructor(private categoriaServico: CategoriaServico) {

  }
  ngOnInit(): void {
    this.categoria = new Categoria();
  }


  public cadastrar() {
    this.ativar_spinner = true;

    this.categoriaServico.cadastrar(this.categoria).subscribe(
      produtoJson => {
        this.mensagem = "";
        this.ativar_spinner = false;
        this.categoriaCadastrada = true;
        console.log(produtoJson);
      },
      err => {
        console.log(err.error);
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );
  }
}
