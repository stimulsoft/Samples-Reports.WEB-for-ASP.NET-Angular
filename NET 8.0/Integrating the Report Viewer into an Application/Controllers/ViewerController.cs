﻿using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Angular;

namespace Integrating_the_Report_Viewer_into_an_Application.Controllers
{
    [Controller]
    public class ViewerController : Controller
    {
        static ViewerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        [HttpPost]
        public IActionResult InitViewer()
        {
            var requestParams = StiAngularViewer.GetRequestParams(this);

            var options = new StiAngularViewerOptions();
            options.Actions.GetReport = "GetReport";
            options.Actions.ViewerEvent = "ViewerEvent";
            options.Appearance.ScrollbarsMode = true;

            return StiAngularViewer.ViewerDataResult(requestParams, options);
        }

        [HttpPost]
        public IActionResult GetReport()
        {
            var report = StiReport.CreateNewReport();
            var path = StiAngularHelper.MapPath(this, $"Reports/MasterDetail.mrt");
            report.Load(path);

            return StiAngularViewer.GetReportResult(this, report);
        }

        [HttpPost]
        public IActionResult ViewerEvent()
        {
            return StiAngularViewer.ViewerEventResult(this);
        }
    }
}


