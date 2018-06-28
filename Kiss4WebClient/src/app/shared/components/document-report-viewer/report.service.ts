import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class ReportService {
    private _url = '/assets/data/test_report.json';

    constructor(private http: HttpClient) { }

    getReportViewer(): Observable<Pick<any, any>> {
        return this.http.get<Pick<any, any>>(this._url)
            .catch(this.errorHandler);
    }

    errorHandler(error: HttpErrorResponse) {
        return Observable.throw(error.message || 'Server Error');
    }
}
