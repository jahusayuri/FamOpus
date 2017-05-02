using System;
using System.Linq;
using FamOpus.Application.Service;
using FamOpus.Domain.Enumeration;
using FamOpus.Infrastructure;
using FamOpus.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FamOpus.Test.Application.Test
{
    public class EmployeeServiceTest
    {
        public EmployeeServiceTest()
        {
        }

        [Fact]
        public void IsPersonAdded()
        {
            var firstName = "Jahusa";
            var middleName = "Manigbas";
            var lastName = "Requioma";
            var gender = Gender.Male;
            var dateOfBirth = DateTime.Parse("05/21/1996");

            using (var unitOfWork = new EfUnitOfWork())
            {
                var personRepository = new EfPersonRepository(unitOfWork);
                var personService = new PersonService(personRepository);

                personService.CreatePerson(firstName, lastName, middleName, gender, dateOfBirth);
            }

            using (var unitOfWork = new EfUnitOfWork())
            {
                var personRepository = new EfPersonRepository(unitOfWork);

                var persons = personRepository.FindAll();

                var person = persons.First();

                Assert.Equal(firstName, person.FirstName);
                Assert.Equal(middleName, person.MiddleName);
                Assert.Equal(lastName, person.LastName);
                Assert.Equal(gender, person.Gender);
                Assert.Equal(dateOfBirth, person.DateOfBirth);

                personRepository.Delete(person);

                Assert.Equal(EntityState.Deleted, unitOfWork.Context.Entry(person).State);

                personRepository.SaveChanges();

                Assert.Equal(EntityState.Detached, unitOfWork.Context.Entry(person).State);
            }

        }
    }
}