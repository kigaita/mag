using System;
using System.Web.Mvc;

namespace UwbItContest.Web.Infrastructure
{
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid &&
                filterContext.HttpContext.Request.HttpMethod != "GET")
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = filterContext.ActionDescriptor.ActionName,
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }
        }
    }
}