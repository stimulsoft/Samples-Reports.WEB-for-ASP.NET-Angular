using System.Web.Mvc;

namespace Integrating_the_Report_Components_in_ASP_NET_App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
