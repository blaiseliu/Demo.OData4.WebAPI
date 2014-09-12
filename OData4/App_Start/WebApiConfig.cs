using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using OData4.Models;
using RouteParameter = System.Web.Http.RouteParameter;

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

            config.MapODataServiceRoute("odata", "odata/v1", model: GetModel()); 
        }

        private static IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<CourseViewModel>("Courses");
            return builder.GetEdmModel();
        }
    }
}
