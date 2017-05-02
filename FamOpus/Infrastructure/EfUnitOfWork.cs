using System;
using FamOpus.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace FamOpus.Infrastructure
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbContextTransaction _transaction;

        public FamOpusContext Context { get; }

        public EfUnitOfWork()
        {
            Context = new FamOpusContext();
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            Context?.Dispose();
        }
    }
}