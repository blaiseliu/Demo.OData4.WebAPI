using System;

namespace OData4.Models
{
    public class CourseViewModel
    {
        public CourseViewModel(string location, string instructor, bool isOpen=true)
        {
            Id = Guid.NewGuid();
            Location = location;
            Instructor = instructor;
            IsOpen = isOpen;
        }

        public CourseViewModel()
        {
            
        }
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string Instructor { get; set; }
        public bool IsOpen { get; set; }
    }
}