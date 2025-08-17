using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoffeShop.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}