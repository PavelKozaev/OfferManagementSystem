import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { PopularSuppliers } from './components/popular-suppliers/popular-suppliers';
import { SearchBar } from './components/search-bar/search-bar';
import { OffersList } from './components/offers-list/offers-list';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
     PopularSuppliers,
    SearchBar,
    OffersList
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}