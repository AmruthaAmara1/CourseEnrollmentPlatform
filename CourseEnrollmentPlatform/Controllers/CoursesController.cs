using CourseEnrollmentPlatform.Models;
using System;
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

        // GET: Courses/Details/<id>
        public ActionResult Details(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            return View(course);
        }

        public ActionResult New()
        {
            var viewModel = new CourseFormViewModel()
            {
                Id = 0 
            };
            return View("CourseForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CourseFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CourseForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var course = new Course
                {
                    Name = viewModel.Name,
                    Instructor = viewModel.Instructor,
                    StartDate = viewModel.StartDate ?? DateTime.Now, // safeguard
                    DurationWeeks = viewModel.DurationWeeks ?? 1     // safeguard
                };

                _context.Courses.Add(course);
                System.Diagnostics.Debug.WriteLine("✔ Course ADDED: " + course.Name);
            }
            else
            {
                var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == viewModel.Id);
                if (courseInDb == null)
                    return HttpNotFound();

                courseInDb.Name = viewModel.Name;
                courseInDb.Instructor = viewModel.Instructor;
                courseInDb.StartDate = viewModel.StartDate ?? DateTime.Now;
                courseInDb.DurationWeeks = viewModel.DurationWeeks ?? 1;

                System.Diagnostics.Debug.WriteLine("✔ Course UPDATED: " + courseInDb.Name);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            var viewModel = new CourseFormViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Instructor = course.Instructor,
                StartDate = course.StartDate,
                DurationWeeks = course.DurationWeeks
            };

            return View("CourseForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
