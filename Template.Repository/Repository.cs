﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DapperExtensions;
using System.Reflection;

namespace Template.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            using (var dbcontext = new DbFactory().CreateSqlConnection())
            {
                return dbcontext.Insert(entity);
            }
        }

        public IList<TEntity> FindBy(IPredicateGroup predicates)
        {
            using (var dbcontext = new DbFactory().CreateSqlConnection())
            {
                return dbcontext.GetList<TEntity>(predicates).ToList();
            }
        }

        public TEntity GetById(object id)
        {
            using (var dbcontext = new DbFactory().CreateSqlConnection())
            {
                return dbcontext.Get<TEntity>(id);
            }
        }

        public bool Remove(TEntity entity)
        {
            using (var dbcontext = new DbFactory().CreateSqlConnection())
            {
                return dbcontext.Delete(entity);
            }
        }

        public bool Update(TEntity entity)
        {
            using (var dbcontext = new DbFactory().CreateSqlConnection())
            {
                return dbcontext.Update(entity);
            }
        }
    }
}