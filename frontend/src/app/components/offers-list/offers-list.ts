import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferService } from '../../core/api/offer.service';
import { WritableSignal } from '@angular/core'; 
import { Offer } from '../../core/models/offer.model';

@Component({
  selector: 'app-offers-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './offers-list.html',
  styleUrl: './offers-list.css'
})
export class OffersList implements OnInit {
  offers: WritableSignal<Offer[]>;
  totalCount: WritableSignal<number>;
  isLoading: WritableSignal<boolean>;
  error: WritableSignal<string | null>;
  
  constructor(private offerService: OfferService) {
    this.offers = this.offerService.offers;
    this.totalCount = this.offerService.totalCount;
    this.isLoading = this.offerService.isLoading;
    this.error = this.offerService.error;
  }

  ngOnInit(): void {
    this.offerService.loadInitialOffers();
  }
}