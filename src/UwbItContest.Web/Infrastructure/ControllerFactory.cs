namespace UwbItContest.Web.Infrastructure
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName) => 
            typeof(ControllerFactory)
            .Assembly
            .GetType("UwbItContest.Web.Features." + controllerName + ".UiController");
    }
}