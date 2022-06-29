import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatorioServicosComponent } from './relatorio-servicos.component';

describe('RelatorioServicosComponent', () => {
  let component: RelatorioServicosComponent;
  let fixture: ComponentFixture<RelatorioServicosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RelatorioServicosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RelatorioServicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
