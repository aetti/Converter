import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CurrencyConverterService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  convertCurrency(amount: Number) {
    const url = `${this.baseUrl}currencyconvertervalues/${amount}`;
    return this.http.get<any>(url);
  }
}

