import { Gasto } from "./Gasto";
import { Parcelado } from "./Parcelado";

export interface Estabelecimento {

  id: number;
  nome: string;
  endereco: string;
  numero: number;
  bairro: string;
  cep: number;
  cidade: string;
  uF: string;
  foto: string;
  dataCadastro: Date;
  observacao: string;
  gastos: Gasto[];
  parcelados: Parcelado[];
}
