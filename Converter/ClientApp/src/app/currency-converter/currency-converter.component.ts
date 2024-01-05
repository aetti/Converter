import { Component } from '@angular/core';
import { CurrencyConverterService } from '../../services/currency-converter.service';

@Component({
  selector: 'app-currency-converter',
  templateUrl: './currency-converter.component.html',
  styleUrls: ['./currency-converter.component.css']
})
export class CurrencyConverterComponent {
  amount: Number = 0;
  result = '';

  constructor(private currencyConverterService: CurrencyConverterService) { }

  convertCurrency() {
    this.currencyConverterService.convertCurrency(this.amount).subscribe(result => {
      console.log(result); // Added for debugging
      this.result = result.currencyText;
    }, error => console.error(error));
  }

  clearInput() {
    this.amount = 0;
    this.result = '';
  }
}

