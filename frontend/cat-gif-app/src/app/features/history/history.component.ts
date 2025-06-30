import { Component, OnInit } from '@angular/core';
import { HistoryItem } from 'src/app/core/models/history';
import { HistoryService } from 'src/app/core/services/history.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  loading = false;
  historial: HistoryItem[] = [];
  columns: string[] = ['fecha', 'fact', 'query', 'gif'];

  constructor(private historyService: HistoryService) { }

  ngOnInit(): void {
    this.loading = true
    this.historyService.getHistory().subscribe({
      next: res => {
        this.historial = res;
        this.loading = false;
      },
      error: err => {
        this.loading = false;
      }
    });
  }
}
