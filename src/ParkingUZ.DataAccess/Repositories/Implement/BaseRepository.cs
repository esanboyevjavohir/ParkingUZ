using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Core.Common;
using ParkingUZ.Core.Entities;
using ParkingUZ.Core.Exceptions;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Interface;
using System.Linq.Expressions;

namespace ParkingUZ.DataAccess.Repositories.Implement
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataBaseContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(DataBaseContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        public IQueryable<TEntity> GetAll() =>
            DbSet.AsQueryable();
        
        public IEnumerable<TEntity> GetAllAsEnumerable()
        {
            return DbSet.AsEnumerable();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await Context.User.FindAsync(id);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

            if(entity == null)
                throw new ResourceNotFoundException(typeof(TEntity));

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
