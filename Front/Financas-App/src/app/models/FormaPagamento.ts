import { Gasto } from "./Gasto";
import { Parcelado } from "./Parcelado";

export interface FormaPagamento {

  id: number;
  nome: string;
  dataCadastro: Date;
  gastos: Gasto[];
  parcelados: Parcelado[];
}
