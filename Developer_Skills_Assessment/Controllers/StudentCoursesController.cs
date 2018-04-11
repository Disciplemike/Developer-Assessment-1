using Developer_Skills_Assessment.DAL;
using Developer_Skills_Assessment.DAL.Entities;
using Developer_Skills_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.Controllers
{
    public class StudentCoursesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public StudentCoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var model = _unitOfWork.StudentCourses
                .GetAllWithStudentsAndCourses()
                .Select(sc => new StudentCourseViewModel()
                {
                    CourseTitle = sc.Course.Title,
                    StudentFirstName = sc.Student.FirstName,
                    StudentLastName = sc.Student.LastName
                });
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["Courses"] = new SelectList(_unitOfWork.Courses.GetAll(), "Id", "Title");
            ViewData["Students"] = _unitOfWork.Students
                .GetAll()
                .Select(s => new SelectListItem()
                {
                    Value = $"{s.Id}",
                    Text = $"{s.LastName},{s.FirstName}"
                });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCourseCreateViewModel model)
        {
            var course = _unitOfWork.Courses.Find(model.SelectedCourseId);
            var student = _unitOfWork.Students.Find(model.SelectedStudentId);
            if(course != null && student != null)
            {
                if (_unitOfWork.StudentCourses.Find(student.Id, course.Id) == null)
                {
                    _unitOfWork.StudentCourses.Add(new StudentCourse()
                    {
                        Student = student,
                        Course = course
                    });
                    _unitOfWork.Complete();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
