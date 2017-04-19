using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Template.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        TEntity GetById(object id);
        IList<TEntity> FindBy(IList<IPredicate> predicates);
    }
}
