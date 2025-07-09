// src/app/app.module.ts
import { NgModule, LOCALE_ID } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { registerLocaleData } from '@angular/common'
import { HttpClientModule } from '@angular/common/http'
import localeRu from '@angular/common/locales/ru';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { RouterOutlet, RouterLink } from '@angular/router';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { EmployeeListComponent } from '../components/EmployeeListComponent/employee-list.component'
import { EmployeeFormComponent } from '../components/EmployeeFormComponent/employee-form.component'
import { EmployeeModalComponent } from '../components/EmployeeModalComponent/employee-modal.component'
import { ConfirmModalComponent } from '../components/ConfirmModalComponent/confirm-modal.component'
import { AboutComponent } from '../components/AboutComponent/about.component'

registerLocaleData(localeRu);

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    EmployeeFormComponent,
    EmployeeModalComponent,
    ConfirmModalComponent,
    AboutComponent,
  ],
  imports: [
  RouterOutlet,
    RouterLink,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'ru' }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
