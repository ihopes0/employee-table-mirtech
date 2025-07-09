import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { AboutComponent } from '../components/AboutComponent/about.component';
import { EmployeeListComponent } from '../components/EmployeeListComponent/employee-list.component';

import { AppRoutingModule } from './app-routing.module';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter([
        { path: '', redirectTo: '/about', pathMatch: 'full' },
        { path: 'about', component: AboutComponent },
        { path: 'employees', component: EmployeeListComponent },
        { path: '**', redirectTo: '/about' }
      ]), provideClientHydration(withEventReplay())
  ]
};
