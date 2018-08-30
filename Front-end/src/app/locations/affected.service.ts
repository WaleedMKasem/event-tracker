import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AffectedLocation } from '../events/meta-models/affected-location';
import { ApiRepository } from '../shared/api-repository';
import { HelperService } from '../shared/helper.service';

@Injectable()
export class AffectedService extends ApiRepository<AffectedLocation> {

    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('AffectedLocation/', _httpClient);
    }
    getAffectedLocation(originalLat: number, originalLong: number, originalAffected: number, originalNear: number): Observable<AffectedLocation[]> {

        const params = new HttpParams()
            .set("originalLat", originalLat.toString())
            .set("originalLong", originalLong.toString())
            .set("originalAffected", originalAffected.toString())
            .set("originalNear", originalNear.toString())
        return this.query('GetAffectedLocations', params)
            .catch(this._helperService.handleError);
    }
}