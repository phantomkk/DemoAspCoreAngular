import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PhoneService } from './Phone/phone.service'; 
import { ProductClient, API_BASE_URL } from './Phone/api';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
  ],
  providers: [ProductClient, PhoneService, 
  {provide: API_BASE_URL, useValue: "https://localhost:5001"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
