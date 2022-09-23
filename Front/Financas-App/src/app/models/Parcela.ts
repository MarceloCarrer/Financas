import { Parcelado } from "./Parcelado";

export interface Parcela {
  id: number;
  valoParcela: number;
  numeroParcela: number;
  pago: boolean;
  parceladoId: number;
  parcelado: Parcelado;
}
