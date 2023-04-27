import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstabelecimentoListaComponent } from './estabelecimento-lista.component';

describe('EstabelecimentoListaComponent', () => {
  let component: EstabelecimentoListaComponent;
  let fixture: ComponentFixture<EstabelecimentoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstabelecimentoListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstabelecimentoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
