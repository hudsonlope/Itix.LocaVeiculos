import { Component, OnInit } from "@angular/core"
import { Carro } from "../model/carro";
import { UsuarioServico } from "../servicos/usuario/usuario.servico";
import { CarroServico } from "../servicos/carro/carro.servico";
import { Categoria } from "../model/categoria";

@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html',
  styleUrls: ['./carro.component.css']
})

export class CarroComponent implements OnInit {
  public carro: Carro;
  public ativar_spinner: boolean;
  public cadastrado: boolean;
  public mensagem: string;
  public categorias: Categoria[];

  constructor(private carroServico: CarroServico, private usuarioServico: UsuarioServico) {

  }
  ngOnInit(): void {
    this.carro = new Carro();
    this.obterCategorias();

  }


  public obterCategorias() {
    this.carroServico.obterCategorias().subscribe(
      categoriaJson => {
        var defaultCategoria = new Categoria();
        defaultCategoria.categoria_Id = 9999999;
        defaultCategoria.nomeCategoria = "Selecione uma categoria";
        defaultCategoria.precoBaseDiaria = 0;

        categoriaJson.push(defaultCategoria);
        this.categorias = categoriaJson;
      },
      err => {
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );
  }

  public cadastrar() {
    this.ativar_spinner = true;
    this.carroServico.cadastrar(this.carro).subscribe(
      categoriaJson => {
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
