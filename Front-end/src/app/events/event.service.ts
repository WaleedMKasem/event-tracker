import { HttpClient } from '@angular/common/http';
import { HelperService } from './../shared/helper.service';
import { Event } from './event.model';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/delay';

import { Injectable } from '@angular/core';
import { Http, Headers, Request, RequestMethod, Response } from '@angular/http';
import { HttpParams } from '@angular/common/http';
import { ApiRepository } from '../shared/api-repository';
import { ItemsWithTotal } from '../shared/items-with-total.model';

@Injectable()
export class EventService extends ApiRepository<Event> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('event/', _httpClient);
    }

    getEvent(eventId: string): Observable<Event> {
        return this.read(eventId)
            .catch(this._helperService.handleError);
    }

    getEvents(): Observable<Event[]> {
        return this.list()
            .catch(this._helperService.handleError);
    }

    getEventsBySpec(title: string, startedOn: Date, endedOn: Date): Observable<Event[]> {
        const params = new HttpParams()
            .set("title", title)
            .set("startedOn", null)
            .set("endedOn", null);

        return this.query('GetBySpec', params)
            .catch(this._helperService.handleError);
    }
    GetSubEvent(eventId: string, index: number): Observable<Event> {
        const params = new HttpParams()
            .set("id", eventId)
            .set("index", index.toString());

        return this.query('GetSubEvent', params)
            .catch(this._helperService.handleError);
    }
    addSubEvent(eventId: string, subEvent: any): Observable<any> {
        const params = new HttpParams()
            .set("id", eventId);

        return this.customPost('AddSubEvent', params, subEvent)
            .catch(this._helperService.handleError);
    }
    updateSubEvent(eventId: string, index: number, subEvent: any): Observable<any> {
        const params = new HttpParams()
            .set("id", eventId)
            .set("index", index.toString());

        return this.customPut('UpdateSubEvent', params, subEvent)
            .catch(this._helperService.handleError);
    }
    deleteSubEvent(eventId: string, index: number): Observable<any> {
        const params = new HttpParams()
            .set("id", eventId)
            .set("index", index.toString());

        return this.customDelete('DeleteSubEvent', params)
            .catch(this._helperService.handleError);
    }
    getPagedEvents(pageIndex: number, pageSize: number,
        countryId?: number, stateId?: number, cityId?: number,
        categoryId?: number, typeId?: number,
        severityId?: number, statusId?: number, alert?: boolean,
        dateFrom?: Date, dateTo?: Date
    ): Observable<ItemsWithTotal<Event>> {
        const params = new HttpParams()
            .set("pageIndex", pageIndex.toString())
            .set("pageSize", pageSize.toString())
            .set("countryId", (countryId != null && countryId != 0) ? countryId.toString() : "")
            .set("stateId", stateId != null && stateId != 0 ? stateId.toString() : "")
            .set("cityId", cityId != null && cityId != 0 ? cityId.toString() : "")
            .set("categoryId", categoryId != null && categoryId != 0 ? categoryId.toString() : "")
            .set("typeId", typeId != null && typeId != 0 ? typeId.toString() : "")
            .set("severity", severityId != null && severityId != -1 ? severityId.toString() : "")
            .set("status", statusId != null && statusId != -1 ? statusId.toString() : "")
            .set("isAlert", alert != null  ? alert.toString() : null)
            .set("dateFrom", dateFrom != null ? dateFrom.toString() : "")
            .set("dateTo", dateTo != null ? dateTo.toString() : "");

        return this.queryWithTotal('getPagedEvents', params)
            .catch(this._helperService.handleError);
        // .delay(1000);
    }

    addEvent(event: Event): Observable<any> {
        return this.create(event)
            .catch(this._helperService.handleError);
    }

    updateEvent(event: Event): Observable<any> {
        return this.update(event.id, event)
            .catch(this._helperService.handleError);
    }

    deleteEvent(eventId: any): Observable<any> {
        return this.delete(eventId)
            .catch(this._helperService.handleError);
    }
    closeEvent(eventId: any, closeDate: string, closeNotes: string): Observable<any> {
        const params = new HttpParams()
            .set("id", eventId)
            .set("closeDate", closeDate)
            .set("closeNotes", closeNotes);

        return this.query('CloseEvent', params)
            .catch(this._helperService.handleError);
    }

}
