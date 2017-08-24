﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ES.MODELS;
using System.Data.Entity.Validation;

namespace ES.DAL
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal DbContext Database { get { return _unitOfWork.Db; } }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual int Insert(T entity)
        {
            try
            {
                dynamic obj = dbSet.Add(entity);
                this._unitOfWork.Db.SaveChanges();
                return obj.Id;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var exceptionMessage = string.Concat(/*ex.Message*/"Validation failed for one or more entities. ", " The validation errors are : ", string.Join("  ", errorMessages));
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
                this._unitOfWork.Db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var exceptionMessage = string.Concat(/*ex.Message*/"Validation failed for one or more entities. ", " The validation errors are : ", string.Join("  ", errorMessages));
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public int Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dynamic obj = dbSet.Remove(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj.Id;
        }


        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public int SaveChanges()
        {
            return this._unitOfWork.Db.SaveChanges();
        }

        public int Delete(int Id)
        {
            var dbResult = dbSet.Find(Id);
            if (_unitOfWork.Db.Entry(dbResult).State == EntityState.Detached)
            {
                dbSet.Attach(dbResult);
            }
            dynamic obj = dbSet.Remove(dbResult);
            this._unitOfWork.Db.SaveChanges();
            return obj.Id;
        }
    }
}
