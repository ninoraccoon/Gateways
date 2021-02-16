import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Gateway, Peripheral } from 'src/app/fetch-data/fetch-data.component';

@Component({
  selector: 'app-add-edit-ph',
  templateUrl: './add-edit-ph.component.html',
  styleUrls: ['./add-edit-ph.component.css']
})
export class AddEditPhComponent implements OnInit {
  @Input()
  gw:Gateway;
  @Input()
  ph:Peripheral;

  uid:number;
  vendor: string;
  status: boolean;
  creatioDate:Date;  
  @Output() onSuggest: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit() {
    this.uid = this.ph.uid;
    this.vendor=this.ph.vendor;
    this.status=this.ph.status;
    this.creatioDate = this.ph.creatioDate;
  }

  addGw(){
    var min=0;
    this.gw.peripheral.forEach(i=>{if(min>i.id) min = i.id;})
    min--;
    var ph = this.gw.peripheral.find(i=>i.id==0);
    ph.uid=this.uid;
    ph.vendor=this.vendor;
    ph.status = this.status;
    ph.creatioDate = this.creatioDate;
    ph.GatewayId = this.gw.id;
    ph.id = min;
    this.onSuggest.emit([]);
  }

  EditGw(){
    var ph = this.gw.peripheral.find(i=>i.id==this.ph.id);
    ph.uid=this.uid;
    ph.vendor=this.vendor;
    ph.status = this.status;
    ph.creatioDate = this.creatioDate;
    ph.GatewayId = this.gw.id;
    this.onSuggest.emit([]);
  }

}
