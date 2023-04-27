import { Parcelado } from "./Parcelado";

export interface Parcela {
  id: number;
  dataPagamento: Date;
  pago: boolean;
  parceladoId: number;
  parcelado: Parcelado;
}
