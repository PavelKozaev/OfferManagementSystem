import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, tap, debounceTime, switchMap, of, Subject } from 'rxjs';
import { Offer, PagedOffers } from '../models/offer.model';
import { PopularSupplier } from '../models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  private readonly apiUrl = 'http://localhost:8080/api';
  
  readonly offers = signal<Offer[]>([]);
  readonly totalCount = signal<number>(0);
  readonly isLoading = signal<boolean>(false);
  readonly error = signal<string | null>(null);

  private searchTerm$ = new Subject<string>();

  constructor(private http: HttpClient) {
    this.searchTerm$.pipe(
      debounceTime(300), 
      switchMap(term => { 
        this.isLoading.set(true); 
        this.error.set(null);
        return this.fetchOffers(term);
      })
    ).subscribe(response => {
      this.offers.set(response.items); 
      this.totalCount.set(response.totalCount); 
      this.isLoading.set(false); 
    });
  }

  search(term: string): void {
    this.searchTerm$.next(term);
  }

  loadInitialOffers(): void {
    this.search('');
  }

  getPopularSuppliers(): Observable<PopularSupplier[]> {
    return this.http.get<PopularSupplier[]>(`${this.apiUrl}/suppliers/popular`);
  }

  private fetchOffers(term: string): Observable<PagedOffers> {
    let params = new HttpParams();
    if (term) {
      params = params.append('searchTerm', term);
    }
    return this.http.get<PagedOffers>(`${this.apiUrl}/offers`, { params });
  }
}