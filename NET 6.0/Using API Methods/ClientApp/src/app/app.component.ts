import { Component, ViewChild } from '@angular/core';
import { StimulsoftViewerComponent } from 'stimulsoft-viewer-angular';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    standalone: false
})
export class AppComponent {

  @ViewChild('viewer') viewer: StimulsoftViewerComponent;

  title = 'ClientApp';
}
