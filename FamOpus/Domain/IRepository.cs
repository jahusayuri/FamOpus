using System;
using System.Collections.Generic;

namespace FamOpus.Domain
{
    public interface IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid Id);
        IEnumerable<TEntity> FindAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}