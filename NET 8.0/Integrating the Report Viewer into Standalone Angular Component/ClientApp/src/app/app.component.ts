import { Component } from '@angular/core';
import { StimulsoftViewerModule } from 'stimulsoft-viewer-angular';

@Component({
  selector: 'app-root',
  imports: [StimulsoftViewerModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'viewer';
}
