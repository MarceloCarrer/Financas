import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Estabelecimento } from '@app/models/Estabelecimento';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EstabelecimentoService {

  baseURL = 'https://localhost:5001/api/estabelecimento'

  constructor(private http: HttpClient) { }

  public getEstabelecimentos(): Observable<Estabelecimento[]> {
    return this.http.get<Estabelecimento[]>(this.baseURL).pipe(take(1));
  }

  public getEstabelecimentosByNome(nome: string): Observable<Estabelecimento[]> {
    return this.http.get<Estabelecimento[]>(`${this.baseURL}/nome/${nome}`).pipe(take(1));
  }

  public getEstabelecimentoById(id: number): Observable<Estabelecimento> {
    return this.http.get<Estabelecimento>(`${this.baseURL}/id/${id}`).pipe(take(1));
  }

  public post(estabelecimento: Estabelecimento): Observable<Estabelecimento> {
    return this.http.post<Estabelecimento>(this.baseURL, estabelecimento).pipe(take(1));
  }

  public put(estabelecimento: Estabelecimento): Observable<Estabelecimento> {
    return this.http.put<Estabelecimento>(`${this.baseURL}/${estabelecimento.id}`, estabelecimento).pipe(take(1));
  }

  public deleteEstabelecimento(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }

}
