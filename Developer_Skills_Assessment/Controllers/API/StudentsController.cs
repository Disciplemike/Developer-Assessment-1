using Developer_Skills_Assessment.DAL;
using Developer_Skills_Assessment.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class StudentsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get()
        {
            var data = _unitOfWork.Students.GetAll();
            return Json(data);
        }

        public IActionResult Find(int id)
        {
            //Implement code to retrieve student here

            return Json(new { }); //Update Return to include the student
        }

        public IActionResult ByLastName(string lastName = "")
        {
            var data = new List<Students>();
            if (!String.IsNullOrWhiteSpace(lastName))
            {
                data = _unitOfWork.Students.GetStudentsByLastName(lastName).ToList();
                return Json(data);
            }
            return Json(data);
        }
    }
}
