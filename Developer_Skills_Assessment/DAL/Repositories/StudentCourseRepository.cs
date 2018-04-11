using Developer_Skills_Assessment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.DAL.Repositories
{
    public class StudentCourseRepository : Repository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(SchoolDbContext context)
            : base(context)
        {

        }

        public SchoolDbContext SchoolContext {
            get {
                return Context as SchoolDbContext;
            }
        }

        public IEnumerable<StudentCourse> GetAllByCourseId(int courseId)
        {
            return SchoolContext.StudentCourses.Where(sc => sc.CourseId == courseId);
        }

        public IEnumerable<StudentCourse> GetAllByStudentId(int studentId)
        {
            return SchoolContext.StudentCourses.Where(sc => sc.StudentId == studentId);
        }

        public IEnumerable<StudentCourse> GetAllWithStudentsAndCourses()
        {
            return SchoolContext.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course);
        }
    }
}
