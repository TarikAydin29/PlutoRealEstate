using RealEstate.BLL.Abstract;
using RealEstate.DAL.Abstract;
using RealEstate.DAL.EntityFramework;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public Task<Category> TInsertAsync(Category entity)
        {
            return _categoryDal.InsertAsync(entity);
        }
        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Category entity)
        {
            return _categoryDal.UpdateAsync(entity);
        }

        public Task<List<Category>> TGetAllAsync()
        {
            return _categoryDal.GetAllAsync();
        }

        public Task<Category> TGetByIdAsync(Guid Id)
        {
            return _categoryDal.GetByIdAsync(Id);
        }

        public Task<int> TSaveAsync()
        {
            return (_categoryDal.SaveAsync());
        }

    }
}
