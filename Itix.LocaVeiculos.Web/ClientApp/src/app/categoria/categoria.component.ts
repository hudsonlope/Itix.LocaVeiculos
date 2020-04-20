import { Component } from "@angular/core"

@Component({
  selector: "app-categoria",
  template: "{{ obterNome() }}"
})

export class CategoriaComponent {
  public nomeCategoria: string;
  public precoBaseDiaria: number;

  public obterNome(): string {
    return "CAT 100";
  }
}
