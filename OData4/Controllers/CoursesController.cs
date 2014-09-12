using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using OData4.Models;

namespace OData4.Controllers
{
    [ODataRoutePrefix("Courses")]
    public class CoursesODataController:ODataController
    {
        [EnableQuery]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            var courses = GetCourses();
            return Ok(courses);
        }

        private static IQueryable<CourseViewModel> GetCourses()
        {
            var locations = new[] {"School", "Office Meeting Room", "Auditorium"};
            var instructors = new[] {"Charlie Brown", "Linus van Pelt", "Lucy van Pelt"};


            return (from l in locations
                from i in instructors
                select new CourseViewModel(l, i))
                .AsQueryable();
        }
    }
}