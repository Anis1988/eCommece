import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/_models/IProduct';

@Component({
  selector: 'app-product-item-details',
  templateUrl: './product-item-details.component.html',
  styleUrls: ['./product-item-details.component.css']
})
export class ProductItemDetailsComponent implements OnInit {
  @Input () product: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
