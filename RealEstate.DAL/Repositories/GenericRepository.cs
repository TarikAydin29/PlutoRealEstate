using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;
using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
    {
        private readonly Context _context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(Context context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            entity.IsActive = false;
            DbSet.Update(entity);
            _context.SaveChanges();        
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync(Guid Id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Guid> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

    }
}
