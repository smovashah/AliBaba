using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    [ApiController]
    [Route("v3/Repository")]
    public class RepositoryApi<TEntity> : ControllerBase where TEntity : class
    {
        private readonly alibabaEntities _db;
        private readonly DbSet<TEntity> _dbset;

        public RepositoryApi(alibabaEntities alibaba)
        {
            _db = alibaba;
            _dbset = _db.Set<TEntity>();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TEntity>> GetById([FromRoute] Object id)
        {
            var item = _dbset.Find(id);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            IQueryable<TEntity> query = _dbset;
            return Ok(query.ToList());
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<bool>> Insert([FromBody] TEntity entity)
        {
            try
            {
                _dbset.Add(entity);
                _db.SaveChanges();

                return Ok(true);
            }
            catch (System.Exception)
            {
                return Ok(false);
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete([FromBody] TEntity entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                    _db.Attach(entity);
                _dbset.Remove(entity);
                _db.SaveChanges();

                return Ok(true);
            }
            catch (System.Exception)
            {
                return Ok(false);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<bool>> Update([FromBody] TEntity entity)
        {
            try
            {
                _db.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();

                return Ok(true);
            }
            catch (System.Exception)
            {
                return Ok(false);
            }
        }

    }
}