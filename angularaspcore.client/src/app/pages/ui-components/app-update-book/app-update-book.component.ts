import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/api-service/book.service';
import { BookDataModel } from 'src/app/model/book.model';
import { Subscription } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-app-update-book',
  templateUrl: './app-update-book.component.html',
  styleUrls: ['./app-update-book.component.scss'],
})
export class AppUpdateBookComponent implements OnDestroy, OnInit{
  model : BookDataModel;
  private addBookSubscription?: Subscription;
  posts: any[];
  constructor(private postService: BookService, private router: Router) {
    
  }
  ngOnInit(): void {

    this.model =
    {
      id:1,
      title: 'Hell0',
      description: 'Hello',
      author: 'Hello',
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
