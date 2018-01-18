import {Injectable} from '@angular/core';
import {Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';
import {AuthenticationService} from '../_services';
import {HttpClient} from '@angular/common/http';
import {ValidLoginService} from '../_services/validLogin.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private log: ValidLoginService, private http: HttpClient) {

    //this.log.ngOnInit()
  }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
  console.log(this.log.user,this.log.validToken)
    if (this.log.validToken) {
      return true;
    } else {
      this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
      return false;
    }


  }
}
