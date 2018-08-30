import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { Event } from './event.model';
import { EventService } from './event.service';
import { Data } from '@angular/router/src/config';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { Status } from '../shared/enums/status';
import { Severity } from '../shared/enums/severity';
import { Effect } from '../shared/enums/effect';
import { DisasterUnit } from '../shared/enums/disaster-unit';
import { AffectedLocationType } from '../shared/enums/affected-locationType';

@Component({
    selector: 'event-details',
    templateUrl: 'details.component.html'
})

export class EventDetailsComponent implements OnInit {
    constructor(protected _activatedRoute: ActivatedRoute, protected _route: Router, protected _eventService: EventService, public datepipe: DatePipe) {

        this._activatedRoute.params.subscribe(params => {
            this.eventId = params['id'];
            this.subIndex = params['subIndex'];
        });
    }

    event: Event;
    subEvent: Event;
    eventId: string;
    subIndex: number;
    companies: any[];
    airports: any[];
    seaports: any[];

    ngOnInit() {
        this.loadEvent();
    }

    loadEvent() {
        if (this.eventId) {
            this._eventService.getEvent(this.eventId)
                .subscribe(event => {
                    console.log(event);
                    this.event = event;
                    this.companies = event.affectedLocations.filter(a => a.type == AffectedLocationType.Company);
                    this.airports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Airport);
                    this.seaports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Seaport);
                    if (this.subIndex) {
                        this._eventService.GetSubEvent(this.eventId, this.subIndex)
                            .subscribe(event => {
                                console.log(event);
                                this.subEvent = event;
                                this.subEvent.id = this.event.id;
                                this.subEvent.code = this.event.code;
                                this.event = this.subEvent;
                                this.companies = event.affectedLocations.filter(a => a.type == AffectedLocationType.Company);
                                this.airports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Airport);
                                this.seaports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Seaport);
                            });
                    }
                });
        }
    }
    getEffect(id: number) {
        return Effect[id];
    }
    getStatus(id: number) {
        return Status[id];
    }
    getSeverity(id: number) {
        return Severity[id];
    }
    getUnit(id: number) {
        return DisasterUnit[id];
    }
    mapDesisters(types:any[]){
        return types.map(e=>e.name).join(', ');
    }
}