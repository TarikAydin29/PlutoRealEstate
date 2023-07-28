using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Abstract
{
    public interface IGenericDal<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<Guid> UpdateAsync(T entity);
        Task<T> InsertAsync(T entity);
        bool Delete(T entity);
        Task<int> SaveAsync();
    }
}
