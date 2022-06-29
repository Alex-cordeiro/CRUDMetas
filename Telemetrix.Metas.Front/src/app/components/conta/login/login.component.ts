import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioLogin } from 'src/app/model/usuario-login.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, 
    private authService: AuthService,
    private router: Router) { }

  public formLogin!: FormGroup; 
  public usuarioLogin!: UsuarioLogin;
  ngOnInit(): void {
    this.criarFormulario(new UsuarioLogin)
  }

  public criarFormulario(usuarioLogin: UsuarioLogin){
    this.formLogin = this.formBuilder.group({
      userName: new FormControl(usuarioLogin.userName, [Validators.required]),
      senha: new FormControl(usuarioLogin.senha, [Validators.required]),
    })
  }

  async onSubmit(){
    try{
      if(this.formLogin?.valid){
        this.usuarioLogin = {
         userName: this.formLogin.controls['userName'].value,
         senha: this.formLogin.controls['senha'].value
        }
         await this.authService.login(this.usuarioLogin).subscribe((res) => {
          if(res.authenticated){
          }
         })
       }
    }catch(error){
      console.log(error);
    }
  }

  public login(){
    
  }
}
