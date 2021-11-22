import { IType } from './../_models/IType';
import { IBrand } from './../_models/IBrand';
import { IProduct } from './../_models/IProduct';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductParams } from '../_models/productParams';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  baseUrl = environment.apiUrl;
  products: IProduct[] = [];
  brands: IBrand[] = [];
  types: IType[] = [];

  constructor(private http: HttpClient) {}

  getProducts(productParams: ProductParams) {
    // if (this.products.length > 0) {
    //   return of(this.products);
    // }
    let params = new HttpParams();

    if (productParams.byBrand ) {
      params = params.append('byBrand', productParams.byBrand.toString());
    }
    if (productParams.byType) {
      params = params.append('byType', productParams.byType.toString());
    }
    if (productParams.search) {
      params = params.append('search', productParams.search);
    }
    if (productParams.orderBy) {
      params = params.append('OrderBy', productParams.orderBy);
    }
    params = params.append('pageNumber', productParams.pageNumber);
    params = params.append('pageSize', productParams.pageSize);

    return this.http
      .get<IProduct[]>(this.baseUrl + 'product', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.products = response.body;
          return response.body;
        })
      );
  }
  getBrands() {
    // if (this.brands.length > 0) {
    //   return of(this.brands);
    // }
    return this.http
      .get<IBrand[]>(this.baseUrl + 'product/brands')
      .pipe(
        map((response) => {
          this.types = response;
          return response;
        })
      );
  }
  getTypes() {
    // if (this.types.length > 0) {
    //   return of(this.types);
    // }
    return this.http
      .get<IType[]>(this.baseUrl + 'product/types')
      .pipe(
        map((response) => {
          this.types = response;
          return response;
        })
      );
  }
}
