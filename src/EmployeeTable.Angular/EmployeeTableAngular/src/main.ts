import { bootstrapApplication } from '@angular/platform-browser';
import { platformBrowser } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.component.config';
import { AppModule } from './app/app.module';

const platform = platformBrowser();

platform.bootstrapModule(AppModule)

// bootstrapApplication(AppComponent, appConfig)
//   .catch(e => console.error(e));
