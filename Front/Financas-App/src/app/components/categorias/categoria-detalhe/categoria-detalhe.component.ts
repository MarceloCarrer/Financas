import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from '@app/models/Categoria';
import { CategoriaService } from '@app/services/categoria.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-categoria-detalhe',
  templateUrl: './categoria-detalhe.component.html',
  styleUrls: ['./categoria-detalhe.component.scss']
})
export class CategoriaDetalheComponent implements OnInit {

  public form!: FormGroup;
  public categoria = {} as Categoria;
  public estadoSalvar: string = 'post';

  constructor(
    private categoriaService: CategoriaService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    ) { this.localeService.use('pt-br'); }

    public carregarCategotia(): void {
      const categotiaIdParam = this.router.snapshot.paramMap.get("id");

      if (categotiaIdParam !== null) {
        this.spinner.show();
        this.estadoSalvar = 'put';
        this.categoriaService.getCategoriaById(+categotiaIdParam).subscribe({
          next: (categotia: Categoria) => {
            this.categoria = { ...categotia};
            this.form.patchValue(this.categoria)
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

    ngOnInit(): void {
      this.carregarCategotia();
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

        this.categoria = (this.estadoSalvar === 'post')
                  ? { ...this.form.value}
                  : {id: this.categoria.id, ...this.form.value}

        this.categoriaService[this.estadoSalvar](this.categoria).subscribe({
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
