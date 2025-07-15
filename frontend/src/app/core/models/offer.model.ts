export interface Offer {
  id: number;
  brand: string;
  model: string;
  supplierName: string;
  registeredAt: Date;
}

export interface PagedOffers {
  items: Offer[];
  totalCount: number;
}