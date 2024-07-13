# Integrating the Report Viewer into an Application

This example illustrates loading of the report with Angular Viewer.

### Step by step

#### app.component.html

Add *StimulsoftViewerComponent* to template:

    <stimulsoft-viewer-angular

Define URL template to server controller:

    [requestUrl]="'http://localhost:60801/Viewer/{action}'"

Define controller action that handle viewer initial request:

     [action]="'InitViewer'"

Define viewer height:

    [height]="'600px'";

#### ViewerController.cs

Definer action that handle viewer initial request:

    public IActionResult InitViewer() 
    {
	    var requestParams = StiAngularViewer.GetRequestParams(this);
Define Angular viewer  options:	    

	    var options = new StiAngularViewerOptions();
	    
Define ViewerEvent that will handle viewer request:

	    options.Actions.ViewerEvent = "ViewerEvent";
	    
Get the initial data for Angular Viewer:

	    return StiAngularViewer.ViewerDataResult(requestParams, options);
	}

Definer action that handle viewer requests:

    public IActionResult ViewerEvent()
    {
        var requestParams = StiAngularViewer.GetRequestParams(this);
Load report on GetReport action:

        if (requestParams.Action == StiAction.GetReport)
        {
            var report = StiReport.CreateNewReport();
            var path = StiAngularHelper.MapPath(this, $"Reports/MasterDetail.mrt");
            report.Load(path);
            return StiAngularViewer.GetReportResult(this, report);
        }
Process other viewer requests:

        return StiAngularViewer.ProcessRequestResult(this);
    }
