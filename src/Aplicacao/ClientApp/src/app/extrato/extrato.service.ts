import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActionResult } from './model/action-result.model';

@Injectable({
  providedIn: 'root'
})
export class ExtratoService {
  baseUrlApi: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrlApi = baseUrl;
  }

  uploadExtractsFiles(model: any): Observable<ActionResult> {
    return this.http.post<ActionResult>(`${this.baseUrlApi}api/upload/uploadFiles/`, model);
  }

  saveExtract(model: any): Observable<ActionResult> {
    return this.http.post<ActionResult>(`${this.baseUrlApi}api/extract/save/`, model);
  }

  updateTransaction(model: any): Observable<ActionResult> {
    return this.http.post<ActionResult>(`${this.baseUrlApi}api/extract/updateTransaction/`, model);
  }

  deleteTransaction(idTransaction: string): Observable<ActionResult> {
    return this.http.get<ActionResult>(`${this.baseUrlApi}api/extract/deleteTransaction?idTransaction=${idTransaction}`);
  }

  getAccount(): Observable<ActionResult> {
    return this.http.get<ActionResult>(`${this.baseUrlApi}api/extract/getAccount/`);
  }

  getExtractsByIdDataBank(idDataBank: string): Observable<ActionResult> {
    return this.http.get<ActionResult>(`${this.baseUrlApi}api/extract/getExtractsByIdDataBank?idDataBank=${idDataBank}`);
  }

}

