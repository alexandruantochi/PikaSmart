import {Component, OnDestroy, OnInit} from '@angular/core';
import '../assets/app.css';
import {LoginComponent} from './login';
import {AuthenticationService} from './_services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit,OnDestroy {
  public dispatcherUrl:any;
  constructor(private log:AuthenticationService){
    this.dispatcherUrl="http://localhost:53836/api/"
  }
  ngOnInit() {

  }
  ngOnDestroy(){
    this.log.logout();
  }
}
