using Developer_Skills_Assessment.DAL;
using Developer_Skills_Assessment.DAL.Entities;
using Developer_Skills_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.Controllers
{
    public class StudentsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var model = _unitOfWork.Students
                .GetAll()
                .Select(s => new StudentViewModel() { FirstName = s.FirstName, LastName = s.LastName });
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                try
                {
                    _unitOfWork.Students.Add(student);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                catch
                {
                    throw new Exception();
                }
            }
            return RedirectToAction("Create", model);
        }
       
        public IActionResult CreateResults(bool isSuccess)
        {
            return Json(new { success = isSuccess });
        }
    }
}
