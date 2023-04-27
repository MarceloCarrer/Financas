import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormaPagamentoListaComponent } from './forma-pagamento-lista.component';

describe('FormaPagamentoListaComponent', () => {
  let component: FormaPagamentoListaComponent;
  let fixture: ComponentFixture<FormaPagamentoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormaPagamentoListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormaPagamentoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
