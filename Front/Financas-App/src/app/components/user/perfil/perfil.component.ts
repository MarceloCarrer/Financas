import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  public form!: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  get property (): any {
    return this.form.controls;
  }

  public validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmaSenha')
    };

    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      sobreNome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.minLength(7), Validators.email]],
      telefone: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(11)]],
      descricao: ['', Validators.maxLength(100)],
      funcao: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      confirmaSenha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
    }, formOptions);
  }
}
