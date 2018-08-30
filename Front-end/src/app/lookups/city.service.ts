import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams } from '@angular/common/http';
import { City } from '../lookups/city';
import { ApiRepository } from '../shared/api-repository';
import { HelperService } from '../shared/helper.service';

@Injectable()
export class CityService extends ApiRepository<City> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('City/', _httpClient);
    }
    getCities(cityId: number): Observable<City[]> {
        const params = new HttpParams()
            .set("id", cityId.toString())
        return this.query('', params)
            .catch(this._helperService.handleError);
    }
    getEventsCities(stateId: number): Observable<City[]> {
        const params = new HttpParams()
            .set("id", stateId.toString());
        return this.query('getEventsCities', params)
            .catch(this._helperService.handleError);
    }
}