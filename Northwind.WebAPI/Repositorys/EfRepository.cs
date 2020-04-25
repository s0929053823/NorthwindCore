using Microsoft.EntityFrameworkCore;
using Northwind.DbModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebAPI.Repositorys
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly NorthwindContext _context;

        public EfRepository(NorthwindContext northwindContext)
        {
            _context = northwindContext;


            if (northwindContext != null)
            {
                _dbSet = northwindContext.Set<TEntity>();
            }
            else throw new Exception("DbContext is Null");
        }


        public IEnumerable<TEntity> GetAll()
        {
           return _dbSet.ToArray();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToArrayAsync();
        }

        public void Delete(object id)
        {

            var orders = _dbSet.Find(id);
            if (orders == null)
            {
                throw new Exception($"Entity {id} is Not Found");
            }

            _dbSet.Remove(orders);
            _context.SaveChanges();
        }


        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }


        public void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task DeleteAsync(object id)
        {
            var orders = await _dbSet.FindAsync(id);
            if (orders == null)
            {
                throw new Exception($"Entity {id} is Not Found");
            }

            _dbSet.Remove(orders);
            await _context.SaveChangesAsync();
        }
    }
}
