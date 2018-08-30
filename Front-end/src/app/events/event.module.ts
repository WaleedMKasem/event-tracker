
import { EventListComponent } from './event-list.component';
import { EventService } from './event.service';
import { RouterModule } from '@angular/router';
import { EventRoutes } from './event.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SingleEventComponent } from './single.component';
import { EventTimelineComponent } from './timeline.component';
import { EventDetailsComponent } from './details.component';
import { CloseEventComponent } from './close.component';
import { FormGroupService } from '../shared/form-groups.service';
import { CountryService } from '../lookups/country.service';
import { StateService } from '../lookups/state.service';
import { CityService } from '../lookups/city.service';
import { DatePipe } from '@angular/common';
import { AffectedService } from '../locations/affected.service';
import { DisasterService } from '../lookups/disaster.service';
import { MyDateInput } from './date-Input .component';
import { MyDatePickerModule } from 'mydatepicker';
import { MapComponent } from './map.component';
import { SafePipe } from '../shared/safe.pipe';
import { SharedModule } from '../shared/shared.module';
import { AgmCoreModule } from '@agm/core';
import { ImporterComponent } from './importer.component'
import { FileService } from '../shared/file.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPaginationModule, MyDatePickerModule, SharedModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCeQxr2zcO6t1B5JhdmktakNO7zZbU-vV0'
    }),
    RouterModule.forChild(EventRoutes)
  ],
  declarations: [EventListComponent, MyDateInput, MapComponent, CloseEventComponent,
    SingleEventComponent, EventTimelineComponent, EventDetailsComponent, ImporterComponent],
  providers: [EventService, FormGroupService, CountryService, DatePipe,
    StateService, CityService, AffectedService, DisasterService, FileService
  ]
})
export class EventModule { }
