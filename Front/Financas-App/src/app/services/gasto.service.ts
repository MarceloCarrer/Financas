import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Gasto } from '../models/Gasto';

@Injectable()

export class GastoService {

  baseURL = 'https://localhost:5001/api/gasto'

  constructor(private http: HttpClient) { }

  public getGastos(): Observable<Gasto[]> {
    return this.http.get<Gasto[]>(this.baseURL).pipe(take(1));
  }

  public getGastoById(id: number): Observable<Gasto> {
    return this.http.get<Gasto>(`${this.baseURL}/id/${id}`).pipe(take(1));
  }

  public getGastosByLocal(local: string): Observable<Gasto[]> {
    return this.http.get<Gasto[]>(`${this.baseURL}/local/${local}`).pipe(take(1));
  }

  public getGastosByMes(mes: number, ano: number): Observable<Gasto[]> {
    return this.http.get<Gasto[]>(`${this.baseURL}/mes/${mes}/ano/${ano}`).pipe(take(1));
  }

  public getGastosByAno(ano: number): Observable<Gasto[]> {
    return this.http.get<Gasto[]>(`${this.baseURL}/ano/${ano}`).pipe(take(1));
  }

  public getGastosByCategoria(categoriaId: number): Observable<Gasto[]> {
    return this.http.get<Gasto[]>(`${this.baseURL}/categoria/${categoriaId}`).pipe(take(1));
  }

  public post(gasto: Gasto): Observable<Gasto> {
    return this.http.post<Gasto>(this.baseURL, gasto).pipe(take(1));
  }

  public put(gasto: Gasto): Observable<Gasto> {
    return this.http.put<Gasto>(`${this.baseURL}/${gasto.id}`, gasto).pipe(take(1));
  }

  public deleteGasto(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }

}
