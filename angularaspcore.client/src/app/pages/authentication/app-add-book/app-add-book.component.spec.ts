import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppAddBookComponent } from './app-add-book.component';

describe('AppAddBookComponent', () => {
  let component: AppAddBookComponent;
  let fixture: ComponentFixture<AppAddBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppAddBookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppAddBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
