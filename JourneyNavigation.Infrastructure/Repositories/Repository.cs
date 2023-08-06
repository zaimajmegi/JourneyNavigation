using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Domain.Models;
using JourneyNavigation.Infrastructure.Data;

namespace JourneyNavigation.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity is User)
            {

                var prop = entity.GetType().GetProperty("IsActive");
                prop.SetValue(entity, false);
                _context.Entry(entity).State = EntityState.Deleted;

            }
            else
                _entities.Remove(entity);
        }

        public virtual void RemoveWithChildren(TEntity entity)
        {
            if (entity is User)
            {
                var prop = entity.GetType().GetProperty("IsActive");
                prop.SetValue(entity, false);
                _context.Entry(entity).State = EntityState.Deleted;

                // Delete all child entities
                foreach (var childEntry in _context.Entry(entity).Collections)
                {
                    if (childEntry.CurrentValue is IEnumerable<User> childEntities)
                    {
                        foreach (var childEntity in childEntities)
                        {
                            var childProp = childEntity.GetType().GetProperty("IsActive");
                            childProp.SetValue(childEntity, false);

                            childEntry.EntityEntry.State = EntityState.Deleted;
                        }
                    }
                }
            }
            else
                _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                if (e is User)
                {
                    e.GetType().GetProperty("IsActive").SetValue(e, false);
                }
                else
                    _entities.Remove(e);
            }
        }

        public virtual int Count()
        {
            var alle = _entities.ToList();
            //if (alle is List<IAuditableEntity>)
            //{
            //    return alle.Where(x => x.GetType().GetProperty("Status").GetValue(x).Equals(RecordStatus.Enabled)).Count();
            //}
            //else
            return _entities.Count();
        }


        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var ent = _entities.Where(predicate);
            return ent;
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var temp = _entities.FirstOrDefault(predicate);
            if (temp != null)
            {
                return temp;
            }
            return null;
        }

        public virtual TEntity Get(int id)
        {

            var temp = _entities.Find(id);
            if (temp != null)
            {
                return temp;
            }
            return null;
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            var all = _entities.ToList();
            return all;
        }
        public virtual async Task<TEntity> GetAsync(int id)
        {
            var temp = await _entities.FindAsync(id);
            if (temp != null)
            {
                return temp;
            }
            return null;
        }
        public virtual async Task<TEntity> GetAsync(string id)
        {
            var temp = await _entities.FindAsync(id);
            if (temp != null)
            {
                return temp;
            }
            return null;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var all = await _entities.ToListAsync();
            return all;
        }


        public IQueryable<TEntity> GetAllQueryable()
        {
            return _entities;
        }
    }
}
