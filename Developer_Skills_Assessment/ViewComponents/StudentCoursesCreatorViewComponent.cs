using Developer_Skills_Assessment.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.ViewComponents
{
    public class StudentCoursesCreatorViewComponent : ViewComponent
    {
        private IUnitOfWork _unitOfWork;

        public StudentCoursesCreatorViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
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
    }
}
