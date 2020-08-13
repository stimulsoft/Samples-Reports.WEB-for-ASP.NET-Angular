import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { StimulsoftViewerModule } from 'stimulsoft-viewer-angular';
import { StimulsoftDesignerModule } from 'stimulsoft-designer-angular';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    StimulsoftViewerModule,
    StimulsoftDesignerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
