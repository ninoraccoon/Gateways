import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { GwService } from 'src/app/gw-service.service';
import { Gateway, Peripheral } from '../fetch-data.component';

@Component({
  selector: 'app-add-edit-gateway',
  templateUrl: './add-edit-gateway.component.html',
  styleUrls: ['./add-edit-gateway.component.css']
})
export class AddEditGatewayComponent implements OnInit {
  @Input()
  gw:Gateway;
  serial:string;
  id:number;
  ipv4:string;
  Peripheral:Peripheral[];
  @Output() onSuggest: EventEmitter<any> = new EventEmitter();

  constructor(private service:GwService) { 
   
  }

  addGw(){
    var data =<Gateway>{
      ipv4:this.ipv4,
      peripheral:this.gw.peripheral,
      serial:this.serial
    }
    this.service.AddGw(data).subscribe(r=>{
      alert(r.toString());
      this.onSuggest.emit([]);
    });
   
  }
  EditGw(){
    console.log(this.gw);
   
    var data =<Gateway>{
      ipv4:this.ipv4,
      peripheral:this.gw.peripheral,
      serial:this.serial,
      id:this.id
    }
    this.service.UpdateGw(data.id,data).subscribe(r=>{
      alert(r.toString());
      this.onSuggest.emit([]);
    });
  

  }

  ngOnInit() {
    this.serial=this.gw.serial;
    this.id=this.gw.id;
    this.ipv4=this.gw.ipv4;
    console.log(this.gw);
    this.Peripheral = this.gw.peripheral;
  }

}
