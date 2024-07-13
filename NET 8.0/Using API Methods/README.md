# Using API Methods

This example illustrates how execute methods of StimulsoftViewerComponent. 
StimulsoftViewerComponent contains api object that allow to manipulate viewer or view states.

### Step by step
  
#### app.component.ts
   
    import { Component, ViewChild } from '@angular/core';
    import { StimulsoftViewerComponent } from 'stimulsoft-viewer-angular';
    @Component({
      selector: 'app-root',
      templateUrl: './app.component.html',
      styleUrls: ['./app.component.css']
    })
    
    export class AppComponent {
Define reference to StimulsoftViewerComponent:

      @ViewChild('viewer') viewer: StimulsoftViewerComponent;
      title = 'ClientApp';
    }


#### app.component.html
Add reference to component, add display current page & zoom, add buttons that allow to zoom page to 50% & export report to PDF format with setting ImageQuality to 200:
   
    <input type="button" (click)="viewer.api.zoom = 50" value="Zoom to 50%" />
    <input type="button" (click)="viewer.api.export('Pdf', { ImageResolution: 200 })" value="Export to PDF"/>
    <stimulsoft-viewer-angular #viewer
      [requestUrl]="'http://localhost:60801/Viewer/{action}'"
      [action]="'InitViewer'"
      [height]="'600px'">
    </stimulsoft-viewer-angular>

