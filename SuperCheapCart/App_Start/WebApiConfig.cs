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
            var ourWebsiteOrigin = ConfigurationManager.AppSettings["Environment"].ToString();
            if (ourWebsiteOrigin == "local")
            {
                config.EnableCors(new EnableCorsAttribute(origins: @"http://localhost:53972", headers: "*", methods: "*"));
            }else if (ourWebsiteOrigin == "live")
            {
                config.EnableCors(new EnableCorsAttribute(origins: @"http://myloanworld.com", headers: "*", methods: "*"));
            }else if (ourWebsiteOrigin == "localIIS")
            {
                config.EnableCors(new EnableCorsAttribute(origins: @"http://localhost", headers: "*", methods: "*"));
            }
        }
    }
}
