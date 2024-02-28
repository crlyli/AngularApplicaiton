import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppBookListComponent } from './book-list.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { BookService } from 'src/app/services/api-service/book-service/book.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UicomponentsModule } from '../ui-components.module';

describe('AppBookListComponent', () => {
  let component: AppBookListComponent;
  let fixture: ComponentFixture<AppBookListComponent>;
  let service: BookService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppBookListComponent ],
      imports: [ HttpClientTestingModule, UicomponentsModule ],
      providers: [ BookService, provideAnimations()]
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
