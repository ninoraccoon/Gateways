import { Injectable, Inject } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http'

import { Gateway } from './fetch-data/fetch-data.component';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GwService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  getGw(){
    return this.http.get<Gateway[]>(this.baseUrl + 'api/Gateway').pipe(
      retry(2),
      catchError(this.handleError)
    );
  }

  AddGw(value:Gateway){
    return this.http.post(this.baseUrl + 'api/Gateway',value) .pipe(
      retry(2),
      catchError(this.handleError)
    );
  }

  UpdateGw(id:number,value:Gateway){
    value.peripheral.forEach(i=> {
      if(i.id<0)
        i.id = 0;
    });
    return this.http.put(this.baseUrl + 'api/Gateway'+ `/${id}`,value) .pipe(
      retry(2),
      catchError(this.handleError)
    );
  }

  RemoveGw(value:number){
    return this.http.delete(this.baseUrl + 'api/Gateway'+ `/${value}`) .pipe(
      retry(2),
      catchError(this.handleError)
    );
  }

  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      alert('An error occurred:' + error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      alert(
        `Backend returned code ${error.status}, ` +
        `body was: ${JSON.stringify(error.error)}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };

}
