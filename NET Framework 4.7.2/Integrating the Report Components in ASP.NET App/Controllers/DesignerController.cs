using System.Web.UI.WebControls;

namespace Integrating_the_Report_Components_in_ASP_NET_App.Controllers
{
    public class DesignerController : Controller
    {
        static DesignerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

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
                options.Height = Unit.Percentage(100);
                return StiMvcDesigner.GetAngularScriptsResult(requestParams, options);
            }

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
}