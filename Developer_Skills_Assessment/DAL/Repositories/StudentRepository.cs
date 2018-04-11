using Developer_Skills_Assessment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.DAL.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository(SchoolDbContext context)
            : base(context)
        {           
        }

        public SchoolDbContext SchoolContext
        {
            get
            {
                return Context as SchoolDbContext;
            }
        }

        public IEnumerable<Student> GetStudentsByLastName(string lastName)
        {
            return SchoolContext.Students.Where(s => s.LastName.ToLower() == lastName.ToLower());
        }
    }
}
