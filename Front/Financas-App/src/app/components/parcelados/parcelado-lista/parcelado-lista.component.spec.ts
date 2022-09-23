import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParceladoListaComponent } from './parcelado-lista.component';

describe('ParceladoListaComponent', () => {
  let component: ParceladoListaComponent;
  let fixture: ComponentFixture<ParceladoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParceladoListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParceladoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
