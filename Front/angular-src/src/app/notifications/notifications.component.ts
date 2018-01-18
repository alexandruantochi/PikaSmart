import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ValidLoginService} from '../_services/validLogin.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  public listNotifications: any;
  public name: any;
  public colors: any;

  constructor(private http: HttpClient, private logged: ValidLoginService) {
    this.colors = ['danger', 'success', 'info', 'warning'];

  }

  ngOnInit() {
    this.http.get(this.logged.dispatcherUrl + '/temperature/notification').subscribe(data => {
        this.name = 'temperature';

        for (var elem in data) {
          data['data'] = new Date(data['data']);
        }
        this.listNotifications = data;
      }, err => console.error(err),
      () => console.log('received'));
  }

}
