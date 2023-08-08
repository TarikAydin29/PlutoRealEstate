using RealEstate.BLL.Abstract;
using RealEstate.DAL.Abstract;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Concrete
{
    public class PropertyPhotoManager : IPropertyPhotoService
    {
        private readonly IPropertyPhotoDAL propertyPhotoDAL;

        public PropertyPhotoManager(IPropertyPhotoDAL propertyPhotoDAL)
        {
            this.propertyPhotoDAL = propertyPhotoDAL;
        }
        public void TDelete(PropertyPhoto entity)
        {
            propertyPhotoDAL.Delete(entity);
        }

        public Task<List<PropertyPhoto>> TGetAllAsync()
        {
            return propertyPhotoDAL.GetAllAsync();
        }

        public Task<PropertyPhoto> TGetByIdAsync(Guid Id)
        {
            return propertyPhotoDAL.GetByIdAsync(Id);
        }

        public IEnumerable<PropertyPhoto> TGetByPropertyIdList(Guid id)
        {
            return propertyPhotoDAL.GetByPropertyIdList(id);
        }

        public Task<PropertyPhoto> TInsertAsync(PropertyPhoto entity)
        {
            return propertyPhotoDAL.InsertAsync(entity);
        }

        public Task<int> TSaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> TUpdateAsync(PropertyPhoto entity)
        {
            return propertyPhotoDAL.UpdateAsync(entity);
        }
    }
}
