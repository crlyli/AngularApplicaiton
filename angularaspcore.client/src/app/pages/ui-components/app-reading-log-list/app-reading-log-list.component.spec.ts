import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppReadingLogListComponent } from './app-reading-log-list.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UicomponentsModule } from '../ui-components.module';
import { BookService } from 'src/app/services/api-service/book-service/book.service';
import { provideAnimations } from '@angular/platform-browser/animations';

describe('AppReadingLogListComponent', () => {
  let component: AppReadingLogListComponent;
  let fixture: ComponentFixture<AppReadingLogListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppReadingLogListComponent ],
      imports: [HttpClientTestingModule,  UicomponentsModule ],
      providers: [BookService, provideAnimations()]
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
