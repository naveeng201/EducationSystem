#region

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Objects;
using System.Transactions;
using ES.MODELS;

#endregion

namespace ES.DAL.repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly ESDataContext _db;

        public UnitOfWork()
        {
           _db = new ESDataContext();
           _db.Configuration.LazyLoadingEnabled = true;
           _db.Configuration.ProxyCreationEnabled = false;

        }

        public void Dispose()
        {

        }
        public void StartTransaction()
        {

            _transaction = new TransactionScope();

        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return Set<T>();
        }
    }
}