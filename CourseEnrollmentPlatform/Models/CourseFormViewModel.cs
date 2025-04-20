using System;
using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentPlatform.Models
{
    public class CourseFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructor { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Duration (weeks)")]
        [Required]
        [Range(1, 52)]
        public int? DurationWeeks { get; set; }

        public string Title => Id != 0 ? "Edit Course" : "New Course";
    }
}
