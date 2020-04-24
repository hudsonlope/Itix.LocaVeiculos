import { Injectable, Inject, inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { observable, Observable } from "rxjs";
import { Carro } from "../../model/carro";
import { carroLocado } from "../../model/carroLocado";
import { CarroServico } from "../carro/carro.servico";


@Injectable({
  providedIn: "root"
})


export class HomeServico implements OnInit {

  private _baseUrl: string;
  public carroLocado: carroLocado[];
  public categorias: Carro[];

  constructor(private http: HttpClient, private carroServico: CarroServico, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl
  }

  ngOnInit(): void {
    this.carroLocado = [];
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }


  public cadastrar(carroLocado: carroLocado): Observable<carroLocado> {
    return this.http.post<carroLocado>(this._baseUrl + "api/carroLocado", JSON.stringify(carroLocado), { headers: this.headers });
  }

  public salvar(carroLocado: carroLocado): Observable<carroLocado> {
    return this.http.post<carroLocado>(this._baseUrl + "api/carroLocado/salvar", JSON.stringify(carroLocado), { headers: this.headers });
  }

  public deletar(carroLocado: carroLocado): Observable<carroLocado> {
    return this.http.post<carroLocado>(this._baseUrl + "api/carroLocado/deletar", JSON.stringify(carroLocado), { headers: this.headers });
  }

  public obterTodosCarros(): Observable<carroLocado[]> {
    return this.http.get<carroLocado[]>(this._baseUrl + "api/carroLocado");
  }

  public obterCarro(carroId: number): Observable<carroLocado> {
    return this.http.get<carroLocado>(this._baseUrl + "api/carroLocado/obter");
  }

  public obterCarros(): Observable<Carro[]> {
    return this.carroServico.obterTodosCarros();
  }
}
