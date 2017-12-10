import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgIf } from '@angular/common/src/directives';
declare var jQuery;

@Component({
  selector: 'app-login',
  templateUrl: './app-login.component.html',
  styleUrls: ['./app-login.component.css']
})
export class AppLoginComponent implements OnInit {

  constructor(private router:Router) { 
  }

  activateCheckBox(){
    jQuery('.checkbox').checkbox();
  }

  onSubmit(){
    this.router.navigate(['user']);
  }
  
  ngOnInit() {
    this.activateCheckBox();
  }


}
