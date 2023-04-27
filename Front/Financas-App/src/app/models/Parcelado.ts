import { Categoria } from "./Categoria";
import { Parcela } from "./Parcela";

export interface Parcelado {
  id: number;
  nome: string;
  valor: number;
  qtdParcela: number;
  dataCompra: Date;
  dataVencimento: Date;
  ativo: boolean;
  categoriaId: number;
  categorias: Categoria;
  parcelas: Parcela[];
  outro?: string;
}
