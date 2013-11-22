using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using CodedHomes.Web.Filters;

namespace CodedHomes.Web
{
    public static class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}