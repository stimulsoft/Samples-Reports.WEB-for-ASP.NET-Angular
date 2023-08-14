using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Angular;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using Stimulsoft.System.Web.UI.WebControls;

namespace Designer.Controllers
{
    [Produces("application/json")]
    [Route("api/designer")]
    public class DesignerController : Controller
    {
        static DesignerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Setting the required options on the server side
            var requestParams = StiAngularDesigner.GetRequestParams(this);
            if (requestParams.Action == StiAction.Undefined)
            {
                StiAngularDesignerOptions options = new StiAngularDesignerOptions();
                options.Height = Unit.Percentage(100);
                return StiAngularDesigner.DesignerDataResult(requestParams, options);
            }

            return StiAngularDesigner.ProcessRequestResult(this);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var requestParams = StiAngularDesigner.GetRequestParams(this);
            if (requestParams.ComponentType == StiComponentType.Designer)
            {
                switch (requestParams.Action)
                {
                    case StiAction.GetReport:
                        return GetReport();

                    case StiAction.SaveReport:
                        return SaveReport();
                }
            }

            return StiAngularDesigner.ProcessRequestResult(this);
        }

        public IActionResult GetReport()
        {
            var report = StiReport.CreateNewReport();
            var path = StiAngularHelper.MapPath(this, "Reports/MasterDetail.mrt");
            report.Load(path);

            return StiAngularDesigner.GetReportResult(this, report);
        }

        public IActionResult SaveReport()
        {
            var report = StiAngularDesigner.GetReportObject(this);

            var path = StiAngularHelper.MapPath(this, "Reports/MasterDetail.mrt");
            report.Save(path);

            return StiAngularDesigner.SaveReportResult(this);
        }
    }
}
