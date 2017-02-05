using System;
using System.Data;
using System.Data.Entity;
namespace ES.DAL.repositories
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Call this to commit the unit of work
        /// </summary>
        void Commit();

        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }

        /// <summary>
        /// Starts a transaction on this unit of work
        /// </summary>
        void StartTransaction();

        IDbSet<T> Set<T>() where T : class;
    }
}