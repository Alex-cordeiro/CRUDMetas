import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricoMetasComponent } from './historico-metas.component';

describe('HistoricoMetasComponent', () => {
  let component: HistoricoMetasComponent;
  let fixture: ComponentFixture<HistoricoMetasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricoMetasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricoMetasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
