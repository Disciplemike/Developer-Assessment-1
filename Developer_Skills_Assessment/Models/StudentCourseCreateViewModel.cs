using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.Models
{
    public class StudentCourseCreateViewModel
    {
        public int SelectedStudentId { get; set; }
        public int SelectedCourseId { get; set; }

    }
}
