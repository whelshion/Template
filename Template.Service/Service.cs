using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Template.Service
{
    public abstract class Service<TEntity> : IService<TEntity>
    {
        public int Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> FindBy(IList<IPredicate> predicates)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool IsExisted(object id)
        {
            throw new NotImplementedException();
        }

        public int Remove(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
