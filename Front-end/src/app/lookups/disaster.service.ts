import { Injectable } from '@angular/core';
import { ApiRepository } from '../shared/api-repository';
import { HttpClient } from '@angular/common/http';
import { HelperService } from '../shared/helper.service';
import { Observable } from 'rxjs/Observable';
import { Disaster } from './disaster';

@Injectable()
export class DisasterService extends ApiRepository<Disaster> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('Disaster/', _httpClient);
    }
    getDisasters(): Observable<Disaster[]> {
      return this.list()
        .catch(this._helperService.handleError);
    }
}