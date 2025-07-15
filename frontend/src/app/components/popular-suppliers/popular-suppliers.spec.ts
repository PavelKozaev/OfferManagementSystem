import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopularSuppliers } from './popular-suppliers';

describe('PopularSuppliers', () => {
  let component: PopularSuppliers;
  let fixture: ComponentFixture<PopularSuppliers>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PopularSuppliers]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PopularSuppliers);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
