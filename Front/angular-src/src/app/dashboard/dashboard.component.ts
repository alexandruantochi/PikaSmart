import {Component, OnInit} from '@angular/core';
import * as Chartist from 'chartist';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public data1;
  public arraySensors:any;


  constructor(private http: HttpClient){
  }
  getData(){
    //user id
    //dispather - url
    var dispatcherURL='http://localhost:53836/api/';
    //list de senzori foreach
    this.http.get(dispatcherURL+'/temperature/').subscribe(data => {
      data["temperatureRecords"].forEach(record=>{
        record.time=new Date(record.time)
      });
      console.log(data);
      this.arraySensors=[];
      for(var index=0;index<3;index++){
        // this.arraySensors.push(data)
        this.arraySensors.push(dispatcherURL +'/temperature')
      }

    } , err => console.error(err),
      () => console.log('done'));
  }
  ngOnInit() {
    this.getData();

  }
}
