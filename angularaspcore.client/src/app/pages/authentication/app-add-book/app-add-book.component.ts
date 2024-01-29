import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { PostService } from 'src/app/services/api-service/book.service';
import { AddBookRequest } from 'src/app/model/add-book-reqeust.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-app-add-book',
  templateUrl: './app-add-book.component.html',
  styleUrls: ['./app-add-book.component.scss']
})
export class AppAddBookComponent implements OnDestroy{
  model : AddBookRequest;
  private addBookSubscription?: Subscription;
  posts: any[];
  constructor(private router: Router, private postService: PostService) {
    this.model =
    {
      id:0,
      title: '',
      description: '',
      author: '',
      rate: 0,
      dateStart: new Date().toDateString(),
      dateFinish : new Date().toDateString()
    }
  }
  
  onFormSubmit()
  { 
    this.addBookSubscription = this.postService.addBook(this.model)
      .subscribe({
        next: (response) => {
          console.log('This was successful!')
        },
        error: (error) => {
        }
      })
  }

  ngOnDestroy(): void {
    this.addBookSubscription?.unsubscribe();
  }
}
