import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppAlarmsComponent } from './app-alarms.component';

describe('AppAlarmsComponent', () => {
  let component: AppAlarmsComponent;
  let fixture: ComponentFixture<AppAlarmsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppAlarmsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppAlarmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
