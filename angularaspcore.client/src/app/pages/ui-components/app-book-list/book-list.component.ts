import { Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { PostService } from 'src/app/services/api-service/book.service';
import { Subscription } from 'rxjs';
import { BookDataModel } from 'src/app/model/book.model';
import { MatSelectionList } from '@angular/material/list';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html'
})
export class AppBookListComponent implements OnInit, OnDestroy {
  constructor(private postService: PostService) {}
  bookList: BookDataModel[];
  ngOnInit(): void {
    debugger;
      this.getBookList();
  }
    private addBookSubscription?: Subscription;   
    
    getBookList(){
      this.addBookSubscription = this.postService.getBooks().subscribe(response =>
        {
          this.bookList = response;
        }
      );  
    };
    
    OnDeleteSelected(id:string) {    
      this.addBookSubscription = this.postService.deleteBook(id).subscribe(response =>
        {
          this.getBookList()
        })
    };



    ngOnDestroy(): void {
      this.addBookSubscription?.unsubscribe();
    };
	}