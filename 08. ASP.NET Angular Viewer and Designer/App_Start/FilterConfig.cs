using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Angular_Viewer_and_Designer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
