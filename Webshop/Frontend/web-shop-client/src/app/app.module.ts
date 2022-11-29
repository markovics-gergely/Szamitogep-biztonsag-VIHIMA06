import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LoadingComponent } from './components/loading/loading.component';
import { PreviewComponent } from './components/preview/preview.component';
import { PagerComponent } from './components/pager/pager.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { BrowseComponent } from './components/browse/browse.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatBadgeModule } from '@angular/material/badge';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { DetailsComponent } from './components/details/details.component';
import { InventoryComponent } from './components/inventory/inventory.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { AddCaffComponent } from './add-caff/add-caff.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LoadingComponent,
    PreviewComponent,
    PagerComponent,
    SidebarComponent,
    BrowseComponent,
    DetailsComponent,
    InventoryComponent,
    CheckoutComponent,
    ConfirmComponent,
    AddCaffComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatSnackBarModule,
    NgbModule,
    MatBadgeModule,
    MatDialogModule,
    MatTooltipModule,
    MatCheckboxModule,
    JwtModule.forRoot({
      config: {},
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
