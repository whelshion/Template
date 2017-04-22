using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Template.Repository;

namespace Template.Service
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        protected Service(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }
        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public IList<TEntity> FindBy(IPredicateGroup predicates)
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
