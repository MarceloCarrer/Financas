import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

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
      usuario: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      senha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      confirmaSenha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
    }, formOptions);
  }

}
