import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Estabelecimento } from '@app/models/Estabelecimento';
import { EstabelecimentoService } from '@app/services/estabelecimento.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-estabelecimento-lista',
  templateUrl: './estabelecimento-lista.component.html',
  styleUrls: ['./estabelecimento-lista.component.scss']
})
export class EstabelecimentoListaComponent implements OnInit {

  public estabelecimentos: Estabelecimento[] = [];
  public estabelecimentosFiltradas: Estabelecimento[] = [];
  private _filtroLista: string = '';
  public modalRef?: BsModalRef;
  public estabelecimentoId: number = 0;
  public nome: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.estabelecimentosFiltradas = this.filtroLista ? this.filtrarEstabelecimentos(this.filtroLista) : this.estabelecimentos;
  }

  public filtrarEstabelecimentos(filtrarPor: string) : Estabelecimento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.estabelecimentos.filter(
      (estabelecimento: any) => estabelecimento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    constructor(
      private estabelecimentoService: EstabelecimentoService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router,
      ) { }

      public ngOnInit(): void {
        this.spinner.show();
        this.getEstabelecimentos();
      }

      public getEstabelecimentos(): void {
        const observer = {
          next: (_estabelecimento: Estabelecimento[]) => {
            this.estabelecimentos = _estabelecimento;
            this.estabelecimentosFiltradas = this.estabelecimentos;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar dados.','Falha!');
            console.log(error)
          },
          complete: () => this.spinner.hide()
        };
        this.estabelecimentoService.getEstabelecimentos().subscribe(observer);
      }

      public openModal(event: any, template: TemplateRef<any>, estabelecimentoId: number, nome: string) : void{
        event.stopPropagation();
        this.estabelecimentoId = estabelecimentoId;
        this.nome = nome;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      public confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();
        this.estabelecimentoService.deleteEstabelecimento(this.estabelecimentoId).subscribe({
          next: (resultado: any) => {
            console.log(resultado);
            this.toastr.success('Registro deletado.', 'Sucesso!');
            this.spinner.hide();
            this.getEstabelecimentos();
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

      public detalheEstabelecimento(id: number): void {
        this.router.navigate([`estabelecimento/detalhe/${id}`]);
      }

}
