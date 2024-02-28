import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppUpdateBookComponent } from './app-update-book.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UicomponentsModule } from '../ui-components.module';
import { BookService } from 'src/app/services/api-service/book-service/book.service';

describe('AppUpdateBookComponent', () => {
  let component: AppUpdateBookComponent;
  let fixture: ComponentFixture<AppUpdateBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppUpdateBookComponent ],
      imports: [HttpClientTestingModule,  UicomponentsModule ],
      providers: [BookService, provideAnimations()]
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
