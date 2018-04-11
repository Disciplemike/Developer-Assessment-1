using Developer_Skills_Assessment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.DAL.Repositories
{
    public interface IStudentCourseRepository : IRepository<StudentCourse>
    {
        IEnumerable<StudentCourse> GetAllByStudentId(int studentId);
        IEnumerable<StudentCourse> GetAllByCourseId(int courseId);

        IEnumerable<StudentCourse> GetAllWithStudentsAndCourses();

    }
}
