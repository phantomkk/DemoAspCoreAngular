
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.DataAccessObjects
{
    public interface IUnitOfWork<out TContext>: IDisposable where TContext: DbContext 
    {
        TContext Context { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
