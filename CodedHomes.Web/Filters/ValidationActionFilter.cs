using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.Web.Http.Filters;
using System.Net.Http;

namespace CodedHomes.Web.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if(!modelState.IsValid)
            {
                var errors = new JObject();

                foreach(var key in modelState.Keys)
                {
                    var state = modelState[key];

                    if(state.Errors.Any())
                    {
                        errors[key] = state.Errors.First().ErrorMessage;
                    }
                }

                actionContext.Response = actionContext.Request.CreateResponse<JObject>(HttpStatusCode.BadRequest, errors);
            }
            //base.OnActionExecuting(actionContext);
        }
    }
}