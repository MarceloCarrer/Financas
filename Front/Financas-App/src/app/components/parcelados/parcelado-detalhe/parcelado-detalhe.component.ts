import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from '@app/models/Categoria';
import { Parcelado } from '@app/models/Parcelado';
import { CategoriaService } from '@app/services/categoria.service';
import { ParceladoService } from '@app/services/parcelado.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-parcelado-detalhe',
  templateUrl: './parcelado-detalhe.component.html',
  styleUrls: ['./parcelado-detalhe.component.scss']
})
export class ParceladoDetalheComponent implements OnInit {

  public form!: FormGroup;
  public parcelado = {} as Parcelado;
  public categorias: Categoria[] = [];
  public estadoSalvar: string = 'post';

  constructor(
    private parceladoService: ParceladoService,
    private categoriaService: CategoriaService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    ){ this.localeService.use('pt-br'); }

    public carregarParcelado(): void {
      const parceladoIdParam = this.router.snapshot.paramMap.get("id");
      this.getCategorias();
      if (parceladoIdParam !== null) {
        this.spinner.show();
        this.estadoSalvar = 'put';
        this.parceladoService.getParceladoById(+parceladoIdParam).subscribe({
          next: (parcelado: Parcelado) => {
            this.parcelado = { ...parcelado};
            this.form.patchValue(this.parcelado)
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
    this.carregarParcelado();
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
      categoriaId: ['', Validators.required],
      outro: ['',[Validators.minLength(3), Validators.maxLength(50)]],
      dataCompra: ['', Validators.required],
      valor: ['', [Validators.required, Validators.min(0.01), Validators.max(1000000)]],
      qtdParcela: ['', [Validators.required, Validators.min(2), Validators.max(1000)]],
      ativo: [''],
    });
  }

  public resetForm(): void{
    this.form.reset();
  }

  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {

      this.parcelado = (this.estadoSalvar === 'post')
                ? { ...this.form.value}
                : {id: this.parcelado.id, ...this.form.value}

      this.parceladoService[this.estadoSalvar](this.parcelado).subscribe({
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

  public getCategorias(): void {
    const observer = {
      next: (_categorias: Categoria[]) => {
        this.categorias = _categorias;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar dados.','Falha!');
        console.log(error)
      },
      complete: () => this.spinner.hide()
    };
    this.categoriaService.getCategorias().subscribe(observer);
  }

}
