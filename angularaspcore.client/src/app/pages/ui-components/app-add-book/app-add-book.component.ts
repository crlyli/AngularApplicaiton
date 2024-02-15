import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/api-service/book.service';
import { BookDataModel } from 'src/app/model/book.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-app-add-book',
  templateUrl: './app-add-book.component.html',
  styleUrls: ['./app-add-book.component.scss']
})
export class AppAddBookComponent implements OnDestroy{
  model : BookDataModel;
  private addBookSubscription?: Subscription;
  posts: any[];
  constructor(private postService: BookService, private router: Router) {
    this.model =
    {
      id:0,
      title: '',
      description: '',
      author: ''
    }
  }

  onFormSubmit()
  { 
    this.addBookSubscription = this.postService.addBook(this.model)
      .subscribe({
        next: (response) => {
          console.log('This was successful!')
          this.router.navigate(['/dashboard']);
        },
        error: (error) => {
          console.log(error.error)
        }
      })
  }

  ngOnDestroy(): void {
    this.addBookSubscription?.unsubscribe();
  }
}
