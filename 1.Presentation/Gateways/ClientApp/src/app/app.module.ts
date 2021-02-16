import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AddEditGatewayComponent } from './fetch-data/add-edit-gateway/add-edit-gateway.component';
import { PeripheralComponent } from './peripheral/peripheral.component';
import { AddEditPhComponent } from './peripheral/add-edit-ph/add-edit-ph.component';
import {GwService} from './gw-service.service'


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    
    CounterComponent,
    FetchDataComponent,
    AddEditGatewayComponent,
    PeripheralComponent,
    AddEditPhComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },     
      { path: '', component: FetchDataComponent, pathMatch: 'full' },
    ])
  ],
  providers: [GwService],
  bootstrap: [AppComponent]
})
export class AppModule { }
