import { Component } from '@angular/core';
import { PhoneService } from './Phone/phone.service';
import { Observable } from 'rxjs';
import { ProductDto } from './Phone/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontEnd';
products: ProductDto[];
  constructor(private productService: PhoneService){
    this.productService.getAllProduct();
    this.productService.getListProducts$().subscribe(x=>{
      if(x){
        console.log(x);
        this.products = x;
      }
    })
  }
}
