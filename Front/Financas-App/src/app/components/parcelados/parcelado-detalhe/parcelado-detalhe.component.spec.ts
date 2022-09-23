import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParceladoDetalheComponent } from './parcelado-detalhe.component';

describe('ParceladoDetalheComponent', () => {
  let component: ParceladoDetalheComponent;
  let fixture: ComponentFixture<ParceladoDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParceladoDetalheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParceladoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
