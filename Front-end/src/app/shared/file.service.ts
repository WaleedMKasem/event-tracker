import { Injectable } from '@angular/core';
import { ApiRepository } from './api-repository';
import { HelperService } from './helper.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ImportType } from './enums/import-type';

@Injectable()
export class FileService  extends ApiRepository<Event> {
    constructor(protected _helperService: HelperService, protected _httpClient: HttpClient) {
        super('file/', _httpClient);
    }

    uploadFiles(body: any): Observable<any> {
        return this.customPostWithBody('', null, body)
            .catch(this._helperService.handleError);
    }
    importExcel(importType:ImportType ,body: any): Observable<any> {
        
        const params = new HttpParams()
            .set("type", importType.toString());

        return this.customPostWithBody('PostExcel', params, body)
            .catch(this._helperService.handleError);
    }
}