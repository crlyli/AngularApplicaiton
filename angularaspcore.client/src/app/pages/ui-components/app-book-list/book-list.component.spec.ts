import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppBookListComponent } from './book-list.component';

describe('AppBookListComponent', () => {
  let component: AppBookListComponent;
  let fixture: ComponentFixture<AppBookListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppBookListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppBookListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
