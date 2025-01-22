using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CheckListAI.Web.Core
{
    public class AddUserToViewDataFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;

            if (controller != null && context.HttpContext.Session.GetString("username") != null)
            {
                controller.ViewData["username"]  = context.HttpContext.Session.GetString("username");
            }

        }
    }
}
