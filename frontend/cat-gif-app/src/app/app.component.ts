import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  showHistory = false;

  ngOnInit(): void {
    this.recargarHistorial(false);
  }

  recargarHistorial(estado: boolean){
    if (estado === false) {
      this.showHistory = false; // Desmonta
      setTimeout(() => {
        this.showHistory = true; // Vuelve a montar
      });
    }
  }
}
