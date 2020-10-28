import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AddPositionComponent } from './add-position/add-position.component'
import { AddEmployeePositionComponent } from './add-employee-position/add-employee-position.component';
import { EmployeePositionList } from './employee-position-list/employee-position-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddPositionComponent,
    AddEmployeePositionComponent,
    EmployeePositionList
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
