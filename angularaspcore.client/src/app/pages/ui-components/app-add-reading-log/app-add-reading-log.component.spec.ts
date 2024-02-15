import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppAddReadingLogComponent } from './app-add-reading-log.component';

describe('AppAddReadingLogComponent', () => {
  let component: AppAddReadingLogComponent;
  let fixture: ComponentFixture<AppAddReadingLogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppAddReadingLogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppAddReadingLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
