import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {fakeBackendProvider} from './_helpers/';

import {AppRoutingModule} from './app.routing';
import {ComponentsModule} from './components/components.module';
import {AppComponent} from './app.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {UserProfileComponent} from './user-profile/user-profile.component';
import {NotificationsComponent} from './notifications/notifications.component';
import {RefreshComponent} from './components/refresh/refresh.component';

import {AlertComponent} from './_directives/';
import {AuthGuard} from './_guards/';
import {JwtInterceptor} from './_helpers/';
import {AlertService, AuthenticationService, UserService} from './_services/';
import {HomeComponent} from './home/';
import {LoginComponent} from './login/';
import {RegisterComponent} from './register/';
import {WidgetComponent} from './dashboard/directives/widget.component';
import {ValidLoginService} from './_services/validLogin.service';




@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    UserProfileComponent,
    NotificationsComponent,
    RefreshComponent,
    AlertComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    WidgetComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule
       ],
  providers: [
    AuthGuard,
    ValidLoginService,
    AlertService,
    AuthenticationService,
    UserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },

    // provider used to create fake backend
    fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
