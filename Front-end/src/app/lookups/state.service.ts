import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams } from '@angular/common/http';
import { State } from '../lookups/state';
import { ApiRepository } from '../shared/api-repository';
import { HelperService } from '../shared/helper.service';

@Injectable()
export class StateService extends ApiRepository<State> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('State/', _httpClient);
    }
    getStates(countryId: number): Observable<State[]> {

        const params = new HttpParams()
            .set("id", countryId.toString());
        return this.query('', params)
            .catch(this._helperService.handleError);
    }
    getEventsStates(countryId: number): Observable<State[]> {
        const params = new HttpParams()
            .set("id", countryId.toString());
        return this.query('getEventsStates', params)
            .catch(this._helperService.handleError);
    }
}