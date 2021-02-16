import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GwService } from '../gw-service.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public Gateways: Gateway[];

  ModalTitle:string;
  activateAddEditGw:boolean=false;
  gw:Gateway;
  display = "none";
  constructor(private service:GwService) {
     this.refresh();
  }

  addClick(){
    this.display = "block";
    this.gw = {
      peripheral:[],
      id:0,
      ipv4:"",
      serial:""
    };
    this.ModalTitle = "Add new Dep"
    this.activateAddEditGw = true;
  }

  editClick(data:Gateway){
    this.display = "block";
    console.log(data);
    this.gw = data;
    this.ModalTitle = `Edit ${data.serial}`
    this.activateAddEditGw = true;
  }

  closeClick(){
    this.display = "none";
    this.activateAddEditGw = false;
    this.refresh();
  }

  refresh(){
    this.service.getGw().subscribe(result=>{
      this.Gateways  = result;
     });
  }

  deleteClick(data:Gateway){
    this.service.RemoveGw(data.id).subscribe(r=>{
      this.refresh();
    });
  }
  
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export interface Gateway {
  id: number;
  serial: string;
  ipv4: string;
  peripheral:Peripheral[]
}

export interface Peripheral {
  id: number;
  uid:number;
  vendor: string;
  status: boolean;
  creatioDate:Date;
  GatewayId:number;
}
