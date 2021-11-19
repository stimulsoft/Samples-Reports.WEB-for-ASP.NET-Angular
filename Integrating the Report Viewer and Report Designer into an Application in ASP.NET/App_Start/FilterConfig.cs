using System.Web;
using System.Web.Mvc;

namespace Integrating_the_Report_Viewer_and_Report_Designer_into_an_Application_in_ASP_NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
