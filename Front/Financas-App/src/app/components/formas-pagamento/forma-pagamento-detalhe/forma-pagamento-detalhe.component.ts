import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FormaPagamento } from '@app/models/FormaPagamento';
import { FormaPagamentoService } from '@app/services/formaPagamento.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-forma-pagamento-detalhe',
  templateUrl: './forma-pagamento-detalhe.component.html',
  styleUrls: ['./forma-pagamento-detalhe.component.scss']
})
export class FormaPagamentoDetalheComponent implements OnInit {

  public form!: FormGroup;
  public formaPagamento = {} as FormaPagamento;
  public estadoSalvar: string = 'post';

  constructor(
    private formaPagamentoService: FormaPagamentoService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    ) { this.localeService.use('pt-br'); }

    public carregarFormaPagamento(): void {
      const formaPagamentoIdParam = this.router.snapshot.paramMap.get("id");

      if (formaPagamentoIdParam !== null) {
        this.spinner.show();
        this.estadoSalvar = 'put';
        this.formaPagamentoService.getFormaPagamentoById(+formaPagamentoIdParam).subscribe({
          next: (formaPagamento: FormaPagamento) => {
            this.formaPagamento = { ...formaPagamento};
            this.form.patchValue(this.formaPagamento)
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar dados.','Falha!');
            console.error(error);
          },
          complete: () => this.spinner.hide()
        });
      }
    }

    public ngOnInit(): void {
      this.carregarFormaPagamento();
      this.validation();
    }

    get property (): any {
      return this.form.controls;
    }

    get bsConfig (): any {
      return {
        isAnimated: true,
        dateInputFormat: 'DD/MM/YYYY' ,
        adaptivePosition: true,
        containerClass: "theme-dark-blue",
        showWeekNumbers: false
      }
    }

    public validation(): void {
      this.form = this.fb.group({
        nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
        dataCadastro: ['', Validators.required],
      });
    }

    public resetForm(): void{
      this.form.reset();
    }

    public salvarAlteracao(): void {
      this.spinner.show();
      if (this.form.valid) {

        this.formaPagamento = (this.estadoSalvar === 'post')
                  ? { ...this.form.value}
                  : {id: this.formaPagamento.id, ...this.form.value}

        this.formaPagamentoService[this.estadoSalvar](this.formaPagamento).subscribe({
          next: () => {
            this.toastr.success('Registro salvo.','Sucesso!');
          },
          error: (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar dados.','Falha!');
          },
          complete: () => this.spinner.hide()
        });
      }
    }
}
