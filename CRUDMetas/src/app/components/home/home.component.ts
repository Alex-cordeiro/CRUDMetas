import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  constructor() { }

  public habilitaFormulario: boolean = false;

  ngOnInit(): void {
  }

  public mostraFormulario(){
    this.habilitaFormulario = !this.habilitaFormulario;
    console.log(this.habilitaFormulario);
  }

}
