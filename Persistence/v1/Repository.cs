using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.v1
{
    using Application.Interfaces;
    using Domain.Common;
    using global::Persistence.Context;
    using Microsoft.EntityFrameworkCore;


    namespace Persistence.v1
    {
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
        {
            private readonly DataSetContext context;

            public Repository(DataSetContext context)
            {
                this.context = context;
            }
            public async Task<TEntity> AddAsync(TEntity entity)
            {
                CheckEntityExist(entity, "AddAsync");

                await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> DeleteAsync(TEntity entity)
            {
                CheckEntityExist(entity, "DeleteAsync");

                context.Remove(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                return await context.Set<TEntity>().ToListAsync();
            }

            public async Task<TEntity> GetByIdAsync(Guid id)
            {
                CheckIdExist(id, "GetByIdAsync");

                return await context.FindAsync<TEntity>(id);
            }



            public async Task<TEntity> UpdateAsync(TEntity entity)
            {
                CheckEntityExist(entity, "UpdateAsync");

                context.Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            void CheckEntityExist(TEntity entity, string caller)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(caller)} entity must not be null");
                }
            }

            void CheckIdExist(Guid id, string caller)
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException($"{nameof(caller)} id must not be empty");
                }
            }


        }
    }

}
