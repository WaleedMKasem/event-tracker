import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { Event } from './event.model';
import { EventService } from './event.service';
import { Data } from '@angular/router/src/config';
import { Lookup } from '../lookups/lookup';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../shared/enums/status';
import { Severity } from '../shared/enums/severity';

@Component({
  selector: 'event-timeline',
  templateUrl: 'timeline.component.html'
})

export class EventTimelineComponent implements OnInit {
  constructor(protected _activatedRoute: ActivatedRoute, protected _route: Router, protected _eventService: EventService) {

    this._activatedRoute.params.subscribe(params => {
      this.eventId = params['id'];
    });
  }

  event: Event;
  eventId: string;
  hideSources:any [];
  hideMainSources:boolean;

  ngOnInit() {
    this.getEvent();
    this.hideMainSources=false;
    this.hideSources=[];
  }
  getEvent() {
    if (this.eventId) {
      this._eventService.getEvent(this.eventId)
        .subscribe(event => {
          this.event = event;
          console.log(this.event);
        });
    }
  }
  getStatus(id: number) {
    return Status[id];
  }
  getSeverity(id: number) {
    return Severity[id];
  }
  deleteEventUpdate(eventId: string, update: Event) {
    if (confirm("Are you sure you want to delete this update?")) {
      this._eventService.deleteSubEvent(eventId, this.event.updates.indexOf(update))
        .subscribe(res => {
          var idx = this.event.updates.indexOf(update);
          if (idx !== -1) {
            this.event.updates.splice(idx, 1);
          }
        });
    }
  }
}