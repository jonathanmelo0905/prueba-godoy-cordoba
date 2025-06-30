import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HistoryItem } from '../models/history';
import { CatFact } from '../models/cat-fact';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  private apiUrl = environment.apiUrl; // Ajusta el puerto según tu backend

  constructor(private http: HttpClient) {}

  getHistory(): Observable<HistoryItem[]> {
    return this.http.get<HistoryItem[]>(`${this.apiUrl}/history`);
  }

  saveToHistory(data: CatFact): Observable<any> {
    return this.http.post(`${this.apiUrl}/gif`, data);
  }
}
