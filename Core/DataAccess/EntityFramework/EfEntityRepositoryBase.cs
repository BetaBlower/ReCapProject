using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<IEntity> 
        where TEntity : class ,IEntity,new()
        where TContext :DbContext,new()

    {
        public void Add(IEntity entity)
        {
            using (TContext tContext = new  TContext())
            {
                var AddEntity = tContext.Entry(entity);
                AddEntity.State = EntityState.Added;
                tContext.SaveChanges();
            }
        }

        public void Delete(IEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                var DeleteEntity = tContext.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                tContext.SaveChanges();
            }
        }

        public IEntity Get(Expression<Func<IEntity, bool>> filter)
        {
            using (TContext tContext = new TContext())
            {
                return tContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<IEntity> GetAll(Expression<Func<IEntity, bool>> filter = null)
        {
            using (TContext tContext = new TContext())
            {
                return filter == null
                    ? tContext.Set<TEntity>().ToList()
                    : tContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Uppdate(IEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                var UppdatedEntity = tContext.Entry(entity);
                UppdatedEntity.State = EntityState.Modified;
                tContext.SaveChanges();
            }
        }
    }
}
