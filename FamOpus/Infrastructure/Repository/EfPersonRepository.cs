using System;
using System.Collections.Generic;
using System.Linq;
using FamOpus.Domain.Aggregate;
using FamOpus.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FamOpus.Infrastructure.Repository
{
    public class EfPersonRepository : IPersonRepository
    {

        private readonly EfUnitOfWork _unitOfWork;

        public EfPersonRepository(EfUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Person FindById(Guid id)
        {
            return _unitOfWork.Context.Persons.Find(id);
        }

        public IEnumerable<Person> FindAll()
        {
            return _unitOfWork.Context.Persons.ToList();
        }

        public void Create(Person entity)
        {
             _unitOfWork.Context.Persons.Add(entity);
        }

        public void Update(Person entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Person entity)
        {
            _unitOfWork.Context.Persons.Remove(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Context.SaveChanges();
            _unitOfWork.Commit();
        }
    }
}