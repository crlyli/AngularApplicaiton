import { Component, OnDestroy, OnInit } from '@angular/core';
import { ReadingLogDataModel } from 'src/app/model/reading_log.model';
import { ReadingLogService } from 'src/app/services/api-service/reading-log.service';
import { Subscription } from 'rxjs';
import { MatSelectionList } from '@angular/material/list';

@Component({
  selector: 'app-app-reading-log-list',
  templateUrl: './app-reading-log-list.component.html',
  styleUrls: ['./app-reading-log-list.component.scss']
})
export class AppReadingLogListComponent implements OnInit, OnDestroy {
  constructor(private readingLogService: ReadingLogService) {}
  readingLogList: ReadingLogDataModel[];
  ngOnInit(): void {
      this.getReadingLogList();
  }
  private addReadingLogSubscription?: Subscription;   
    
  getReadingLogList(){
    this.addReadingLogSubscription = this.readingLogService.getreadinglogs().subscribe(response =>
      {
        debugger;
        this.readingLogList = response;
      }
    );  
  };
  
  OnDeleteSelected(id:string) {    
    this.addReadingLogSubscription = this.readingLogService.deletereadinglog(id).subscribe(response =>
      {
        this.getReadingLogList()
      })
  };

  onUpdateBook(data:any){

  };


  ngOnDestroy(): void {
    this.addReadingLogSubscription?.unsubscribe();
  };
}