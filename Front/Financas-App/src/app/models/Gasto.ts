import { Categoria } from "./Categoria";

export interface Gasto {
  id: number;
  local: string;
  valor: number;
  dataCompra: Date;
  categoriaId: number;
  categorias: Categoria;
  outro?: string;
}
