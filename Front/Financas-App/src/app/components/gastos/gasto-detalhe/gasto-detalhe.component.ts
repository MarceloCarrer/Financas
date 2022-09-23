import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from '@app/models/Categoria';
import { Gasto } from '@app/models/Gasto';
import { CategoriaService } from '@app/services/categoria.service';
import { GastoService } from '@app/services/gasto.service';
import { getDate } from 'ngx-bootstrap/chronos/utils/date-getters';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-gasto-detalhe',
  templateUrl: './gasto-detalhe.component.html',
  styleUrls: ['./gasto-detalhe.component.scss']
})
export class GastoDetalheComponent implements OnInit {

  public form!: FormGroup;
  public gasto = {} as Gasto;
  public categorias: Categoria[] = [];
  public estadoSalvar: string = 'post';
  public bsValue = new Date();

  constructor(
    private gastoService: GastoService,
    private categoriaService: CategoriaService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    ){ this.localeService.use('pt-br'); }

  public carregarGasto(): void {
    const gastoIdParam = this.router.snapshot.paramMap.get("id");
    this.getCategorias();
    if (gastoIdParam !== null) {
      this.spinner.show();
      this.estadoSalvar = 'put';
      this.gastoService.getGastoById(+gastoIdParam).subscribe({
        next: (gasto: Gasto) => {
          this.gasto = { ...gasto};
          this.form.patchValue(this.gasto)
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
    this.carregarGasto();
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
      local: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      categoriaId: ['', Validators.required],
      outro: ['',[Validators.minLength(3), Validators.maxLength(50)]],
      dataCompra: ['', Validators.required],
      valor: ['', [Validators.required, Validators.min(0.01), Validators.max(1000000)]],
    });
  }

  public resetForm(): void{
    this.form.reset();
  }

  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {

      this.gasto = (this.estadoSalvar === 'post')
                ? { ...this.form.value}
                : {id: this.gasto.id, ...this.form.value}

      this.gastoService[this.estadoSalvar](this.gasto).subscribe({
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
