
import { Observable } from 'rxjs/Observable';

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { ItemsWithTotal } from './items-with-total.model';

export abstract class ApiRepository<T> {

  protected _baseURL = `api/`;

  constructor(protected entityUrl: string, protected _httpClient: HttpClient) { }

  protected read(id: string): Observable<T> {
    return this._httpClient.get<T>(`${this._baseURL}${this.entityUrl}/${id}`);
  }

  protected list(): Observable<T[]> {
    return this.query();
  }

  protected query(action?: string, prams?: HttpParams): Observable<T[]> {
    return this._httpClient
      .get<Array<T>>(`${this._baseURL}${this.entityUrl}${action || ''}`, { params: prams });
  }
  protected customPost(action?: string, prams?: HttpParams, entity?: T): Observable<T[]> {
    return this._httpClient
      .post<Array<T>>(`${this._baseURL}${this.entityUrl}${action || ''}`, entity, { params: prams });
  }
  protected customPostWithBody(action?: string, prams?: HttpParams, body?: any): Observable<any> {
    return this._httpClient
      .post<Array<T>>(`${this._baseURL}${this.entityUrl}${action || ''}`, body, { params: prams });
  }
  protected customPut(action?: string, prams?: HttpParams, entity?: T): Observable<T[]> {
    return this._httpClient
      .put<Array<T>>(`${this._baseURL}${this.entityUrl}${action || ''}`, entity, { params: prams });
  }
  protected queryWithTotal(action?: string, prams?: HttpParams): Observable<ItemsWithTotal<T>> {
    return this._httpClient
      .get<ItemsWithTotal<T>>(`${this._baseURL}${this.entityUrl}${action || ''}`, { params: prams });
  }

  protected create(entity: T): Observable<any> {
    return this._httpClient
      .post(`${this._baseURL}${this.entityUrl}`, entity);
  }

  protected update(id: any, entity: T): Observable<any> {
    return this._httpClient
      .put(`${this._baseURL}${this.entityUrl}/${id}`, entity);
  }

  protected delete(id: any): Observable<any> {
    return this._httpClient
      .delete(`${this._baseURL}${this.entityUrl}/${id}`);
  }
  protected customDelete(action?: string, prams?: HttpParams): any {
    return this._httpClient
      .delete<any>(`${this._baseURL}${this.entityUrl}${action || ''}`, { params: prams });
  }

}

