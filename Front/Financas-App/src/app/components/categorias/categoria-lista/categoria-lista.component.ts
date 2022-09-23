import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Categoria } from '@app/models/Categoria';
import { CategoriaService } from '@app/services/categoria.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categoria-lista',
  templateUrl: './categoria-lista.component.html',
  styleUrls: ['./categoria-lista.component.scss']
})
export class CategoriaListaComponent implements OnInit {

  public categorias: Categoria[] = [];
  public categoriasFiltradas: Categoria[] = [];
  private _filtroLista: string = '';
  public modalRef?: BsModalRef;
  public categoriaId: number = 0;
  public nome: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.categoriasFiltradas = this.filtroLista ? this.filtrarCategorias(this.filtroLista) : this.categorias;
  }

  public filtrarCategorias(filtrarPor: string) : Categoria[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.categorias.filter(
      (categoria: any) => categoria.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    constructor(
      private categoriaService: CategoriaService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router,
      ) { }

      public ngOnInit(): void {
        this.spinner.show();
        this.getCategorias();
      }

      public getCategorias(): void {
        const observer = {
          next: (_categorias: Categoria[]) => {
            this.categorias = _categorias;
            this.categoriasFiltradas = this.categorias;
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

      public openModal(event: any, template: TemplateRef<any>, categoriaId: number, nome: string) : void{
        event.stopPropagation();
        this.categoriaId = categoriaId;
        this.nome = nome;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      public confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();
        this.categoriaService.deleteCategoria(this.categoriaId).subscribe({
          next: (resultado: any) => {
            console.log(resultado);
            this.toastr.success('Registro deletado.', 'Sucesso!');
            this.spinner.hide();
            this.getCategorias();
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

      public detalheCategoria(id: number): void {
        this.router.navigate([`categoria/detalhe/${id}`]);
      }

    }
