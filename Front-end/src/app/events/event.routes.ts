
import { EventListComponent } from './event-list.component';
import { Routes } from '@angular/router';
import { SingleEventComponent } from './single.component';
import { EventTimelineComponent } from './timeline.component';
import { CloseEventComponent } from './close.component';
import { EventDetailsComponent } from './details.component';
import { MapComponent } from './map.component';
import { ImporterComponent } from './importer.component'

// import { EventComponent } from './event.component';

export const EventRoutes: Routes = [{
    path: 'events',
    children: [
        { path: '', component: EventListComponent },
        { path: 'single', component: SingleEventComponent },
        { path: 'single/:id', component: SingleEventComponent },
        { path: 'single/:id/:isUpdate', component: SingleEventComponent },
        { path: 'single/:id/:isUpdate/:subIndex', component: SingleEventComponent },
        { path: 'details/:id', component: EventDetailsComponent },
        { path: 'details/:id/:subIndex', component: EventDetailsComponent },
        { path: 'timeline/:id', component: EventTimelineComponent },
        { path: 'close/:id', component: CloseEventComponent },
        { path: 'map/:long/:lat', component: MapComponent },
        { path: 'importer', component: ImporterComponent }
    ]
}];

