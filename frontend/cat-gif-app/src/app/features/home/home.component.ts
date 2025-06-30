import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CatFact } from 'src/app/core/models/cat-fact';
import { CatFactService } from 'src/app/core/services/cat-fact.service';
import { GiphyService } from 'src/app/core/services/giphy.service';
import { HistoryService } from 'src/app/core/services/history.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @Output() recargarPadre = new EventEmitter<boolean>();
  fact: CatFact | null = null;
  loading: boolean = true;
  isrecargarFact: boolean = false;
  offset: number = 1;

  constructor(
    private catFactService: CatFactService,
    private historyService: HistoryService,
    private giphyService: GiphyService
  ) { }

  ngOnInit(): void {
    this.getFactAndGif();
  }

  getFactAndGif(): void {
    this.loading = true;
    this.catFactService.getFactWithGif().subscribe({
      next: (data) => {
        this.fact = data;
        this.loading = false;
        this.recargarPadre.emit(false);
      },
      error: (err) => {
        console.error('Error al obtener el cat fact:', err);
        this.loading = false;
        this.isrecargarFact = true;
      }
    });
  }

  recargarFact(){
    this.getFactAndGif();
    this.isrecargarFact = false;
  }

  refreshGif(): void {
    if (!this.fact?.query) return;
    this.loading = true;
    this.fact.offset = this.fact.offset + this.offset;
    this.giphyService.getGifByQuery(this.fact).subscribe({
      next: (gifUrl) => {
        if (this.fact) {
          this.fact.gifUrl = gifUrl;
          this.recargarPadre.emit(false);
          this.loading = false;
        }
      },
      error: (err) => {
        this.recargarPadre.emit(true);
        console.error('Error al refrescar el gif:', err);
      }
    });
  }
}
