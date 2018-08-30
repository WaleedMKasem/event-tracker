import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { Event } from './event.model';
import { EventService } from './event.service';
import { Data } from '@angular/router/src/config';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common'
import { Status } from '../shared/enums/status';


@Component({
    selector: 'close-event',
    templateUrl: 'close.component.html'
})

export class CloseEventComponent implements OnInit {
    constructor(protected _activatedRoute: ActivatedRoute, protected _route: Router, protected _eventService: EventService, protected _datepipe: DatePipe) {

        this._activatedRoute.params.subscribe(params => {
            this.eventId = params['id'];
        });
    }

    event: Event;
    eventId: string;
    closeDate: Date = new Date();
    closeNotes: string;

    closeEvent() {
        if (confirm("Are you sure you want to close this event?")) {
            let latest_date = this._datepipe.transform(this.closeDate, 'yyyy/M/d');
            console.log(latest_date);
            console.log(this.closeNotes);
            this._eventService.closeEvent(this.eventId, latest_date, this.closeNotes)
                .subscribe(res => {
                    this._route.navigate(['/events']);
                });
        }
    }

    ngOnInit(): void {
        this._eventService.getEvent(this.eventId)
            .subscribe(event => {
                console.log(event);
                if (event.details.status === Status.Closed) {
                    this._route.navigate(['/events']);
                }
            });
    }
}
