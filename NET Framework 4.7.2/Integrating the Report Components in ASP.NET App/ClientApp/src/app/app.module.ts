import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { StimulsoftViewerModule } from 'stimulsoft-viewer-angular';
import { StimulsoftDesignerModule } from 'stimulsoft-designer-angular';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    StimulsoftViewerModule,
    StimulsoftDesignerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
