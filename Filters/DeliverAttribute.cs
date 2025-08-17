using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Filters
{
    public class DeliverAttribut : ActionFilterAttribute
    {
        private readonly AppDbContext _context;

        public DeliverAttribut(AppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("Email");
            var findUser = _context.users.Where(u => u.Email == email && u.Role == "deliver").FirstOrDefault();

            if (string.IsNullOrEmpty(email) || findUser == null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}