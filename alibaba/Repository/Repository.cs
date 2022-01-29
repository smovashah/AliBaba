using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository
{

    public class Repository<TEntity> where TEntity : class
    {
        private readonly alibabaEntities _db;
        private readonly DbSet<TEntity> _dbset;

        public Repository(alibabaEntities alibaba)
        {
            _db = alibaba;
            _dbset = _db.Set<TEntity>();
        }

        public TEntity GetById(Object id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbset;
            return query.ToList();
        }

        public virtual bool Insert(TEntity entity)
        {
            try
            {
                _dbset.Add(entity);
                _db.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public virtual bool Delete(TEntity entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                    _db.Attach(entity);
                _dbset.Remove(entity);
                _db.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public virtual bool Update(TEntity entity)
        {
            try
            {
                _db.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

    }
}