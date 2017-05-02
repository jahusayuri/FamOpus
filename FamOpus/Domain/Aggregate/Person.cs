using System;
using System.Collections.Generic;
using FamOpus.Domain.Entity;
using FamOpus.Domain.Enumeration;

namespace FamOpus.Domain.Aggregate
{
    public class Person : IAggregateRoot
    {

        protected Person()
        {
            // required for Entity Framework
        }

        public Person(string firstName, string lastName, string middleName, Gender gender, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        public Guid Id { get; set; }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string MiddleName { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public Gender Gender { get; protected set; }

        public IEnumerable<Task> Tasks { get; protected set; }

        #region Calculated Properties

        public string Name => LastName + ", " + FirstName + " " + MiddleName;
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        #endregion
    }
}