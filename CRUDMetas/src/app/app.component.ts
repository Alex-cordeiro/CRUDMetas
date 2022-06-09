import { Component } from '@angular/core';
import { TipoMeta } from './model/tipo-meta.model';
import { OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  constructor(){}

  ngOnInit(): void
  {
  }
  title = 'Metas';

}
