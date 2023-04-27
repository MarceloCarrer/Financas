import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parcela } from '@app/models/Parcela';
import { Observable, take } from 'rxjs';

@Injectable()

export class ParcelaService {

  baseURL = 'https://localhost:5001/api/parcela'

  constructor(private http: HttpClient) { }

  public getParcelasByParceladoId(parceladoId: number): Observable<Parcela[]> {
    return this.http.get<Parcela[]>(`${this.baseURL}/parceladoId/${parceladoId}`).pipe(take(1));
  }

  public saveParcelas(parceladoId: number, parcelas: Parcela[]): Observable<Parcela[]> {
    return this.http.put<Parcela[]>(`${this.baseURL}/${parceladoId}`, parcelas).pipe(take(1));
  }

  public deleteParcela(parceladoId: number, parcelaId: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${parceladoId}/${parcelaId}`).pipe(take(1));
  }

}
