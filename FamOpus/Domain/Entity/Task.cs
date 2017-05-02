using System;
using System.Collections.Generic;
using FamOpus.Domain.Aggregate;

namespace FamOpus.Domain.Entity
{
    public class Task : IEntity
    {
        protected Task()
        {

        }

        public  Guid Id { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public IEnumerable<Person> Persons { get; protected set; }
    }
}