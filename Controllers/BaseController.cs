using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace ElectricInventorySystem.Controllers
{
    public class BaseController : Controller
    {
        protected string CurrentRole => HttpContext.Session.GetString("Role") ?? "";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path.Value;

            // Allow login page
            if (path.Contains("/Account/Login"))
            {
                base.OnActionExecuting(context);
                return;
            }

            // Not logged in
            if (string.IsNullOrEmpty(CurrentRole))
            {
                context.Result = RedirectToAction("Login", "Account");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}