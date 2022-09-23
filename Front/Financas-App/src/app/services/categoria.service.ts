import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Categoria } from '../models/Categoria';

@Injectable()

export class CategoriaService {

  baseURL = 'https://localhost:5001/api/categoria'

  constructor(private http: HttpClient) { }

  public getCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.baseURL).pipe(take(1));
  }

  public getCategoriasByNome(nome: string): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${this.baseURL}/nome/${nome}`).pipe(take(1));
  }

  public getCategoriaById(id: number): Observable<Categoria> {
    return this.http.get<Categoria>(`${this.baseURL}/id/${id}`).pipe(take(1));
  }

  public post(categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this.baseURL, categoria).pipe(take(1));
  }

  public put(categoria: Categoria): Observable<Categoria> {
    return this.http.put<Categoria>(`${this.baseURL}/${categoria.id}`, categoria).pipe(take(1));
  }

  public deleteCategoria(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }

}
