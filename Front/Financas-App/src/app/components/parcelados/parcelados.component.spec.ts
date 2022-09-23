import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParceladosComponent } from './parcelados.component';

describe('ParceladosComponent', () => {
  let component: ParceladosComponent;
  let fixture: ComponentFixture<ParceladosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParceladosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParceladosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
