import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { AppNavbarComponent } from './app-navbar/app-navbar.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { AppFooterComponent } from './app-footer/app-footer.component';
import { AppBoxComponent } from './app-box/app-box.component';
import { AppUserComponent } from './app-user/app-user.component';
import { AppPreferencesComponent } from './app-preferences/app-preferences.component';
import { AppDashboardComponent } from './app-dashboard/app-dashboard.component';
import { AppAlarmsComponent } from './app-alarms/app-alarms.component';
import { AppMenuComponent } from './app-menu/app-menu.component';
import { AppRegisterComponent } from './app-register/app-register.component';
import { AppLoginComponent } from './app-login/app-login.component';

const appRoutes: Routes = [
  {path:'', component:AppDashboardComponent},
  {path:'login', component:AppLoginComponent},
  {path:'register',component:AppRegisterComponent},
  {path:'user', component:AppUserComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    AppNavbarComponent,
    AppHeaderComponent,
    AppFooterComponent,
    AppBoxComponent,
    AppUserComponent,
    AppPreferencesComponent,
    AppDashboardComponent,
    AppAlarmsComponent,
    AppMenuComponent,
    AppRegisterComponent,
    AppLoginComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
