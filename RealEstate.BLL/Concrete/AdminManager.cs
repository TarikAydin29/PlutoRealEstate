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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Task<Admin> TInsertAsync(Admin entity)
        {
            return _adminDal.InsertAsync(entity);
        }
        public bool TDelete(Admin entity)
        {
            return _adminDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Admin entity)
        {
            return _adminDal.UpdateAsync(entity);
        }

        public Task<List<Admin>> TGetAllAsync()
        {
            return _adminDal.GetAllAsync();
        }

        public Task<Admin> TGetByIdAsync(Guid Id)
        {
            return _adminDal.GetByIdAsync(Id);
        }
        public Task<int> TSaveAsync()
        {
            return (_adminDal.SaveAsync());
        }
    }
}
