using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DomainModels.Abstraction;

namespace Infrastructure.Abstraction
{
    internal interface IRepository<T> where T : class, IBaseModel
    {
        bool Add(T entity);
        bool Add(IEnumerable<T> entytiesAsyncEnumerable);
        bool Delete(T entity);
		bool Delete(IEnumerable<T> entytiesAsyncEnumerable);
        T GetById(Guid id);
        T GetByName(String name);
        IQueryable<T> GetAll();
        bool Update(T entity);
		bool Update(IEnumerable<T> entytiesAsyncEnumerable);
    }
}
