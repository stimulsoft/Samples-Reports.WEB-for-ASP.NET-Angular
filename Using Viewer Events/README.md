# Using Viewer Events

This example illustrates how to use Stimulsoft Angular Viewer events.

### Step by step
  
#### app.component.html
   
    <stimulsoft-viewer-angular
      [requestUrl]="'http://localhost:60801/Viewer/{action}'"
      [action]="'InitViewer'"
      [height]="'600px'"
   Define event on viewer loaded:
   
      (loaded)="loaded()"
  Define event on user run export:
  
      (export)="export($event)">
    </stimulsoft-viewer-angular>

#### app.component.ts
   
    import { Component } from '@angular/core';
    @Component({
      selector: 'app-root',
      templateUrl: './app.component.html',
      styleUrls: ['./app.component.css']
    })
    
    export class AppComponent {
      title = 'ClientApp';
Show log when viewer loaded:

      loaded(): void {
        console.log('Report loaded');
      }

Show export format in log when user run export:
     
      export(event: any): void {
       console.log(`Export to: ${event.exportFormat}`);  
      }
    } 
