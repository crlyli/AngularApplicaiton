import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './features/book-list/book-list.component';
import { AddBookComponent } from './features/add-book/add-book.component';

const routes: Routes = [
  {
    path: 'admin/books',
    component: BookListComponent
  },
  {
    path: 'admin/books/add',
    component: AddBookComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
