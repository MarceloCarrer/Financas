import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo = {} as string;
  @Input() rota = {} as string;
  @Input() subtitulo = {} as string;
  @Input() subRota = {} as string;
  @Input() iconClass = 'fa fa-chart-bar';
  @Input() botaoListar = false;


  constructor(private router: Router) { }

  public ngOnInit(): void {
  }

  public return(): void {
    this.router.navigate([`/${this.subRota}`])
  }

}
