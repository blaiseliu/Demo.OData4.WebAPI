using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using OData4.Models;

namespace OData4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapODataServiceRoute("odata", "odata", model: GetModel()); 
        }

        private static Microsoft.OData.Edm.IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<CourseViewModel>("Courses");
            //EntitySetConfiguration<CourseViewModel> courses = builder.EntitySet<CourseViewModel>("Courses");

            return builder.GetEdmModel();
        }
    }
}
