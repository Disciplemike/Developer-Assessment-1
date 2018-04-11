using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer_Skills_Assessment.DAL.Repositories;

namespace Developer_Skills_Assessment.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolDbContext _context;

        public UnitOfWork(SchoolDbContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Courses = new CourseRepository(_context);
            StudentCourses = new StudentCourseRepository(_context);
        }
        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IStudentCourseRepository StudentCourses { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
