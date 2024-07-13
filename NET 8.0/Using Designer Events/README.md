# Using Designer Events

This example illustrates how to use Angular Designer component.
When click  Design button in Viewer, Viewer close & shows Designer:

### Step by step
  
#### app.module.ts
   
    import { BrowserModule } from  '@angular/platform-browser';
    import { NgModule } from  '@angular/core';
    import { StimulsoftViewerModule } from  'stimulsoft-viewer-angular';
Import StimulsoftDesignerModule:

    import { StimulsoftDesignerModule } from  'stimulsoft-designer-angular';
    import { AppComponent } from  './app.component';
    
    @NgModule({
      declarations: [
        AppComponent
      ],
      imports: [
        BrowserModule,
        StimulsoftViewerModule,
   Add StimulsoftDesignerModule to imports:
   
        StimulsoftDesignerModule
      ],
      providers: [],
      bootstrap: [AppComponent]
    })

#### app.component.html
   Show viewer or designer at once.
   
    <stimulsoft-viewer-angular *ngIf="showViewer"
      [requestUrl]="'http://localhost:60801/Viewer/{action}'"
      [action]="'InitViewer'"
      [height]="'600px'"
When user click Design button (design) event occurs: 

      (design)="showViewer = false">
    </stimulsoft-viewer-angular>
    
    <stimulsoft-designer-angular *ngIf="!showViewer" 
Define URL to designer controller: 

      [requestUrl]="'http://localhost:60801/api/designer'"
      [height]="'600px'"
      [width]="'100%'">
Content that show while designer loading:

      Loading designer...
    </stimulsoft-designer-angular>

### DesignerController.cs

    namespace AngularViewer.Controllers
    {
	  [Produces("application/json")]
	  [Route("api/designer")]
	  public  class  DesignerController : Controller
	  {
	  [HttpGet]
	  public IActionResult Get()
	  {

Setting the required options on the server side
	
	    var requestParams = StiNetCoreDesigner.GetRequestParams(this);
	    if (requestParams.Action == StiAction.Undefined)
	    {
	      var options = new StiNetCoreDesignerOptions();
	      return StiNetCoreDesigner.GetAngularScriptsResult(requestParams, options);
	    }
	    return StiNetCoreDesigner.ProcessRequestResult(this);
	  }
	  
	  [HttpPost]
	  public IActionResult Post()
	  {
	    var requestParams = StiNetCoreDesigner.GetRequestParams(this);
	    if (requestParams.Component == StiComponentType.Designer)
	    {
	      switch (requestParams.Action)
	      {
	        case StiAction.GetReport:
	          return GetReport();
	        
	        case StiAction.SaveReport:
	          return SaveReport();
	      }
	    }
	    return StiNetCoreDesigner.ProcessRequestResult(this);
	  }
Action on load report:

	  public IActionResult GetReport()
	  {
	    var report = StiReport.CreateNewReport();
	    var path = StiNetCoreHelper.MapPath(this, "Reports/MasterDetail.mrt");
	    report.Load(path);
	    return StiNetCoreDesigner.GetReportResult(this, report);
	  }
Action on save report:
	  
	  public IActionResult SaveReport()
	  {
	    var report = StiNetCoreDesigner.GetReportObject(this);
	    var path = StiNetCoreHelper.MapPath(this, "Reports/MasterDetail.mrt");
	    report.Save(path);
	    return StiNetCoreDesigner.SaveReportResult(this);
	  }
	}

### ViewerController.cs

    public IActionResult InitViewer()
    {
      var requestParams = StiAngularViewer.GetRequestParams(this);
      var options = new StiAngularViewerOptions();
 Enable Design button in viewer options:
 
      options.Toolbar.ShowDesignButton = true;
      options.Actions.ViewerEvent = "ViewerEvent";
      return StiAngularViewer.ViewerDataResult(requestParams, options);
    }
