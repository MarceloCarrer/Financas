import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Gasto } from '@app/models/Gasto';
import { GastoService } from '@app/services/gasto.service';

@Component({
  selector: 'app-gasto-lista',
  templateUrl: './gasto-lista.component.html',
  styleUrls: ['./gasto-lista.component.scss']
})
export class GastoListaComponent implements OnInit {

  public gastos: Gasto[] = [];
  public gastosFiltradas: Gasto[] = [];
  private _filtroLista: string = '';
  public modalRef?: BsModalRef;
  public gastoId: number = 0;
  public nome: string = '';
  public valor: number = 0;

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.gastosFiltradas = this.filtroLista ? this.filtrarGastos(this.filtroLista) : this.gastos;
  }

  public filtrarGastos(filtrarPor: string) : Gasto[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.gastos.filter(
      (gasto: any) => gasto.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    constructor(
      private gastoSevice: GastoService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router,
      ) { }

      public ngOnInit(): void {
        this.spinner.show();
        this.getGastos();
      }

      public getGastos(): void {
        const observer = {
          next: (_gastos: Gasto[]) => {
            this.gastos = _gastos;
            this.gastosFiltradas = this.gastos;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar dados.','Falha!');
            console.log(error);
          },
          complete: () => this.spinner.hide()
        };
        this.gastoSevice.getGastos().subscribe(observer);
      }

      public openModal(event: any, template: TemplateRef<any>, gastoId: number, nome: string, valor: number) : void{
        event.stopPropagation();
        this.gastoId = gastoId;
        this.nome = nome;
        this.valor = valor;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      public confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();
        this.gastoSevice.deleteGasto(this.gastoId).subscribe({
          next: (resultado: any) => {
            console.log(resultado);
            this.toastr.success('Registro deletado.', 'Sucesso!');
            this.getGastos();
          },
          error: (error: any) => {
            this.toastr.error('Erro ao excluir dados.','Falha!');
            console.log(error);
          }
        }).add(() => this.spinner.hide());
      }

      public decline(): void {
        this.modalRef?.hide();
      }

      public detalheGasto(id: number): void {
        this.router.navigate([`gasto/detalhe/${id}`]);
      }

    }
