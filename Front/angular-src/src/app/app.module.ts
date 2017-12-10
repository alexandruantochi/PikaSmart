import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

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
    AppMenuComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
