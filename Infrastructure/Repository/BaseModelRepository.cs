using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DomainModels.Abstraction;
using Infrastructure.Abstraction;

namespace Infrastructure.Repository
{
    public class BaseModelRepository<T> : IRepository<T> where T : IBaseModel, IDisposable
    {
        private readonly AuctionDb.AuctionDb dbContext;

        public BaseModelRepository()
        {
            dbContext = AuctionDb.AuctionDb.Create();
        }

        public bool Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("BaseModelRepository" + typeof(T));

            //dbContext.StatusModels.AddOrUpdate(( fIBaseModel)entity);
            return false;
        }

        public bool Add(IDbAsyncEnumerable<T> entytiesAsyncEnumerable)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IDbAsyncEnumerable<T> entytiesAsyncEnumerable)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(IDbAsyncEnumerable<T> entytiesAsyncEnumerable)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
