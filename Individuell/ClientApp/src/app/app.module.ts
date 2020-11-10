import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { Liste } from './liste/liste';
import { Meny } from './meny/meny';
import { Ny } from './ny/ny';
import { SpmList } from './spmList/spmList';
import { AlleKontakt } from './alleKontakt/alleKontakt';
import { AppRoutingModule } from './app-routing.module';



@NgModule({
  declarations: [
    AppComponent,
    Liste,
    Meny,
    Ny,
    SpmList,
    AlleKontakt
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
