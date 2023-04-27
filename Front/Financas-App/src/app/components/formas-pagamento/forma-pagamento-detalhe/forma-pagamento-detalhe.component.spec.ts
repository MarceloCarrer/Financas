import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormaPagamentoDetalheComponent } from './forma-pagamento-detalhe.component';

describe('FormaPagamentoDetalheComponent', () => {
  let component: FormaPagamentoDetalheComponent;
  let fixture: ComponentFixture<FormaPagamentoDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormaPagamentoDetalheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormaPagamentoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
