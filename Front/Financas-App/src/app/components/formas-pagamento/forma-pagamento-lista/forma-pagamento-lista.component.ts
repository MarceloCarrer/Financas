import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormaPagamento } from '@app/models/FormaPagamento';
import { FormaPagamentoService } from '@app/services/formaPagamento.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-forma-pagamento-lista',
  templateUrl: './forma-pagamento-lista.component.html',
  styleUrls: ['./forma-pagamento-lista.component.scss']
})
export class FormaPagamentoListaComponent implements OnInit {

  public formasPagamento: FormaPagamento[] = [];
  public formasPagamentoFiltradas: FormaPagamento[] = [];
  private _filtroLista: string = '';
  public modalRef?: BsModalRef;
  public formaPagamentoId: number = 0;
  public nome: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.formasPagamentoFiltradas = this.filtroLista ? this.filtrarFormaPagamentos(this.filtroLista) : this.formasPagamento;
  }

  public filtrarFormaPagamentos(filtrarPor: string) : FormaPagamento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.formasPagamento.filter(
      (formaPagamento: any) => formaPagamento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    constructor(
      private formaPagamentoService: FormaPagamentoService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router,
      ) { }

      public ngOnInit(): void {
        this.spinner.show();
        this.getFormaPagamentos();
      }

      public getFormaPagamentos(): void {
        const observer = {
          next: (_formasPagamento: FormaPagamento[]) => {
            this.formasPagamento = _formasPagamento;
            this.formasPagamentoFiltradas = this.formasPagamento;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar dados.','Falha!');
            console.log(error)
          },
          complete: () => this.spinner.hide()
        };
        this.formaPagamentoService.getFormaPagamentos().subscribe(observer);
      }

      public openModal(event: any, template: TemplateRef<any>, formaPagamentoId: number, nome: string) : void{
        event.stopPropagation();
        this.formaPagamentoId = formaPagamentoId;
        this.nome = nome;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      public confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();
        this.formaPagamentoService.deleteFormaPagamento(this.formaPagamentoId).subscribe({
          next: (resultado: any) => {
            console.log(resultado);
            this.toastr.success('Registro deletado.', 'Sucesso!');
            this.spinner.hide();
            this.getFormaPagamentos();
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao excluir dados.','Falha!');
            console.log(error);
          },
          complete: () => this.spinner.hide()
        });
      }

      public decline(): void {
        this.modalRef?.hide();
      }

      public detalheFormaPagamento(id: number): void {
        this.router.navigate([`formaPagamento/detalhe/${id}`]);
      }

    }
