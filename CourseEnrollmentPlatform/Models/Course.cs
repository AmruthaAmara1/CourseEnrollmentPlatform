using System;
namespace CourseEnrollmentPlatform.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructor { get; set; }

        public DateTime StartDate { get; set; }

        public int DurationWeeks { get; set; }
    }
}