import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormaPagamento } from '@app/models/FormaPagamento';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FormaPagamentoService {

  baseURL = 'https://localhost:5001/api/formaPagamento'

  constructor(private http: HttpClient) { }

  public getFormaPagamentos(): Observable<FormaPagamento[]> {
    return this.http.get<FormaPagamento[]>(this.baseURL).pipe(take(1));
  }

  public getFormaPagamentosByNome(nome: string): Observable<FormaPagamento[]> {
    return this.http.get<FormaPagamento[]>(`${this.baseURL}/nome/${nome}`).pipe(take(1));
  }

  public getFormaPagamentoById(id: number): Observable<FormaPagamento> {
    return this.http.get<FormaPagamento>(`${this.baseURL}/id/${id}`).pipe(take(1));
  }

  public post(formaPagamento: FormaPagamento): Observable<FormaPagamento> {
    return this.http.post<FormaPagamento>(this.baseURL, formaPagamento).pipe(take(1));
  }

  public put(formaPagamento: FormaPagamento): Observable<FormaPagamento> {
    return this.http.put<FormaPagamento>(`${this.baseURL}/${formaPagamento.id}`, formaPagamento).pipe(take(1));
  }

  public deleteFormaPagamento(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }
}
