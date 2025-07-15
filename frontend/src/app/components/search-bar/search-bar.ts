import { Component } from '@angular/core';
import { OfferService } from '../../core/api/offer.service';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [],
  templateUrl: './search-bar.html',
  styleUrl: './search-bar.css'
})
export class SearchBar {
  constructor(private offerService: OfferService) {}

  onSearch(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    this.offerService.search(inputElement.value);
  }
}