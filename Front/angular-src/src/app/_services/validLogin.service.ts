import {Injectable, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {User} from '../_models/';
import {IntervalObservable} from 'rxjs/observable/IntervalObservable';
import {Router} from '@angular/router';

@Injectable()
export class ValidLoginService implements OnInit {
  public dispatcherUrl: any;
  public user: any;
  public validToken: any;

  constructor(private http: HttpClient, private router: Router) {
    this.dispatcherUrl = 'http://localhost:53836/api';


    /*IntervalObservable.create(5000)
      .subscribe(() => {
        if (this.user) {
          this.http.get(this.dispatcherUrl + '/authenticate/' + this.user['Token'])
            .subscribe(data => {
              console.log(data);
              console.log(222, this.user);
              this.validToken = true;
            }, err => {
              this.validToken = false;
              this.router.navigate(['/login']);
              console.error(333, err);
            });
        }
      });*/

  }

  ngOnInit() {

  }
}
