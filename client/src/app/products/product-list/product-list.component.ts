import { IType } from './../../_models/IType';
import { IBrand } from './../../_models/IBrand';
import { IProduct } from './../../_models/IProduct';
import { ProductParams } from './../../_models/productParams';
import { ProductsService } from './../../_services/products.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  params = new ProductParams();
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  sortOptions = [
    { name: 'Alphabetical', value: 'byName' },
    { name: 'Price: Low to High', value: 'byPriceAsc' },
    { name: 'Price: High to Low', value: 'byPriceDesc' },
  ];

  constructor(private productService: ProductsService) {}

  ngOnInit() {
    this.loadProducts();
    this.loadBrands();
    this.loadTypes();
  }
  loadProducts() {
    this.productService.getProducts(this.params).subscribe(
      (res: IProduct[]) => {
        this.products = res;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  loadBrands() {
    this.productService.getBrands().subscribe(
      (res: IBrand[]) => {
        this.brands = res;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  loadTypes() {
    this.productService.getTypes().subscribe(
      (res: IType[]) => {
        this.types = res;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  onSorted(sort: string) {
    this.params.orderBy = sort;
    this.loadProducts();
  }
  onBrand(brand: number) {
    this.params.byBrand = brand;
    this.loadProducts();
  }
  onType(type: number) {
    this.params.byType = type;
    this.loadProducts();
  }
}
