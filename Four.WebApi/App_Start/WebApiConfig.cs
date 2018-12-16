using Four.WebApi.Attributes;
using Four.WebApi.UnityFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace Four.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Filters.Add(new CustomActionFilterAttribute());
            //config.Services.Replace(typeof(IExceptionHandler),new Glo)
            // Web API configuration and services
            //replace Container of Unity
            config.DependencyResolver = new UnityDependencyResolver(UnityContainerFactory.GetContainer());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
