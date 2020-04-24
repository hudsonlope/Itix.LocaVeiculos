import { Injectable, Inject, inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { observable, Observable } from "rxjs";
import { Carro } from "../../model/carro";
import { Categoria } from "../../model/categoria";
import { CategoriaServico } from "../categoria/categoria.servico";


@Injectable({
  providedIn: "root"
})

export class CarroServico implements OnInit {

  private _baseUrl: string;
  public carro: Carro[];
  public categorias: Categoria[];

  constructor(private http: HttpClient, private categoriaServico: CategoriaServico, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl
  }

  ngOnInit(): void {
    this.carro = [];
  }
  
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }


  public cadastrar(carro: Carro): Observable<Carro> {
    return this.http.post<Carro>(this._baseUrl + "api/carro", JSON.stringify(carro), { headers: this.headers });
  }

  public salvar(carro: Carro): Observable<Carro> {
    return this.http.post<Carro>(this._baseUrl + "api/carro/salvar", JSON.stringify(carro), { headers: this.headers });
  }

  public deletar(carro: Carro): Observable<Carro> {
    return this.http.post<Carro>(this._baseUrl + "api/carro/deletar", JSON.stringify(carro), { headers: this.headers });
  }

  public obterTodosCarros(): Observable<Carro[]> {
    return this.http.get<Carro[]>(this._baseUrl + "api/carro");
  }

  public obterCarro(carroId: number): Observable<Carro> {
    return this.http.get<Carro>(this._baseUrl + "api/carro/obter");
  }

  public obterCategorias(): Observable<Categoria[]> {
    return this.categoriaServico.obterTodasCategorias();
  }
}
