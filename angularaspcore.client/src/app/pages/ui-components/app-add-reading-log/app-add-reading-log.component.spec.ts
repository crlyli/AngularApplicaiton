import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppAddReadingLogComponent } from './app-add-reading-log.component';
import { ReadingLogService } from 'src/app/services/api-service/reading-log-service/reading-log.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UicomponentsModule } from '../ui-components.module';
import { provideAnimations } from '@angular/platform-browser/animations';

describe('AppAddReadingLogComponent', () => {
  let component: AppAddReadingLogComponent;
  let fixture: ComponentFixture<AppAddReadingLogComponent>;
  let service: ReadingLogService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppAddReadingLogComponent ],
      imports: [ HttpClientTestingModule, UicomponentsModule],
      providers: [ ReadingLogService, provideAnimations() ]
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
