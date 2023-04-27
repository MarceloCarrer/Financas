import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Categoria } from '@app/models/Categoria';
import { Parcela } from '@app/models/Parcela';
import { Parcelado } from '@app/models/Parcelado';
import { CategoriaService } from '@app/services/categoria.service';
import { ParcelaService } from '@app/services/parcela.service';
import { ParceladoService } from '@app/services/parcelado.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef } from 'ngx-bootstrap/modal';
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
  //public parcelas: Parcela[] = [];
  public dataVenc: Date;
  public numeroParc: number = 0;
  public valorParcela: number = 0;
  public categorias: Categoria[] = [];
  public estadoSalvar: string = 'post';
  public modalRef?: BsModalRef;
  public parceladoId: number = 0;
  public nome: string = '';
  public valor: number = 0;
  public leitura: boolean = false;
  public geraParcela: boolean = false;

  constructor(
    private parceladoService: ParceladoService,
    private categoriaService: CategoriaService,
    private parcelaService: ParcelaService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private activeRouter: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    ){ this.localeService.use('pt-br'); }

    public carregarParcelado(): void {
      this.parceladoId = +this.activeRouter.snapshot.paramMap.get("id");
      this.getCategorias();
      this.leitura = false;
      if (this.parceladoId !== null && this.parceladoId !== 0 ) {
        this.spinner.show();
        this.estadoSalvar = 'put';
        this.leitura = true;
        this.geraParcela = true;
        this.carregarParcelas();
        this.parceladoService.getParceladoById(this.parceladoId).subscribe({
          next: (parcelado: Parcelado) => {
            this.parcelado = { ...parcelado};
            this.form.patchValue(this.parcelado);

            // for (let index = 0; index < this.parcelado.qtdParcela; index++) {
            //   this.numeroParc = index + 1;
            //   this.valorParcela = (this.parcelado.valor / this.parcelado.qtdParcela);
            //   this.dataVenc = this.meses(this.parcelado.dataVencimento, index);
            // }

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

    public geraParcelas(): void {
      for (let index = 0; index < this.parcelado.qtdParcela; index++) {
        this.numeroParc = index + 1;
        this.valorParcela = (this.parcelado.valor / this.parcelado.qtdParcela);
        this.dataVenc = this.meses(this.parcelado.dataVencimento, index);
        this.adicionaParcelas();
      }
    }

    public carregarParcelas(): void {
      this.parcelaService.getParcelasByParceladoId(this.parceladoId).subscribe({
        next: (parcelasRetorno: Parcela[]) => {
          parcelasRetorno.forEach(parcela => {
            this.parcelas.push(this.criarParcelas(parcela));
            this.geraParcela = false;
          })
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao carregar Parcelas.','Falha!');
          console.error(error);
        },
        complete: () => this.spinner.hide()
      });
    }

    ngOnInit(): void {
      this.carregarParcelado();
      this.validation();
    }

    get property (): any {
      return this.form.controls;
    }

    get parcelas(): FormArray {
      return this.form.get('parcelas') as FormArray;
    }

    get modoListar(): boolean {
      return this.estadoSalvar == 'put';
    }

    get bsConfig (): any {
      return {
        isAnimated: true,
        dateInputFormat: 'DD/MM/YYYY',
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
        dataVencimento: ['', Validators.required],
        valor: ['', [Validators.required, Validators.min(0.01), Validators.max(1000000)]],
        qtdParcela: ['', [Validators.required, Validators.min(2), Validators.max(1000)]],
        ativo: ['true'],
        parcelas: this.fb.array([]),
      });
    }

    public adicionaParcelas(): void {
      this.parcelas.push(this.criarParcelas({id: 0} as Parcela));
    }

    public criarParcelas(parcela: Parcela): FormGroup {
      return this.fb.group({
        id: [parcela.id],
        numeroParcela: [this.numeroParc],
        valorParcela: [this.valorParcela],
        dataVencimento: [this.dataVenc],
        dataPagamento: [parcela.dataPagamento],
        pago: [parcela.pago]
      });
    }

    public resetForm(): void{
      this.form.reset();
    }

    public salvarParcelado(): void {
      this.spinner.show();
      if (this.form.valid) {
        this.parcelado = (this.estadoSalvar === 'post')
        ? { ...this.form.value}
        : {id: this.parcelado.id, ...this.form.value}
        this.parceladoService[this.estadoSalvar](this.parcelado).subscribe({
          next: (parceladoRetorno: Parcelado) => {
            this.toastr.success('Registro salvo.','Sucesso!');
            this.router.navigate([`parcelado/detalhe/${parceladoRetorno.id}`]);
          },
          error: (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar dados.','Falha!');
          },
          complete: () => {
            this.spinner.hide();
          }
        });
      }
    }

    public meses(d: any, m: any): Date {
      var data = new Date(d);
      var dia = data.getDate();
      var mes = data.getMonth();
      var dataMes = new Date(data.getFullYear(), eval(m+mes), dia);
      return dataMes;
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

    public decline(): void {
      this.modalRef?.hide();
    }

    public salvarParcelas(): void {
      this.spinner.show();
      this.parcelaService.saveParcelas(this.parceladoId, this.form.value.parcelas).subscribe({
        next: () => {
          this.toastr.success('Registro salvo.','Sucesso!');
          //this.parcelas.reset();
        },
        error: (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Erro ao salvar Parcelas.','Falha!');
        },
        complete:() => this.spinner.hide()
      });
    }

  }
