import { Injectable } from '@angular/core';
import { Gif } from '../models/giphy';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CatFact } from '../models/cat-fact';

@Injectable({
  providedIn: 'root'
})
export class GiphyService {


  private apiUrl = environment.apiUrl; // Ajusta el puerto según tu backend

  constructor(private http: HttpClient) { }

  getGifByQuery(data: CatFact): Observable<string> {
    return this.http.post<Gif>(`${this.apiUrl}/Gif`, data).pipe(
      map(res => res.url)
    );
  }
}
