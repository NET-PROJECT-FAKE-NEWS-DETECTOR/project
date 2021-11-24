﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
                }
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> DeleteAsync(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(DeleteAsync)} entity mult not be null");
                }

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
                if (id == Guid.Empty)
                {
                    throw new ArgumentException($"{nameof(GetByIdAsync)} id must not be empty");
                }

                return await context.FindAsync<TEntity>(id);
            }



            public async Task<TEntity> UpdateAsync(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
                }

                context.Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }

}
