using Developer_Skills_Assessment.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.Controllers.API
{
    public class CoursesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get()
        {
            var data = _unitOfWork.Courses.GetAll();
            return Json(data);
        }
    }
}
