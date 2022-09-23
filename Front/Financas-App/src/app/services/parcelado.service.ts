import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parcelado } from '@app/models/Parcelado';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ParceladoService {

  baseURL = 'https://localhost:5001/api/parcelado'

  constructor(private http: HttpClient) { }

  public getParcelados(): Observable<Parcelado[]> {
    return this.http.get<Parcelado[]>(this.baseURL).pipe(take(1));
  }

  public getParceladoById(id: number): Observable<Parcelado> {
    return this.http.get<Parcelado>(`${this.baseURL}/id/${id}`).pipe(take(1));
  }

  public getParceladosByNome(nome: string): Observable<Parcelado[]> {
    return this.http.get<Parcelado[]>(`${this.baseURL}/nome/${nome}`).pipe(take(1));
  }

  public getParceladosByMes(mes: number, ano: number): Observable<Parcelado[]> {
    return this.http.get<Parcelado[]>(`${this.baseURL}/mes/${mes}/ano/${ano}`).pipe(take(1));
  }

  public getParceladosByAno(ano: number): Observable<Parcelado[]> {
    return this.http.get<Parcelado[]>(`${this.baseURL}/ano/${ano}`).pipe(take(1));
  }

  public getParceladosByCategoria(categoriaId: number): Observable<Parcelado[]> {
    return this.http.get<Parcelado[]>(`${this.baseURL}/categoria/${categoriaId}`).pipe(take(1));
  }

  public post(parcelado: Parcelado): Observable<Parcelado> {
    return this.http.post<Parcelado>(this.baseURL, parcelado).pipe(take(1));
  }

  public put(parcelado: Parcelado): Observable<Parcelado> {
    return this.http.put<Parcelado>(`${this.baseURL}/${parcelado.id}`, parcelado).pipe(take(1));
  }

  public deleteParcelado(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }

}
