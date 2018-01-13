import {Component, ElementRef, OnInit} from '@angular/core';
import {User} from "../../_models";
import {Location} from "@angular/common";
import {UserService} from "../../_services";

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}

export const ROUTES: RouteInfo[] = [
  {path: 'dashboard', title: 'Dashboard', icon: 'dashboard', class: ''},
  {path: 'user-profile', title: 'User Profile', icon: 'person', class: ''},
  {path: 'notifications', title: 'Notifications', icon: 'notifications', class: ''}

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  currentUser: User;
  menuItems: any[];

  constructor(private userService: UserService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }

}
