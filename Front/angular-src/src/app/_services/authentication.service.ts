import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import {ValidLoginService} from './validLogin.service';

@Injectable()
export class AuthenticationService {

    constructor(private http: HttpClient ,private  validLogin:ValidLoginService) { }

    login(username: string, password: string) {

        return this.http.post('http://localhost:53836/api/authenticate/login', { UserName: username, Password: password })
            .map(user => {
                // login successful if there's a jwt token in the response
                if (user && user["Token"]) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.validLogin.user=user;
                }

                return user;
            });
    }

    logout() {
     // this.validLogin.validToken=false;

      localStorage.removeItem('currentUser');
        // remove user from local storage to log user out

    }
}
