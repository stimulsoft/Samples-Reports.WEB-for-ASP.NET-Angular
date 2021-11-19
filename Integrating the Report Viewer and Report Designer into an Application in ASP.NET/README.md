# Integrating the Report Viewer into an Application

This example illustrates how use  Angular Viewer with ASP.NET MVC. 

### Installation and running
Use npm to install required modules from ClientApp directory:

    npm install
Run angular server

    ng serve
Run project & navigate to [http://localhost:4200/](http://localhost:4200/)	

### Step by step
  
#### ViewerController.cs
   
    public class ViewerController : Controller
    {
Define AllowCrossSiteJson attribute to allow Cross-Origin Resource Sharing (CORS):

        public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
                base.OnActionExecuting(filterContext);
            }
        }

        [AllowCrossSiteJson]
        public ActionResult InitViewer()
        {
            var requestParams = StiMvcViewer.GetRequestParams();
            var options = new StiAngularViewerOptions();
            options.Actions.ViewerEvent = "ViewerEvent";
            options.Toolbar.ShowDesignButton = true;
            return StiAngularViewer.ViewerDataResult(requestParams, options);
        }
 Define StiAngularViewerOptions and ViewerEvent that will process viewer requests.
 
        [AllowCrossSiteJson]
        public ActionResult ViewerEvent()
        {
            var requestParams = StiAngularViewer.GetRequestParams();

            if (requestParams.Action == StiAction.GetReport)
            {
                return GetReport();
            }

            return StiAngularViewer.ProcessRequestResult();
        }

        public ActionResult GetReport()
        {
            var report = StiReport.CreateNewReport();
            var path = Server.MapPath($"~/Reports/MasterDetail.mrt");
            report.Load(path);

            return StiAngularViewer.GetReportResult(report);
        }
    }


#### DesignerController.cs
In Designer controller define action Get() that call on Designer initialization, where configure Designer options, also create actions that will load, save report & process Designer requests.
   
    public class DesignerController : Controller
	{
Define AllowCrossSiteJson attribute to allow Cross-Origin Resource Sharing (CORS).

		public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
		{
			public override void OnActionExecuting(ActionExecutingContext filterContext)
			{
				filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
				base.OnActionExecuting(filterContext);
			}
		}

		[AllowCrossSiteJson]
		public ActionResult Get()
		{
			var requestParams = StiMvcDesigner.GetRequestParams();

			if (requestParams.Action == StiAction.Undefined)
			{
				var options = new StiMvcDesignerOptions();
				return StiMvcDesigner.GetAngularScriptsResult(requestParams, options);
			}

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

			return StiMvcDesigner.ProcessRequestResult();
		}

		public ActionResult GetReport()
		{
			var report = StiReport.CreateNewReport();
			var path = Server.MapPath("~/Reports/MasterDetail.mrt");
			report.Load(path);

			return StiMvcDesigner.GetReportResult(report);
		}

		public ActionResult SaveReport()
		{
			var report = StiMvcDesigner.GetReportObject();

			var path = Server.MapPath("~/Reports/MasterDetail.mrt");
			report.Save(path);

			return StiMvcDesigner.SaveReportResult();
		}
	}


