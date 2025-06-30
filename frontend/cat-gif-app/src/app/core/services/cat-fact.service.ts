import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { CatFact } from '../models/cat-fact';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CatFactService {

  private apiUrl = environment.apiUrl; // Ajusta el puerto según tu backend

  constructor(private http: HttpClient) { }

  getFactWithGif(): Observable<CatFact> {
    return this.http.get<CatFact>(`${this.apiUrl}/Fact`);
  }

}
