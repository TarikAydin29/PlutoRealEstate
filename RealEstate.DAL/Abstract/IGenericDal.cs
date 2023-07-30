using RealEstate.Core.Entities;

namespace RealEstate.DAL.Abstract
{
    public interface IGenericDal<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<Guid> UpdateAsync(T entity);
        Task<T> InsertAsync(T entity);
        void Delete(T entity);
        Task<int> SaveAsync();
    }
}
