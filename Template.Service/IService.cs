using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Service
{
    public interface IService<TEntity>
    {
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Remove(object id);
        bool IsExisted(object id);
        TEntity GetById(object id);
        IList<TEntity> FindBy(IList<IPredicate> predicates);
    }
}
