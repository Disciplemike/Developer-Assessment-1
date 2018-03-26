using Developer_Skills_Assessment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.DAL.Repositories
{
    public interface IStudentRepository : IRepository<Students>
    {
        IEnumerable<Students> GetStudentsByLastName(string lastName);
    }
}
