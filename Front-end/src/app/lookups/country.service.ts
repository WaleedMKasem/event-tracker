import { Injectable } from '@angular/core';
import { ApiRepository } from '../shared/api-repository';
import { HttpClient } from '@angular/common/http';
import { HelperService } from '../shared/helper.service';
import { Observable } from 'rxjs/Observable';
import { Country } from './country';

@Injectable()
export class CountryService extends ApiRepository<Country> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('Country/', _httpClient);
    }
    getCountries(): Observable<Country[]> {
      return this.list()
        .catch(this._helperService.handleError);
    }
    getEventsCountries(): Observable<Country[]> {
        return this.query('getEventsCountries')
            .catch(this._helperService.handleError);
    }
}