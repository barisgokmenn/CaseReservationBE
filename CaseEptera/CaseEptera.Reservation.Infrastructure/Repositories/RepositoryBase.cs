﻿using CaseEptera.Reservation.Domain.Abstract;
using CaseEptera.Reservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly ReservationDbContext _dbContext;
        public RepositoryBase(ReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool reload = false)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);

            if (reload) _dbContext.Entry(entity).Reload();

            return entity;
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, int disableTracking = 0)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking == 1) query = query.AsNoTracking();
            var entity = await query.FirstOrDefaultAsync(predicate);

            return entity;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

        }
        public async Task<IEnumerable<T>> GetListAsync(IQueryable<T> query)
        {
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> objects)
        {
            await _dbContext.Set<T>().AddRangeAsync(objects);
            return objects;
        }
        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
