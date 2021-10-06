/* Name: Pushpa Dhakal, Course: C# .NET
Code Louisville @ Bellarmine University, Mondays 6:00PM to 8:00PM 
Spring 2020
Instructor: Steve England
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CollegeListOfAmerica
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
                routeTemplate: "api/{controller}/{action}/{id}",
                //id is optional.
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
