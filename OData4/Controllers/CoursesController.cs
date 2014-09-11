using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using OData4.Models;

namespace OData4.Controllers
{
    public class CoursesController:ODataController
    {
        [EnableQuery]
        public IHttpActionResult Get()
        {
            var courses = GetCourses();
            return Ok(courses);
        }

        private static IEnumerable<CourseViewModel> GetCourses()
        {
            var locations = new[] {"School", "Office Meeting Room", "Auditorium"};
            var instructors = new[] {"Charlie Brown", "Linus van Pelt", "Lucy van Pelt"};


            return (from l in locations 
                    from i in instructors 
                    select new CourseViewModel(l, i))
                    .ToList();
        }
    }
}