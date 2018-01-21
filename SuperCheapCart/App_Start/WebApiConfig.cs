using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace myloanworldService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //var ourWebsiteOrigin = ConfigurationManager.AppSettings["allowedDomain"].ToString();
            //This above method does't work because of slashes in the url. need to find a way out
            //config.EnableCors(new EnableCorsAttribute(origins: ourWebsiteOrigin, headers: "POST, GET, OPTIONS, DELETE, PUT", methods: "*"));
            config.EnableCors(new EnableCorsAttribute(origins: "*", headers: "*", methods: "*"));
        }
    }
}
