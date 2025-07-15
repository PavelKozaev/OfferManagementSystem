import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { OfferService } from '../../core/api/offer.service';
import { PopularSupplier } from '../../core/models/supplier.model';

@Component({
  selector: 'app-popular-suppliers',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './popular-suppliers.html',
  styleUrl: './popular-suppliers.css'
})
export class PopularSuppliers implements OnInit {

  suppliers: PopularSupplier[] = [];
  isLoading = true; 
  error: string | null = null; 

  constructor(private offerService: OfferService) {}

  ngOnInit(): void {
    this.offerService.getPopularSuppliers().subscribe({
            
      next: (data) => {
        this.suppliers = data; 
        this.isLoading = false; 
      },
      
      error: (err) => {
        console.error('Ошибка при загрузке популярных поставщиков', err);
        this.error = 'Не удалось загрузить данные. Пожалуйста, попробуйте обновить страницу.';
        this.isLoading = false; 
      }
    });
  }
}