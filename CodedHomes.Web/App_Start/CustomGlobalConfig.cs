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
            // Fixes issue with overly-aggressive validation provider:
            //      http://bit.ly/19jjC6N and http://bit.ly/130EqfT
            config.Services.RemoveAll(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                v => v is InvalidModelValidatorProvider);

            // approach via @encosia at: http://bit.ly/10EEHlQ
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // approach via @John_Papa at: http://jpapa.me/NqC2HH
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ValidationActionFilter());
        }
    }
}