import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    standalone: false
})
export class AppComponent {
  title = 'ClientApp';

  loaded(): void {
    console.log('Report loaded');
  }

  export(event: any): void {
    console.log(`Export to: ${event.exportFormat}`);
  }
}
