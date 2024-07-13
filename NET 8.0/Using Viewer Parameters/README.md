# Using Viewer Parameters

This example illustrates how to pass necessary properties from Angular to server.

### Step by step

#### app.component.ts

Transfer  parameter *reportName*. 

    import { Component } from '@angular/core';
    
    @Component({
      selector: 'app-root',
      templateUrl: './app.component.html',
      styleUrls: ['./app.component.css']
    })
    
    export class AppComponent {
      reports = ['MasterDetail.mrt', 'EditableReport.mrt'];
      title = 'ClientApp';
Define properties

      properties = { reportName: this.reports[0] };
      
Method that update properties
      
      updateProps(reportName: string): void {
        this.properties = { reportName };
      }
    }


####  app.component.html

Add possibility to change reports in Angular Viewer.

    <select  
Update properties on selection changed:
    
      (change)="updateProps($event.target.value)">    
      <option  *ngFor="let item of reports"  [value]="item">{{ item }}</option>
    </select>
    <stimulsoft-viewer-angular
      [requestUrl]="'http://localhost:60801/Viewer/{action}'"
      [action]="'InitViewer'"
      [height]="'600px'"
      
 Define viewer options:
 
      [properties]="properties">
    </stimulsoft-viewer-angular>
    
#### ViewerController.cs
   
    public class ViewerController : Controller
    {

        [HttpPost]
        public IActionResult InitViewer()
        {
            var requestParams = StiAngularViewer.GetRequestParams(this);
            var options = new StiAngularViewerOptions();
            options.Actions.ViewerEvent = "ViewerEvent";
            return StiAngularViewer.ViewerDataResult(requestParams, options);
        }

        [HttpPost]
        public IActionResult ViewerEvent()
        {
            var requestParams = StiAngularViewer.GetRequestParams(this);

            if (requestParams.Action == StiAction.GetReport)
            {
Check request parameter with name *properties*

                var reportName = "MasterDetail.mrt";
                var httpContext = new Stimulsoft.System.Web.HttpContext(this.HttpContext);
                var properties = httpContext.Request.Params["properties"]?.ToString();
                if (properties != null)
                {
Convert property from Base64 and deserialize the JSON to the specified .NET type.

                    var data = Convert.FromBase64String(properties);
                    var json = Encoding.UTF8.GetString(data);
                    JContainer container = JsonConvert.DeserializeObject<JContainer>(json);
                    foreach (JToken token in container.Children())
                    {
Check reportName token & use it as report name:

                        if (((JProperty)token).Name == "reportName")
                        {
                            reportName = ((JProperty)token).Value.Value<string>();
                        }
                    }
                }

                var report = StiReport.CreateNewReport();
                var path = StiAngularHelper.MapPath(this, $"Reports/{reportName}");
                report.Load(path);
                return StiAngularViewer.GetReportResult(this, report);
            }

            return StiAngularViewer.ProcessRequestResult(this);
        }
    }
}
