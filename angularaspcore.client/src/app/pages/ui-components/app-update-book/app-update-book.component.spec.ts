import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppUpdateBookComponent } from './app-update-book.component';

describe('AppUpdateBookComponent', () => {
  let component: AppUpdateBookComponent;
  let fixture: ComponentFixture<AppUpdateBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppUpdateBookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppUpdateBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
