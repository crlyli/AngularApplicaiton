import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppAddBookComponent } from './app-add-book.component';
import { BookService } from 'src/app/services/api-service/book-service/book.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Router } from '@angular/router';
import { UicomponentsModule } from '../ui-components.module';
import { provideAnimations } from '@angular/platform-browser/animations';

describe('AppAddBookComponent', () => {
  let component: AppAddBookComponent;
  let fixture: ComponentFixture<AppAddBookComponent>;
  let service: BookService;
  let route: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppAddBookComponent ],
      imports: [HttpClientTestingModule,  UicomponentsModule ],
      providers: [BookService, provideAnimations()]
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
