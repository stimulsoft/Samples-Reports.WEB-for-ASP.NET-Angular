import { BrowserModule } from '@angular/platform-browser';
import { NgModule, provideExperimentalZonelessChangeDetection } from '@angular/core';
import { StimulsoftViewerModule } from 'stimulsoft-viewer-angular';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { StimulsoftDesignerModule } from 'stimulsoft-designer-angular';

@NgModule({
    declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        StimulsoftViewerModule,
        StimulsoftDesignerModule,
        FormsModule],
    providers: [provideExperimentalZonelessChangeDetection(), provideHttpClient(withInterceptorsFromDi())]
})
export class AppModule { }
