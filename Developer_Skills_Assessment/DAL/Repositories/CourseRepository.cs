using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer_Skills_Assessment.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Developer_Skills_Assessment.DAL.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {


        public CourseRepository(SchoolDbContext context) : base(context)
        {
        }

        public SchoolDbContext SchoolContext
        {
            get
            {
                return Context as SchoolDbContext;
            }
        
        }

        public IEnumerable<Course> GetCoursesByName(string courseName)
        {
            return SchoolContext
                .Courses
                .Where(c => c.Title.ToLower().Contains(courseName.ToLower()));
        }
    }
}
