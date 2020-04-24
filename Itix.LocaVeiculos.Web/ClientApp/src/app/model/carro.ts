import { Categoria } from "./categoria";

export class Carro {
  carro_Id: number;
  ativo: boolean;
  marca: string;
  modelo: string;
  ano: string;
  cor: string;
  chassi: string;
  dtCadastro: Date;
  possuiArCondicionado: boolean;
  possuiDirecaoHidraulica: boolean;
  categoria_id: string;
  categoria: Categoria;
}
