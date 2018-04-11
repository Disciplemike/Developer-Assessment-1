using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Skills_Assessment.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id);
        TEntity Find(params Object[] keyValues);
        IEnumerable<TEntity> GetAll();


        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
