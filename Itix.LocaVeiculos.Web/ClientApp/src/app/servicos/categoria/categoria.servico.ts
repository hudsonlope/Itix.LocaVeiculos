import { Injectable, Inject, inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { observable, Observable } from "rxjs";
import { Categoria } from "../../model/categoria";


@Injectable({
  providedIn: "root"
})

export class CategoriaServico implements OnInit {

  private _baseUrl: string;
  public categorias: Categoria[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl
  }

  ngOnInit(): void {
    this.categorias = [];
  }
  
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }


  public cadastrar(categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this._baseUrl + "api/categoria", JSON.stringify(categoria), { headers: this.headers });
  }

  public salvar(categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this._baseUrl + "api/categoria/salvar", JSON.stringify(categoria), { headers: this.headers });
  }

  public deletar(categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this._baseUrl + "api/categoria/deletar", JSON.stringify(categoria), { headers: this.headers });
  }

  public obterTodasCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this._baseUrl + "api/categoria");
  }

  public obterCategoria(categoriaId: number): Observable<Categoria> {
    return this.http.get<Categoria>(this._baseUrl + "api/categoria/obter");
  }
}
