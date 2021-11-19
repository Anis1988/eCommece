import { IProduct } from './../../_models/IProduct';
import { ProductParams } from './../../_models/productParams';
import { ProductsService } from './../../_services/products.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  params = new ProductParams();
  products: IProduct[];

  constructor(private productService: ProductsService) {}

  ngOnInit() {
    this.loadProducts();
  }
  loadProducts() {
  
    this.productService.getProducts(this.params).subscribe(
      (res: IProduct[]) => {
        this.products = res;
      },
      error => {
        console.log(error);
      }
    );
  }
}
