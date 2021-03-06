﻿import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute} from '@angular/router';
import {NavbarComponent} from "../components/navbar/navbar.component";
import {SidebarComponent} from "../components/sidebar/sidebar.component";

import {AlertService, AuthenticationService} from '../_services/';
import {ValidLoginService} from '../_services/validLogin.service';

@Component({
  providers: [NavbarComponent, SidebarComponent],
  moduleId: module.id.toString(),
  templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private authenticationService: AuthenticationService,
              private navbar: NavbarComponent,
              private sidebar: SidebarComponent,
              private alertService: AlertService,
              private validLogin:ValidLoginService) {
  }

  ngOnInit() {
    // reset login status

    this.authenticationService.logout()

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
  }

  login() {
    this.loading = true;
    this.authenticationService.login(this.model.username, this.model.password)
      .subscribe(
        data => {
          this.validLogin.validToken=true;
          this.navbar.ngOnInit();
          this.sidebar.ngOnInit();
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }
}
