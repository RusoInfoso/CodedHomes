using System.Web;
using System.Web.Mvc;
using CodedHomes.Web.Filters;

namespace CodedHomes.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}