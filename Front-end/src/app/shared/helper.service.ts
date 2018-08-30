import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class HelperService {

  constructor() { }

  handleError(error: Response) {
    return Observable.throw(error.json() || 'Server error');
  }
  // toDate(record: any): any {
  //   const dateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/;
  //   Object.keys(record).map(key => {
  //     if (typeof record[key] === "string" && dateFormat.test(record[key])) {
  //       const date = parseDate(record[key]);
  //       if (date !== null) {
  //         record[key] = date;
  //       }
  //     }
  //   });
  //   return record;
  // }
}
