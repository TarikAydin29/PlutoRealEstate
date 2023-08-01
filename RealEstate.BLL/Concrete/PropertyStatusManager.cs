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
    public class PropertyStatusManager : IPropertyStatusService
    {
        private readonly IPropertyStatusDal propertyStatusDal;

        public PropertyStatusManager(IPropertyStatusDal propertyStatusDal)
        {

            this.propertyStatusDal = propertyStatusDal;
        }
        public Task<PropertyStatus> TInsertAsync(PropertyStatus entity)
        {
            return propertyStatusDal.InsertAsync(entity);
        }
        public void TDelete(PropertyStatus entity)
        {
            propertyStatusDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(PropertyStatus entity)
        {
            return propertyStatusDal.UpdateAsync(entity);
        }
        public Task<List<PropertyStatus>> TGetAllAsync()
        {
            return propertyStatusDal.GetAllAsync();
        }

        public Task<PropertyStatus> TGetByIdAsync(Guid Id)
        {
            return propertyStatusDal.GetByIdAsync(Id);
        }
        public Task<int> TSaveAsync()
        {
            return propertyStatusDal.SaveAsync();
        }


    }
}
