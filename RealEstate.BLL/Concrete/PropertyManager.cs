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
    public class PropertyManager : IPropertyService
    {
        private readonly IPropertyDal _propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }
        public Task<Property> TInsertAsync(Property entity)
        {
            return _propertyDal.InsertAsync(entity);
        }
        public void TDelete(Property entity)
        {
            _propertyDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Property entity)
        {
            return _propertyDal.UpdateAsync(entity);
        }
        public Task<List<Property>> TGetAllAsync()
        {
            return _propertyDal.GetAllAsync();
        }

        public Task<Property> TGetByIdAsync(Guid Id)
        {
            return _propertyDal.GetByIdAsync(Id);
        }
        public Task<int> TSaveAsync()
        {
            return (_propertyDal.SaveAsync());
        }

        public IEnumerable<Property> TGetByAgentIdList(Guid id)
        {
            return _propertyDal.GetByAgentIdList(id);
        }
    }
}
