import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ReadingLogDataModel } from 'src/app/model/reading_log.model';
import { ReadingLogService } from 'src/app/services/api-service/reading-log.service';
import { ReaderDataModel } from 'src/app/model/reader.model';
import { BookDataModel } from 'src/app/model/book.model';
import { ReaderService } from 'src/app/services/api-service/reader.service';
import { BookService } from 'src/app/services/api-service/book.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-app-add-reading-log',
  templateUrl: './app-add-reading-log.component.html',
  styleUrls: ['./app-add-reading-log.component.scss'],
  providers: [DatePipe]
})
export class AppAddReadingLogComponent implements OnInit{
  readingLogModel: ReadingLogDataModel;
  readerModel: ReaderDataModel;
  bookModel: BookDataModel;
  bookList: BookDataModel[];
  readerList: ReaderDataModel[];
  dateStart = new Date();
  dateEnd = null;
  dast:string | null;
  
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
      reading_end: null
    }
    this.getReaderList();
    this.getBookList();
  }
  private addReadingLogSubscription : Subscription;
  onFormSubmit()
  { 
    this.dast = new DatePipe('en').transform(this.dateStart, 'yyyy/MM/dd');
    this.readingLogModel.reading_start = this.dast?.toString() != null ? this.dast?.toString() : new Date().toString();

    this.addReadingLogSubscription = this.readingLogService.addreadinglog(this.readingLogModel)
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
