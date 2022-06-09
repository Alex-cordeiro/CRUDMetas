import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioPecasServicosComponent } from './formulario-pecas-servicos.component';

describe('FormularioPecasServicosComponent', () => {
  let component: FormularioPecasServicosComponent;
  let fixture: ComponentFixture<FormularioPecasServicosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioPecasServicosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioPecasServicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
