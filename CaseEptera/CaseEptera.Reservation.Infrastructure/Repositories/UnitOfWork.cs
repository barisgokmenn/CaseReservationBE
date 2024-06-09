using CaseEptera.Reservation.Domain.Abstract;
using CaseEptera.Reservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ReservationDbContext _dbContext;
        private IDbContextTransaction _trans;
        public UnitOfWork(ReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
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
        public void CreateTransaction()
        {
            _trans = _dbContext.Database.BeginTransaction();
        }
        public void CreateTransaction(IsolationLevel level)
        {
            _trans = _dbContext.Database.BeginTransaction(level);
        }
        public void Commit()
        {
            _trans.Commit();
        }
        public void Rollback()
        {
            _trans.Rollback();
            _trans.Dispose();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public List<T> Query<T>(string query, object parameters)
        {
            return _dbContext.SQLQuery<T>(query, parameters).ToList();
        }
        public List<T> Query<T>(string query)
        {

            return _dbContext.SQLQuery<T>(query).ToList();
        }
        public int Execute(string query, object parameters)
        {
            return _dbContext.Execute(query, parameters);
        }
    }
}
