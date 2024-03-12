import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppBookListComponent } from './book-list.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { BookService } from 'src/app/services/api-service/book-service/book.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UicomponentsModule } from '../ui-components.module';
import { of } from 'rxjs';

describe('AppBookListComponent', () => {
  let component: AppBookListComponent;
  let fixture: ComponentFixture<AppBookListComponent>;
  let bookService: BookService;
  let bookServiceSpy: jasmine.Spy;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppBookListComponent ],
      imports: [ HttpClientTestingModule, UicomponentsModule ],
      providers: [ BookService, provideAnimations()]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppBookListComponent);
    component = fixture.componentInstance;

    bookService = TestBed.inject(BookService);
    bookServiceSpy = spyOn(bookService, 'getBooks').and.returnValue(of([
      {
        id:1,
        title:"A book title",
        description :"A book description",
        author: "First Last"
      },
      {
        id:2,
        title:"Book Title Two",
        description :"A book description two ",
        author: "FirstTwo LastTwo"
      }
    ]))

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve books from the books service on init', () => {
    fixture.detectChanges();
    expect(bookServiceSpy).toHaveBeenCalled();
  })
});
