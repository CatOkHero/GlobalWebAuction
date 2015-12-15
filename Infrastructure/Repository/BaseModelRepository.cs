using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DomainModels.Abstraction;
using Infrastructure.Abstraction;

namespace Infrastructure.Repository
{
	public class BaseModelRepository<T> : IDisposable, IRepository<T> where T : class, IBaseModel 
    {
        protected AuctionDb.AuctionDb DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public BaseModelRepository(AuctionDb.AuctionDb dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
            DbContext.SaveChanges();
        }

        public bool Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("BaseModelRepository" + typeof (T));

	        try
	        {
		        DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
				if (dbEntityEntry.State != EntityState.Detached)
				{
					dbEntityEntry.State = EntityState.Added;
					return true;
				}
	        }
	        catch (Exception ex)
	        {
		        return false;
	        }

            try
            {
                DbSet.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Add(IEnumerable<T> entytiesAsyncEnumerable)
        {
            foreach (var entity in entytiesAsyncEnumerable)
            {
                try
                {
                    Add(entity);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool Delete(T entity)
        {
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if (dbEntityEntry.State != EntityState.Deleted)
			{
				dbEntityEntry.State = EntityState.Deleted;
				return true;
			}
			else
			{
				DbSet.Attach(entity);
				DbSet.Remove(entity);
				return true;
			}
        }

		public bool Delete(IEnumerable<T> entytiesAsyncEnumerable)
        {
			try
			{
				if (entytiesAsyncEnumerable.Any(entity => !Delete(entity)))
				{
					return false;
				}

				return true;
			}
			catch (Exception)
			{
				return false;
			}
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetByName(string name)
        {
			throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

		public bool Update(IEnumerable<T> entytiesAsyncEnumerable)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
	        DbContext.SaveChanges();
            DbContext.Dispose();
        }
    }
}
