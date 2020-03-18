import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PhoneData } from './phone-data.model';

@Injectable({
  providedIn: 'root'
})
export class PhoneServiceService {
  Url = 'http://localhost:60384/api/';
  constructor(private http: HttpClient) { }

  getPhoneData(phoneNumber: string, pageSize: number, pageNumber: number): Observable<PhoneData> {
    // tslint:disable-next-line: max-line-length
    return this.http.get<PhoneData>(this.Url + 'Phone/GetPhoneCombination?phoneNumber=' + phoneNumber + '&pageNumber=' +
      pageNumber + '&pageSize=' + pageSize);
  }
}
