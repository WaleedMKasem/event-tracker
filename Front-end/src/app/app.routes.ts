import { AppComponent } from './app.component';
import { Routes } from '@angular/router';
import { EventListComponent } from './events/event-list.component';

export const AppRoutes: Routes =  [{
  path: '',
  redirectTo: '/events',
  pathMatch: 'full' 
}]
;
