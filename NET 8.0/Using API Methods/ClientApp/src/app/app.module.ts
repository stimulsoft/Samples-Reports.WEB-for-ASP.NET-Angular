import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { StimulsoftViewerModule } from 'stimulsoft-viewer-angular';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

@NgModule({ declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        StimulsoftViewerModule], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
