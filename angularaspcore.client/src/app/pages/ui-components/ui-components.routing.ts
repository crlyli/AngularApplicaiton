import { Routes } from '@angular/router';

// ui
import { AppBadgeComponent } from './badge/badge.component';
import { AppChipsComponent } from './chips/chips.component';
import { AppListsComponent } from './lists/lists.component';
import { AppMenuComponent } from './menu/menu.component';
import { AppTooltipsComponent } from './tooltips/tooltips.component';
import { AppAddBookComponent } from './app-add-book/app-add-book.component';
import { AppBookListComponent } from 'src/app/pages/ui-components/app-book-list/book-list.component';
import { AppUpdateBookComponent } from './app-update-book/app-update-book.component';
import { AppAddReadingLogComponent } from './app-add-reading-log/app-add-reading-log.component';
import { AppReadingLogListComponent } from './app-reading-log-list/app-reading-log-list.component';

export const UiComponentsRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'badge',
        component: AppBadgeComponent,
      },
      {
        path: 'chips',
        component: AppChipsComponent,
      },
      {
        path: 'lists',
        component: AppListsComponent,
      },
      {
        path: 'menu',
        component: AppMenuComponent,
      },
      {
        path: 'tooltips',
        component: AppTooltipsComponent,
      },
      {
        path: 'addbook',
        component: AppAddBookComponent,
      },
      {
        path: 'addreadinglog',
        component: AppAddReadingLogComponent,
      },
      {
        path: 'updatebook',
        component: AppUpdateBookComponent
      },
      {
        path: 'booklist',
        component: AppBookListComponent,
      },
      {
        path: 'addlog',
        component: AppAddReadingLogComponent,
      },
      {
        path: 'readinglog',
        component: AppReadingLogListComponent,
      },
    ],
  },
];
