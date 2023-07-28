using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Abstract
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<List<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(Guid Id);
        Task<Guid> TUpdateAsync(T entity);
        Task<T> TInsertAsync(T entity);
        void TDelete(T entity);
        Task<int> TSaveAsync();
    }
}
