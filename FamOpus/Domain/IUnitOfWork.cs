﻿namespace FamOpus.Domain
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}