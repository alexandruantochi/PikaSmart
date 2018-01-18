import {Component, OnInit} from '@angular/core';
import * as Chartist from 'chartist';
import {HttpClient} from '@angular/common/http';
import {ValidLoginService} from '../_services/validLogin.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public arraySensors: any;

  constructor(private http: HttpClient, private logged: ValidLoginService) {
    this.arraySensors=[];
  }

  getData() {
    for (var elem in this.logged.microServicesList) {
      this.arraySensors.push(this.logged.dispatcherUrl + `/${this.logged.microServicesList[elem]}`);

    }
  }

  ngOnInit() {
    this.getData();

  }

}
