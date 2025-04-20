using CourseEnrollmentPlatform.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseEnrollmentPlatform.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Courses
        public ActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }
    }
}
