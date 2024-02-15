import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppReadingLogListComponent } from './app-reading-log-list.component';

describe('AppReadingLogListComponent', () => {
  let component: AppReadingLogListComponent;
  let fixture: ComponentFixture<AppReadingLogListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppReadingLogListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppReadingLogListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
