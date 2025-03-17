using System.Web.Mvc;

namespace Integrating_the_Report_Components_in_ASP_NET_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("Content");
        }
    }
}