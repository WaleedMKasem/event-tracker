import { Injectable } from '@angular/core';
import { ApiRepository } from '../shared/api-repository';
import { HttpClient } from '@angular/common/http';
import { HelperService } from '../shared/helper.service';
import { Observable } from 'rxjs/Observable';
import { EventCategory } from './event-Category';

@Injectable()
export class EventCategoryService  extends ApiRepository<EventCategory> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
      super('EventCategory/', _httpClient);
    }
    getEventCategories(): Observable<EventCategory[]> {
      return this.list()
        .catch(this._helperService.handleError);
    }
}