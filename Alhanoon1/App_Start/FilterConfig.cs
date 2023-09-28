using System.Web;
using System.Web.Mvc;
using Alhanoon1.Areas.Admin.Filters;

namespace Alhanoon1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Authorization());
        }
    }
}