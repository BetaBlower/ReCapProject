﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        void Add(T entity);
        void Uppdate(T entity);
        void Delete(T entity);
    }
}