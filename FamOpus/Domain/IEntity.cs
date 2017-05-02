using System;

namespace FamOpus.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}