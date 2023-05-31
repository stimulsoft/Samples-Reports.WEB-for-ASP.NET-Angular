using Stimulsoft.Report;
using Stimulsoft.Report.Angular;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrating_the_Report_Components_in_ASP_NET_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("The angular server is running. Please follow the link <a href='http://localhost:4200/'>http://localhost:4200/</a> to open the client side.");
        }
    }
}