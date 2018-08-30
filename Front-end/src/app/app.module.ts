import { HttpClient } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule, RequestOptions } from '@angular/http';
import { HttpClientModule } from "@angular/common/http";
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EventModule } from './events/event.module';
import { EventListComponent } from './events/event-list.component';
import { EventService } from './events/event.service';
import { EventCategoryService } from './lookups/event-category.service';
import { SafePipe } from './shared/safe.pipe';
import { AgmCoreModule } from '@agm/core';



@NgModule({
  declarations: [
    AppComponent
    // ,EventListComponent
  ],
  imports: [
    HttpModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BrowserModule,
    SharedModule,
    EventModule,
    RouterModule.forRoot(AppRoutes, {useHash: true}),
  ],
  providers: [EventCategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
