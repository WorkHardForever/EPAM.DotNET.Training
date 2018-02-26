using System;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        //Rollback
    }
}