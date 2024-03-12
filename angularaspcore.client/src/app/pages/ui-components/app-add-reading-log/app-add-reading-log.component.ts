import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ReadingLogDataModel } from 'src/app/model/reading_log.model';
import { ReadingLogService } from 'src/app/services/api-service/reading-log-service/reading-log.service';
import { ReaderDataModel } from 'src/app/model/reader.model';
import { BookDataModel } from 'src/app/model/book.model';
import { ReaderService } from 'src/app/services/api-service/reader-service/reader.service';
import { BookService } from 'src/app/services/api-service/book-service/book.service';
import { DatePipe } from '@angular/common';
import { ReadingLogDtoModel } from 'src/app/model/reading_log_dto.model';

@Component({
  selector: 'app-app-add-reading-log',
  templateUrl: './app-add-reading-log.component.html',
  styleUrls: ['./app-add-reading-log.component.scss'],
  providers: [DatePipe]
})
export class AppAddReadingLogComponent implements OnInit{
  readingLogModel: ReadingLogDataModel;
  readingLogDto: ReadingLogDtoModel;
  readerModel: ReaderDataModel;
  bookModel: BookDataModel;
  bookList: BookDataModel[];
  readerList: ReaderDataModel[];
  dateStart = new Date();
  dateEnd = "";
  dast:string | null;
  dastEnd:string | null;

  constructor(private readingLogService: ReadingLogService, private readerService: ReaderService, private bookService: BookService){

  }
  ngOnInit(): void {
    this.bookModel = {
      id: 0,
      title: '',
      description: '',
      author:''
    };
    this.readerModel = {
      id: 0,
      fullName: ''
    };
    this.readingLogModel = {
      reader:this.readerModel,
      book:this.bookModel,
      reader_id: this.readerModel,
      book_id: this.bookModel,
      reading_start: this.dateStart.toString(),
      reading_end: ""
    }

    this.getReaderList();
    this.getBookList();
  }
  private addReadingLogSubscription : Subscription;
  onFormSubmit()
  {
    this.dast = new DatePipe('en').transform(this.dateStart, 'yyyy/MM/dd');
    this.dastEnd = new DatePipe('en').transform(this.dateEnd, 'yyyy/MM/dd');

    this.readingLogModel.reading_start = this.dast?.toString() != null ? this.dast?.toString() : new Date().toString();
    this.readingLogModel.reading_end = this.dastEnd?.toString() != "" ? this.dastEnd?.toString() : "";
    this.readingLogDto = {
      readerId: this.readingLogModel.reader_id,
      bookId: this.readingLogModel.book_id,
      ReadingStart : this.readingLogModel.reading_start,
      ReadingEnd: this.readingLogModel.reading_end
    }
    this.addReadingLogSubscription = this.readingLogService.addreadinglog(this.readingLogDto)
      .subscribe({
        next: (response) => {
          debugger;
          console.log('This was successful!')
        },
        error: (error) => {
          console.log(error.error)
        }
      })
  };
  getReadingLogList(){
    this.addReadingLogSubscription = this.readingLogService.getreadinglog()
    .subscribe(response =>
      {
        this.readingLogModel = response;
      }
    );
  };
  getReaderList(){
    this.addReadingLogSubscription = this.readerService.getReaders().subscribe(response =>
      {
        this.readerList = response;
      })
  };
  getBookList(){
    this.addReadingLogSubscription = this.bookService.getBooks().subscribe(response =>
      {
        this.bookList = response;
      })
  };
  fetchSelectedDate()
  {

  }
  ngOnDestroy(): void {
    this.addReadingLogSubscription?.unsubscribe();
  };
}
