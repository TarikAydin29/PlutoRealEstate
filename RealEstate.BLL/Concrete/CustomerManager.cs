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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Task<Customer> TInsertAsync(Customer entity)
        {
            return _customerDal.InsertAsync(entity);
        }
        public void TDelete(Customer entity)
        {
             _customerDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Customer entity)
        {
            return _customerDal.UpdateAsync(entity);
        }
        public Task<List<Customer>> TGetAllAsync()
        {
            return _customerDal.GetAllAsync();
        }

        public Task<Customer> TGetByIdAsync(Guid Id)
        {
            return _customerDal.GetByIdAsync(Id);
        }
        public Task<int> TSaveAsync()
        {
            return _customerDal.SaveAsync();
        }
    }
}
