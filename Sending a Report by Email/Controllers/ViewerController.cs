using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stimulsoft.Report;
using Stimulsoft.Report.Angular;
using Stimulsoft.Report.Web;

namespace Sending_a_Report_by_Email.Controllers
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
            options.Actions.EmailReport = "EmailReport";
            options.Actions.ViewerEvent = "ViewerEvent";
            options.Appearance.ScrollbarsMode = true;
            options.Toolbar.ShowSendEmailButton = true;

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
        public IActionResult EmailReport()
        {
            StiEmailOptions options = StiAngularViewer.GetEmailOptions(this);
            // Passed from the viewer, can be checked and changed
            // options.AddressTo = "";
            // options.Subject = "";
            // options.Body = "";
            // Should be filled here
            options.AddressFrom = "admin_address@test.com";
            options.Host = "smtp.test.com";
            options.Port = 465;
            options.UserName = "admin_address@test.com";
            options.Password = "admin_password";
            // options.CC.Add("email@test.com");
            // options.BCC.Add("email@test.com");
            // options.EnableSsl = true;

            return StiAngularViewer.EmailReportResult(this, options);
        }

        [HttpPost]
        public IActionResult ViewerEvent()
        {
            return StiAngularViewer.ViewerEventResult(this);
        }
    }
}


