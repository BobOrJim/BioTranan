using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation_API.Middleware
{

    //Ive done core-identity and identityServer 4 before. So when i have the time i want to try
    //Auth0, Okta or AzureAd.
    //However, in the meanwhile a ill try my own middleware


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyMiddlewareAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeyValue = configuration.GetValue<string>("ApiKey");

            
            if (apiKeyValue != apiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
