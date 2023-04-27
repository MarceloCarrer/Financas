import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Parcela } from '@app/models/Parcela';
import { Parcelado } from '@app/models/Parcelado';
import { ParcelaService } from '@app/services/parcela.service';
import { ParceladoService } from '@app/services/parcelado.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-parcelado-lista',
  templateUrl: './parcelado-lista.component.html',
  styleUrls: ['./parcelado-lista.component.scss']
})
export class ParceladoListaComponent implements OnInit {

  public parcelados: Parcelado[] = [];
  public parceladosFiltradas: Parcelado[] = [];
  public parcelas: Parcela[] = [];
  private _filtroLista: string = '';
  public modalRef?: BsModalRef;
  public parceladoId: number = 0;
  public nome: string = '';
  public valor: number = 0;
  public valorParcela: number = 0;

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.parceladosFiltradas = this.filtroLista ? this.filtrarParcelados(this.filtroLista) : this.parcelados;
  }

  public filtrarParcelados(filtrarPor: string) : Parcelado[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.parcelados.filter(
      (parcelado: any) => parcelado.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    constructor(
      private parceladoService: ParceladoService,
      private parcelaService: ParcelaService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router,
      ) { }

      public ngOnInit(): void {
        this.spinner.show();
        this.getParcelados();
      }

      public getParcelados(): void {
        const observer = {
          next: (_parcelados: Parcelado[]) => {
            console.log(_parcelados);
            this.parcelados = _parcelados;
            this.parceladosFiltradas = this.parcelados;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar dados.','Falha!');
            console.log(error)
          },
          complete: () => this.spinner.hide()
        };
        this.parceladoService.getParcelados().subscribe(observer);
      }

      public getParcelas(parceladoId: number): void {
        const observer = {
          next: (_parcelas: Parcela[]) => {

            console.log(_parcelas);
            this.parcelas = _parcelas;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar dados.','Falha!');
            console.log(error)
          },
          complete: () => this.spinner.hide()
        };
        this.parcelaService.getParcelasByParceladoId(parceladoId).subscribe(observer);
      }

      public openModal(event: any, template: TemplateRef<any>, parceladoId: number, nome: string, valor: number) : void{
        event.stopPropagation();
        this.parceladoId = parceladoId;
        this.nome = nome;
        this.valor = valor;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      public openParcela(event: any, templateParcela: TemplateRef<any>, parceladoId: number, nome: string, valor: number, qtdParcela: number) : void{
        event.stopPropagation();
        this.parceladoId = parceladoId;
        this.nome = nome;
        this.valor = valor;
        this.valorParcela = valor / qtdParcela;
        this.modalRef = this.modalService.show(templateParcela, {class: 'modal-xl'});
        this.getParcelas(this.parceladoId);
      }

      public confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();
        this.parceladoService.deleteParcelado(this.parceladoId).subscribe({
          next: (resultado: any) => {
            console.log(resultado);
            this.toastr.success('Registro deletado.', 'Sucesso!');
            this.spinner.hide();
            this.getParcelados();
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

      public detalheParcelado(id: number): void {
        this.router.navigate([`parcelado/detalhe/${id}`]);
      }

    }
