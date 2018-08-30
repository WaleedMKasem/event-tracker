import { ChangeDetectionStrategy, Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HelperService } from '../shared/helper.service';
import { EventService } from './event.service';
import { FormBuilder } from '@angular/forms';
import { Event } from './event.model';
import { Observable } from 'rxjs/Observable';
import { CountryService } from '../lookups/country.service';
import { Country } from '../lookups/country';
import { StateService } from '../lookups/state.service';
import { State } from '../lookups/state';
import { CityService } from '../lookups/city.service';
import { City } from '../lookups/city';
import { EventCategoryService } from '../lookups/event-category.service';
import { EventCategory } from '../lookups/event-Category';
import { Lookup } from '../lookups/lookup';

// import 'rxjs/add/operator/do';
// import 'rxjs/add/operator/filter';
// import 'rxjs/add/operator/finally';

@Component({
    selector: 'event-list',
    templateUrl: './event-list.component.html',
    styleUrls: ['./event-list.component.css']
    // ,changeDetection: ChangeDetectionStrategy.OnPush
})
export class EventListComponent {
    events: Event[];
    currentPage: number = 1;
    total: number;
    pageSize: number = 10;
    loading: boolean;
    countries: Country[];
    states: State[];
    cities: City[];
    categories: EventCategory[];
    eventTypes: Lookup[];
    countryId: number = 0;
    stateId: number = 0;
    cityId: number = 0;
    categoryId: number = 0;
    typeId: number = 0;
    severityId: number = -1;
    statusId: number = -1;
    alert?  : boolean = null;
    fromDate: Date = null;
    toDate: Date = null;

    constructor(protected _eventService: EventService, protected _countryService: CountryService,
        protected _stateService: StateService, protected _cityService: CityService, protected _eventCategoryService: EventCategoryService) {
    }

    ngOnInit() {
        this.getEvents();

        this._countryService.getEventsCountries()
            .subscribe(countries => {
                this.countries = countries;
            });

        this._eventCategoryService.getEventCategories()
            .subscribe(categories => {
                console.log(categories);
                this.categories = categories;
            });
    }

    getEvents(page: number = 1) {
        //this.loading = true;
        this._eventService.getPagedEvents(page, this.pageSize, this.countryId, this.stateId, this.cityId, this.categoryId, this.typeId,
            this.severityId, this.statusId, this.alert, this.fromDate,this.toDate)
            .subscribe(res => {
                this.total = res.total;
                this.events = res.items;
                this.currentPage = page;
                //this.loading = false;
            });
    }
    deleteEvent(event: Event) {
        if (confirm("Are you sure you want to delete event this event?")) {
            this._eventService.deleteEvent(event.id)
                .subscribe(res => {
                    var idx = this.events.indexOf(event);
                    if (idx !== -1) {
                        this.events.splice(idx, 1);
                        this.total = this.total - 1;
                    }
                });
        }
    }
    onSelectCountry(countryId) {
        this._stateService.getEventsStates(countryId)
            .subscribe(p => {
                this.states = p;
            });
        this.countryId = countryId;
        this.stateId = 0;
        this.cityId = 0;
        this.getEvents();
    }

    onSelectState(stateId) {
        this._cityService.getEventsCities(stateId)
            .subscribe(p => {
                this.cities = p;
            });
        this.stateId = stateId;
        this.cityId = 0;
        this.getEvents();
    }
    onSelectCity(cityId) {
        this.cityId = cityId;
        this.getEvents();
    }
    onSelectCategory(categoryId) {
        if (categoryId != 0) {
            this.eventTypes = this.categories.find(p => p.id == categoryId).eventTypes;
        } else {
            this.eventTypes = null;
        }

        this.categoryId = categoryId;
        this.typeId = 0;
        this.getEvents();
    }
    onSelectType(typeId) {
        this.typeId = typeId;
        this.getEvents();
    }
    onSelectSeverity(severityId) {
        this.severityId = severityId;
        this.getEvents();
    }
    onSelectStatus(statusId) {
        this.statusId = statusId;
        this.getEvents();
    }
    onSelectAlert(alert) {
        this.alert = alert;
        this.getEvents();
    }
    clearFilters() {
        this.countryId = 0;
        this.states = [];
        this.stateId = 0;
        this.cities = [];
        this.cityId = 0;
        this.categoryId = 0;
        this.eventTypes = [];
        this.typeId = 0;
        this.severityId = -1;
        this.statusId = -1;
        this.alert = null;
        this.fromDate = null;
        this.toDate = null;
        this.getEvents();
    }
}