import { Component, Input, OnInit } from '@angular/core';
import { Gateway, Peripheral } from '../fetch-data/fetch-data.component';

@Component({
  selector: 'app-peripheral',
  templateUrl: './peripheral.component.html',
  styleUrls: ['./peripheral.component.css']
})
export class PeripheralComponent implements OnInit {
  @Input()
  gw:Gateway;

  ph:Peripheral;
  ModalTitle:string;
  activateAddEditGw:boolean=false;  
  display = "none";  
  
  constructor() { }

  ngOnInit() {
    console.log(this.gw);
  }

  addClick(){
    this.display = "block";
    this.ph = {
      uid:0,
      id:0,
      GatewayId:this.gw.id,
      creatioDate:new Date(),
      status:true,
      vendor:''
    };
    if(!this.gw.peripheral)
      this.gw.peripheral=[];
    this.gw.peripheral.push(this.ph);   
    this.ModalTitle = "Add new Dep"
    this.activateAddEditGw = true;
  }

  editClick(data:Peripheral){
    this.display = "block";
    this.ph = data;
    this.ModalTitle = `Edit ${data.uid}`
    this.activateAddEditGw = true;
  }

  closeClick(){
    console.log(this.gw.peripheral);
    this.display = "none";
    this.activateAddEditGw = false;    
    var phs = this.gw.peripheral.filter(i=>i.id!=0);
    this.gw.peripheral = phs;
  }

  deleteClick(data:Peripheral){
    console.log(this.gw.peripheral.indexOf(data));
    this.gw.peripheral.splice(this.gw.peripheral.indexOf(data),1);
  }

}
