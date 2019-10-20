import { Injectable } from '@angular/core';
import { ProductClient, ProductDto } from './api';
import { Model, ModelFactory } from '@angular-extensions/model';

@Injectable()
export class PhoneService {

  private product= new Model<ProductDto[]>([], false, false);
  private product$ = this.product.data$;
  constructor(private productClient: ProductClient) { }

  getAllProduct() {
    this.productClient.getAllProducts().subscribe(x => {
      if (x) {
        this.product.set(x);
      }
    })
  }

  getListProducts$() {
    return this.product$;
  }
}
