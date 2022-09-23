import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GastoDetalheComponent } from './gasto-detalhe.component';

describe('GastoDetalheComponent', () => {
  let component: GastoDetalheComponent;
  let fixture: ComponentFixture<GastoDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GastoDetalheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GastoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
