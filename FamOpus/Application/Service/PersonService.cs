using System;
using FamOpus.Domain.Aggregate;
using FamOpus.Domain.Enumeration;
using FamOpus.Domain.Repository;

namespace FamOpus.Application.Service
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void DeletePerson(Person person)
        {
            _personRepository.Delete(person);
            _personRepository.SaveChanges();
        }

        public void CreatePerson(string firstName, string lastName, string middleName, Gender gender, DateTime dateOfBirth)
        {
            var person = new Person(firstName, lastName, middleName, gender, dateOfBirth);

            _personRepository.Create(person);
            _personRepository.SaveChanges();
        }
    }
}